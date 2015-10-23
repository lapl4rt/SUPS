CREATE TABLE [dbo].[Cargo] (
    [Cargo_ID]       INT             IDENTITY (7000, 1) NOT NULL,
    [Name]           NVARCHAR (100)  NULL,
    [NameEng]        NVARCHAR (120)  NULL,
    [Description]    NVARCHAR (250)  NULL,
    [DescriptionEng] NVARCHAR (250)  NULL,
    [ShortCode]      NCHAR (5)       NOT NULL,
    [Code]           NCHAR (6)       NOT NULL,
    [CodeGNG]        NCHAR (8)       NULL,
    [Mnemocode]      NVARCHAR (12)   NULL,
    [MnemocodeEng]   NVARCHAR (30)   NULL,
    [IsUsed]         BIT             CONSTRAINT [DF_Cargo_IsUsed] DEFAULT ((0)) NOT NULL,
    [IsEmpty]        BIT             CONSTRAINT [DF_Cargo_IsEmpty] DEFAULT ((0)) NOT NULL,
    [Image]          VARBINARY (MAX) NULL,
    CONSTRAINT [PK_RW_Cargo] PRIMARY KEY CLUSTERED ([Cargo_ID] ASC)
);




GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Справочник ЕТСНГ урезанные кода(ГВЦ)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Cargo', @level2type = N'COLUMN', @level2name = N'ShortCode';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Справочник ЕТСНГ(ИВЦ)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Cargo', @level2type = N'COLUMN', @level2name = N'Code';

