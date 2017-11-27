CREATE TABLE [dbo].[Rating] (
    [RatingId] INT         IDENTITY (1, 1) NOT NULL,
    [Rating]   VARCHAR (5) NOT NULL,
    PRIMARY KEY CLUSTERED ([RatingId] ASC)
);

