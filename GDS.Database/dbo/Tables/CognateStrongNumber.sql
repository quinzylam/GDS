CREATE TABLE [dbo].[CognateStrongNumber] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [GroupId]      INT            NOT NULL,
    [StrongNumber] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_CognateStrongNumber] PRIMARY KEY CLUSTERED ([Id] ASC)
);

