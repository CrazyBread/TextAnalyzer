
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Description:	Возвращает число задач за интервал, изменивших статус с указанного и на указанный.
-- =============================================
CREATE PROCEDURE [dbo].[TimelineGetIntervalChange]
	@StartDate DATE,
	@DaysStep INT = 1,
	@StatusId INT = NULL
AS
BEGIN
	SET NOCOUNT ON;
	SET FMTONLY OFF;

	DECLARE @CurrentDate DATE, @EndDate DATE = GETDATE()

	-- create groupable table
	CREATE TABLE #grp ([Date] DATE, StatusId INT, [CountIn] INT, [CountOut] INT)

	-- fill groupable table
	CREATE UNIQUE INDEX UQ_IX_grp ON #grp (Date, StatusId)

	SET @CurrentDate = @StartDate
	WHILE(@CurrentDate <= @EndDate) BEGIN
		INSERT INTO #grp ( Date, StatusId, CountIn, CountOut )
		SELECT @CurrentDate, s.Id, 0, 0
			FROM dbo.Facet s
			WHERE s.[Group] = 'status'

		UPDATE g SET CountIn = r.C
		FROM #grp g
		JOIN  (SELECT @CurrentDate D, f_t.Id I, COUNT(DISTINCT j.IssueId) C
				FROM dbo.Journal j
				JOIN dbo.JournalDetails jd ON j.Id = jd.JournalId
				JOIN dbo.JournalFacet jf ON jf.Id = jd.PropertyId AND jf.Property = 'attr' AND jf.Name = 'status_id'
				JOIN dbo.Facet f_t ON f_t.RedmineId = CAST(jd.NewValue AS INT) AND f_t.[Group] = 'status'
				WHERE j.Date > @CurrentDate AND j.Date < DATEADD(DAY, @DaysStep, @CurrentDate) AND f_t.Id = ISNULL(@StatusId, f_t.Id)
				GROUP BY f_t.Id) r ON r.I = g.StatusId
		WHERE g.Date = @CurrentDate

		UPDATE g SET CountOut = r.C
		FROM #grp g
		JOIN  (SELECT @CurrentDate D, f_t.Id I, COUNT(DISTINCT j.IssueId) C
				FROM dbo.Journal j
				JOIN dbo.JournalDetails jd ON j.Id = jd.JournalId
				JOIN dbo.JournalFacet jf ON jf.Id = jd.PropertyId AND jf.Property = 'attr' AND jf.Name = 'status_id'
				JOIN dbo.Facet f_t ON f_t.RedmineId = CAST(jd.OldValue AS INT) AND f_t.[Group] = 'status'
				WHERE j.Date > @CurrentDate AND j.Date < DATEADD(DAY, @DaysStep, @CurrentDate) AND f_t.Id = ISNULL(@StatusId, f_t.Id)
				GROUP BY f_t.Id) r ON r.I = g.StatusId
		WHERE g.Date = @CurrentDate

		SET @CurrentDate = DATEADD(DAY, @DaysStep, @CurrentDate)
	END

	-- select from groupable table
	SELECT  g.Date, g.StatusId, g.CountIn, g.CountOut, f.Name AS StatusName
		FROM #grp g 
		JOIN dbo.Facet f ON f.Id = g.StatusId AND f.Id = ISNULL(@StatusId, f.Id)
		ORDER BY [Date], g.StatusId

	-- drop temporary tables
	DROP TABLE #grp
END
GO
