CREATE TABLE [dbo].[ShipmentClient] (
    [ShipmentClient_ID] INT            IDENTITY (1, 1) NOT NULL,
    [Code]              NVARCHAR (4)   NULL,
    [Name]              NVARCHAR (200) NULL,
    [NameEng]           NVARCHAR (210) NULL,
    CONSTRAINT [PK_ShipmentClient] PRIMARY KEY CLUSTERED ([ShipmentClient_ID] ASC)
);

