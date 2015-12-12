CREATE TABLE [dbo].[Issue]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[RedmineId] [int] NOT NULL,
[ProjectId] [int] NOT NULL,
[TrackerId] [int] NOT NULL,
[StatusId] [int] NOT NULL,
[PriorityId] [int] NOT NULL,
[AuthorId] [int] NULL,
[Subject] [nvarchar] (1000) COLLATE Cyrillic_General_CI_AS NOT NULL,
[Description] [nvarchar] (max) COLLATE Cyrillic_General_CI_AS NULL,
[Created] [datetime2] (2) NOT NULL,
[Updated] [datetime2] (2) NULL
)
GO
ALTER TABLE [dbo].[Issue] ADD CONSTRAINT [PK_Issue] PRIMARY KEY CLUSTERED  ([Id])
GO
ALTER TABLE [dbo].[Issue] ADD CONSTRAINT [IX_Issue] UNIQUE NONCLUSTERED  ([RedmineId])
GO
ALTER TABLE [dbo].[Issue] ADD CONSTRAINT [FK_Issue_Facet_Author] FOREIGN KEY ([AuthorId]) REFERENCES [dbo].[Facet] ([Id])
GO
ALTER TABLE [dbo].[Issue] ADD CONSTRAINT [FK_Issue_Facet_Priority] FOREIGN KEY ([PriorityId]) REFERENCES [dbo].[Facet] ([Id])
GO
ALTER TABLE [dbo].[Issue] ADD CONSTRAINT [FK_Issue_Facet_Project] FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[Facet] ([Id])
GO
ALTER TABLE [dbo].[Issue] ADD CONSTRAINT [FK_Issue_Facet_Status] FOREIGN KEY ([StatusId]) REFERENCES [dbo].[Facet] ([Id])
GO
ALTER TABLE [dbo].[Issue] ADD CONSTRAINT [FK_Issue_Facet_Tracker] FOREIGN KEY ([TrackerId]) REFERENCES [dbo].[Facet] ([Id])
GO
