CREATE TABLE [dbo].[CTM_Country] (
    [CTM_Country_ID] CHAR (2)       NOT NULL,
    [Name]           NVARCHAR (200) NULL,
    [NameEng]        NVARCHAR (200) NULL,
    [IsUsedForData]  BIT            CONSTRAINT [DF_CTM_Country_IsUsedForData] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_CTM_Country] PRIMARY KEY CLUSTERED ([CTM_Country_ID] ASC)
);

