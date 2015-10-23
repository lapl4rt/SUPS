CREATE TABLE [dbo].[CargoGNG] (
    [CargoGNG_ID] NCHAR (8)      NOT NULL,
    [Name]        NVARCHAR (250) NULL,
    [NameEng]     NVARCHAR (250) NULL,
    CONSTRAINT [PK_CargoGNG] PRIMARY KEY CLUSTERED ([CargoGNG_ID] ASC)
);

