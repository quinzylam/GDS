CREATE TABLE [dbo].[Translation] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Title]       NVARCHAR (MAX) NULL,
    [Code]        INT            NOT NULL,
    [Description] NVARCHAR (MAX) NULL,
    [HasStrongs]  BIT            NOT NULL,
    CONSTRAINT [PK_Translation] PRIMARY KEY CLUSTERED ([Id] ASC)
);

