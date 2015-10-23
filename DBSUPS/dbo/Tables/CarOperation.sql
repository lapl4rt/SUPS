CREATE TABLE [dbo].[CarOperation] (
    [CarOperation_ID]         INT            IDENTITY (1, 1) NOT NULL,
    [Name]                    NVARCHAR (300) NULL,
    [Code]                    NCHAR (2)      NULL,
    [Mnemocode]               NVARCHAR (15)  NOT NULL,
    [OperationType]           TINYINT        CONSTRAINT [DF_CarOperation_OperationType] DEFAULT ((0)) NOT NULL,
    [MnemocodeEng]            NVARCHAR (20)  NULL,
    [NameEng]                 NVARCHAR (350) NULL,
    [MnemocodeMixedLang]      NVARCHAR (6)   NULL,
    [MnemocodeMixedLangShort] NVARCHAR (6)   NULL,
    [IsUsed]                  BIT            CONSTRAINT [DF_CarOperation_IsUsed] DEFAULT ((0)) NOT NULL,
    [IsForGVCUsing]           BIT            CONSTRAINT [DF_CarOperation_IsForGVCUsing] DEFAULT ((0)) NOT NULL,
    [IsStartShip]             BIT            CONSTRAINT [DF_CarOperation_IsStartShip] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_RW_CarOperation] PRIMARY KEY CLUSTERED ([CarOperation_ID] ASC),
    CONSTRAINT [UN_CarOperation_OperationType_Code] UNIQUE NONCLUSTERED ([OperationType] ASC, [Code] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'тип операции 0-с вагоном, 1-с поездом, 2-с контейнером', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CarOperation', @level2type = N'COLUMN', @level2name = N'OperationType';

