CREATE TABLE [dbo].[Facet]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[Group] [nvarchar] (16) COLLATE Cyrillic_General_CI_AS NOT NULL,
[RedmineId] [int] NOT NULL,
[Name] [nvarchar] (200) COLLATE Cyrillic_General_CI_AS NOT NULL
)
GO
ALTER TABLE [dbo].[Facet] ADD CONSTRAINT [PK_Facet] PRIMARY KEY CLUSTERED  ([Id])
GO
