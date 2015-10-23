CREATE TABLE [dbo].[Road] (
    [Road_ID]      INT            IDENTITY (1, 1) NOT NULL,
    [Code]         NVARCHAR (50)  NOT NULL,
    [Mnemocode]    NVARCHAR (50)  NULL,
    [Name]         NVARCHAR (100) NULL,
    [ShortName]    NVARCHAR (20)  NULL,
    [MnemocodeEng] NVARCHAR (50)  NULL,
    [NameEng]      NVARCHAR (110) NULL,
    [ShortNameEng] NVARCHAR (25)  NULL,
    CONSTRAINT [PK_Road] PRIMARY KEY CLUSTERED ([Road_ID] ASC),
    CONSTRAINT [Code_Road] UNIQUE NONCLUSTERED ([Code] ASC)
);

