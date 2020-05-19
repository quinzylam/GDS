CREATE TABLE [dbo].[Translation] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Title]       NVARCHAR (30) NULL,
    [Code]        NVARCHAR(15)            NOT NULL,
    [Description] NVARCHAR (250) NULL,
    [HasStrongs]  BIT            NOT NULL,
    CONSTRAINT [PK_Translation] PRIMARY KEY CLUSTERED ([Id] ASC)
);

