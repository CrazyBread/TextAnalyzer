CREATE TABLE [dbo].[JournalDetails]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[JournalId] [int] NOT NULL,
[PropertyId] [int] NOT NULL,
[OldValue] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[NewValue] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Created] [datetime2] (2) NOT NULL CONSTRAINT [DF_JournalDetails_Created] DEFAULT (getdate())
)
GO
ALTER TABLE [dbo].[JournalDetails] ADD CONSTRAINT [PK_JournalDetails] PRIMARY KEY CLUSTERED  ([Id])
GO
ALTER TABLE [dbo].[JournalDetails] ADD CONSTRAINT [FK_JournalDetails_Journal] FOREIGN KEY ([JournalId]) REFERENCES [dbo].[Journal] ([Id])
GO
ALTER TABLE [dbo].[JournalDetails] ADD CONSTRAINT [FK_JournalDetails_JournalFacet_Property] FOREIGN KEY ([PropertyId]) REFERENCES [dbo].[JournalFacet] ([Id])
GO
