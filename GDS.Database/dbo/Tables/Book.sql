CREATE TABLE [dbo].[Book] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [Title]      NVARCHAR (MAX) NULL,
    [ShortTitle] NVARCHAR (MAX) NULL,
    [Section]    INT            NOT NULL,
    [Colour]     NVARCHAR (MAX) NULL,
    [BookNo]     INT            DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED ([Id] ASC)
);

