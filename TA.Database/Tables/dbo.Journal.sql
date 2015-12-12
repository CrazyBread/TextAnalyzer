CREATE TABLE [dbo].[Journal]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[IssueId] [int] NOT NULL,
[RedmineId] [int] NOT NULL,
[AuthorId] [int] NULL,
[Date] [datetime2] (2) NOT NULL,
[Created] [datetime2] (2) NOT NULL CONSTRAINT [DF_Journal_Created] DEFAULT (getdate())
)
GO
ALTER TABLE [dbo].[Journal] ADD CONSTRAINT [PK_Journal] PRIMARY KEY CLUSTERED  ([Id])
GO
ALTER TABLE [dbo].[Journal] ADD CONSTRAINT [FK_Journal_Facet_Author] FOREIGN KEY ([AuthorId]) REFERENCES [dbo].[Facet] ([Id])
GO
ALTER TABLE [dbo].[Journal] ADD CONSTRAINT [FK_Journal_Issue] FOREIGN KEY ([IssueId]) REFERENCES [dbo].[Issue] ([Id])
GO
