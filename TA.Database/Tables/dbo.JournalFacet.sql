CREATE TABLE [dbo].[JournalFacet]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[Property] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Name] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Created] [datetime2] (2) NOT NULL CONSTRAINT [DF_JournalFacet_Created] DEFAULT (getdate())
)
GO
ALTER TABLE [dbo].[JournalFacet] ADD CONSTRAINT [PK_JournalFacet] PRIMARY KEY CLUSTERED  ([Id])
GO
ALTER TABLE [dbo].[JournalFacet] ADD CONSTRAINT [UQ_IX_JournalFacet] UNIQUE NONCLUSTERED  ([Property], [Name])
GO
