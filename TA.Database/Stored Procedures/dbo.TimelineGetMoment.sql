
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Description:	Возвращает число задач на полночь конкретного дня, сгруппированную по статусам.
-- =============================================
CREATE PROCEDURE [dbo].[TimelineGetMoment]
	@StartDate DATE,
	@DaysStep INT = 1
AS
BEGIN
	SET NOCOUNT ON;
	SET FMTONLY OFF;

	DECLARE @CurrentDate DATE, @EndDate DATE = GETDATE()

	IF OBJECT_ID('tempdb..#tmp') IS NOT NULL
		DROP TABLE #tmp

	-- create temp table
	CREATE TABLE #tmp (IssueId INT, StatusId INT, DateStart DATETIME2(2))

	-- fill tmp
	EXEC dbo.TimelineFillTmp

	-- create groupable table
	CREATE TABLE #grp ([Date] DATE, StatusId INT, [Count] INT)

	-- fill groupable table
	SET @CurrentDate = @StartDate
	WHILE(@CurrentDate <= @EndDate) BEGIN
		INSERT INTO #grp ( Date, StatusId, Count )
		SELECT @CurrentDate, t.StatusId, COUNT(DISTINCT t.IssueId)
			FROM #tmp t
			LEFT JOIN #tmp t_another ON t.IssueId = t_another.IssueId AND t_another.DateStart > t.DateStart AND t_another.DateStart < @CurrentDate
			JOIN dbo.Issue i ON i.Id = t.IssueId
			WHERE t.DateStart < @CurrentDate AND t_another.IssueId IS NULL-- AND i.ProjectId != 4 -- не приборка
			GROUP BY t.StatusId

		INSERT INTO #grp ( Date, StatusId, Count )
		SELECT @CurrentDate, s.Id, 0
			FROM dbo.Facet s
			WHERE s.[Group] = 'status' AND NOT EXISTS(SELECT TOP 1 NULL FROM #grp WHERE [Date] = @CurrentDate AND StatusId = s.Id)

		SET @CurrentDate = DATEADD(DAY, @DaysStep, @CurrentDate)
	END

	-- select from groupable table
	SELECT  g.Date, g.StatusId, g.Count, f.Name AS StatusName
		FROM #grp g 
		JOIN dbo.Facet f ON f.Id = g.StatusId
		ORDER BY [Date], g.StatusId

	-- drop temporary tables
	DROP TABLE #tmp
	DROP TABLE #grp
END
GO
