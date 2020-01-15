CREATE TABLE [dbo].[MorphologyIndication] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [Indication]   NVARCHAR (MAX) NULL,
    [ApplicableTo] NVARCHAR (MAX) NULL,
    [Meaning]      NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_MorphologyIndication] PRIMARY KEY CLUSTERED ([Id] ASC)
);

