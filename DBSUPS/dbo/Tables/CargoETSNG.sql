CREATE TABLE [dbo].[CargoETSNG] (
    [CargoETSNG_ID] NCHAR (6)      NOT NULL,
    [Name]          NVARCHAR (250) NULL,
    [NameEng]       NVARCHAR (250) NULL,
    [CargoGNG_ID]   NCHAR (8)      NULL,
    CONSTRAINT [PK_CargoETSNG] PRIMARY KEY CLUSTERED ([CargoETSNG_ID] ASC)
);

