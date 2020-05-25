CREATE TABLE [dbo].[Chapter] (
    [Id]            INT IDENTITY (1, 1) NOT NULL,
    [TranslationId] INT NOT NULL,
    [BookId]        UNIQUEIDENTIFIER NOT NULL,
    [ChapterNo]     INT NOT NULL,
    CONSTRAINT [PK_Chapter] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Chapter_Book_BookId] FOREIGN KEY ([BookId]) REFERENCES [dbo].[Book] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Chapter_Translation_TranslationId] FOREIGN KEY ([TranslationId]) REFERENCES [dbo].[Translation] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Chapter_BookId]
    ON [dbo].[Chapter]([BookId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Chapter_TranslationId]
    ON [dbo].[Chapter]([TranslationId] ASC);

