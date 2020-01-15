CREATE TABLE [dbo].[Verse] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [VerseNo]   INT            NOT NULL,
    [Text]      NVARCHAR (MAX) NULL,
    [ChapterId] INT            DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Verse] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Verse_Chapter_ChapterId] FOREIGN KEY ([ChapterId]) REFERENCES [dbo].[Chapter] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Verse_ChapterId]
    ON [dbo].[Verse]([ChapterId] ASC);

