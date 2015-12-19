CREATE TABLE [dbo].[Word]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[IssueId] [int] NOT NULL,
[Text] [nvarchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Count] [int] NOT NULL CONSTRAINT [DF_Word_Count] DEFAULT ((0)),
[WordsInText] [int] NOT NULL,
[Created] [datetime2] (2) NOT NULL CONSTRAINT [DF_Word_Created] DEFAULT (getdate())
)
ALTER TABLE [dbo].[Word] ADD 
CONSTRAINT [PK_Word] PRIMARY KEY CLUSTERED  ([Id])
GO
ALTER TABLE [dbo].[Word] ADD CONSTRAINT [IX_Word] UNIQUE NONCLUSTERED  ([IssueId], [Text])

GO

ALTER TABLE [dbo].[Word] ADD CONSTRAINT [FK_Word_Issue] FOREIGN KEY ([IssueId]) REFERENCES [dbo].[Issue] ([Id])
GO
