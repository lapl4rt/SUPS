CREATE TABLE [dbo].[Region] (
    [Region_ID] INT           IDENTITY (1, 1) NOT NULL,
    [Name]      NVARCHAR (50) NOT NULL,
    [NameEng]   NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Region] PRIMARY KEY CLUSTERED ([Region_ID] ASC)
);

