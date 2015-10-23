CREATE TABLE [dbo].[CargoGuide] (
    [CargoID]     INT            NOT NULL,
    [CargoName]   NVARCHAR (100) NULL,
    [Description] NVARCHAR (250) NULL,
    [CargoCode]   NCHAR (6)      NOT NULL,
    [ETSNGCode]   NCHAR (6)      NOT NULL,
    [ETSNGName]   NVARCHAR (250) NULL,
    [GNGCode]     NCHAR (8)      NOT NULL,
    [GNGName]     NVARCHAR (250) NULL,
    [Mnemocode]   NVARCHAR (12)  NULL,
    [IsUsed]      BIT            NOT NULL,
    [IsEmpty]     BIT            NOT NULL
);

