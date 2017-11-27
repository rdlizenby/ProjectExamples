CREATE TABLE [dbo].[Dvd] (
    [DvdId]       INT           IDENTITY (1, 1) NOT NULL,
    [Title]       VARCHAR (50)  NOT NULL,
    [ReleaseYear] INT           NOT NULL,
    [Director]    VARCHAR (30)  NOT NULL,
    [RatingId]    INT           NOT NULL,
    [Notes]       VARCHAR (500) NULL,
    PRIMARY KEY CLUSTERED ([DvdId] ASC),
    FOREIGN KEY ([RatingId]) REFERENCES [dbo].[Rating] ([RatingId])
);

