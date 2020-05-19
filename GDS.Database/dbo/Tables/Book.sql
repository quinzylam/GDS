CREATE TABLE [dbo].[Book] (
    [Id]         UNIQUEIDENTIFIER   NOT NULL,
    [Title]      NVARCHAR (30) NULL,
    [ShortTitle] NVARCHAR (15) NULL,
    [Section]    INT            NOT NULL,
    [Colour]     NVARCHAR (15) NULL,
    [BookNo]     INT            DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED ([Id] ASC)
);

