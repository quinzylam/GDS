CREATE TABLE [dbo].[Dictionary] (
    [Id]                    INT            IDENTITY (1, 1) NOT NULL,
    [Topic]                 NVARCHAR (MAX) NULL,
    [Definition]            NVARCHAR (MAX) NULL,
    [Lexeme]                NVARCHAR (MAX) NULL,
    [Transliteration]       NVARCHAR (MAX) NULL,
    [Pronunciation]         NVARCHAR (MAX) NULL,
    [ShortDefinition]       NVARCHAR (MAX) NULL,
    [CognateStrongNumberId] INT            NULL,
    [Index]                 INT            DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Dictionary] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Dictionary_CognateStrongNumber_CognateStrongNumberId] FOREIGN KEY ([CognateStrongNumberId]) REFERENCES [dbo].[CognateStrongNumber] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Dictionary_CognateStrongNumberId]
    ON [dbo].[Dictionary]([CognateStrongNumberId] ASC);

