SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Description:	Заполнение таблицы #tmp статусами задач на основе журналов.
-- =============================================
CREATE PROCEDURE [dbo].[TimelineFillTmp]
AS
BEGIN
	SET NOCOUNT ON;

	-- fill by default values
	INSERT INTO #tmp ( IssueId, StatusId, DateStart )
	SELECT i.Id, i.StatusId, i.Created
		FROM dbo.Issue i
		--WHERE i.RedmineId = 10667 -- TODO: Remove it when all data will be correct.

	-- update first status
	UPDATE t SET StatusId = f.Id
		FROM #tmp t
		JOIN dbo.Issue i ON t.IssueId = i.Id
		JOIN (SELECT jd.OldValue, j.IssueId, ROW_NUMBER() OVER(PARTITION BY j.IssueId ORDER BY j.Date) rn
				FROM dbo.JournalDetails jd
				JOIN dbo.Journal j ON j.Id = jd.JournalId
				JOIN dbo.JournalFacet jf ON jf.Id = jd.PropertyId AND jf.Property = 'attr' AND jf.Name = 'status_id'
			) jd_first ON jd_first.rn = 1 AND jd_first.IssueId = i.Id
		JOIN dbo.Facet f ON f.RedmineId = CAST(jd_first.OldValue AS INT) AND f.[Group] = 'status'

	-- insert while exists another statuses
	INSERT INTO #tmp ( IssueId, StatusId, DateStart )
	SELECT i.Id, f.Id, j.Date
		FROM dbo.Issue i
		JOIN dbo.Journal j ON j.IssueId = i.Id
		JOIN dbo.JournalDetails jd ON jd.JournalId = j.Id
		JOIN dbo.JournalFacet jf ON jf.Id = jd.PropertyId AND jf.Property = 'attr' AND jf.Name = 'status_id'
		JOIN dbo.Facet f ON f.[Group] = 'status' AND f.RedmineId = CAST(jd.NewValue AS INT)
END
GO
