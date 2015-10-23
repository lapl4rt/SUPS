CREATE TABLE [dbo].[HistoryDislocations] (
    [CargoName]            NVARCHAR (100) NULL,
    [CarNumber]            NVARCHAR (8)   NOT NULL,
    [Weight]               NVARCHAR (3)   NULL,
    [ReceiverCode]         NVARCHAR (13)  NULL,
    [CarType]              NVARCHAR (13)  NULL,
    [OperationName]        NVARCHAR (300) NULL,
    [ArriveStation]        NVARCHAR (100) NULL,
    [OperationStationName] NVARCHAR (100) NULL,
    [DepartStation]        NVARCHAR (100) NULL,
    [OperationDate]        NVARCHAR (13)  NULL,
    [OperationYear]        NVARCHAR (13)  NULL,
    [OperationTime]        NVARCHAR (13)  NULL,
    [DeliveryRoad]         NVARCHAR (100) NULL,
    [ReceiptRoad]          NVARCHAR (100) NULL,
    [TrainIndex]           NVARCHAR (13)  NULL,
    [TrainNumber]          NVARCHAR (13)  NULL,
    CONSTRAINT [PK_HistoryDislocations] PRIMARY KEY CLUSTERED ([CarNumber] ASC)
);

