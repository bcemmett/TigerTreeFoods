CREATE TABLE [dbo].[CurrentPrices]
(
[ItemId] [int] NOT NULL IDENTITY(1, 1),
[Barcode] [nvarchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[RegularPrice] [money] NOT NULL,
[OfferPrice] [money] NULL,
[TillDescription] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Image] [varbinary] (max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[CurrentPrices] ADD CONSTRAINT [Unique_Barcode] UNIQUE NONCLUSTERED  ([Barcode]) ON [PRIMARY]

CREATE UNIQUE NONCLUSTERED INDEX [NonClusteredIndex_ItemId_Barcode] ON [dbo].[CurrentPrices] ([ItemId], [Barcode]) INCLUDE ([OfferPrice], [RegularPrice], [TillDescription]) ON [PRIMARY]



ALTER TABLE [dbo].[CurrentPrices] ADD 
CONSTRAINT [PK_CurrentPrices_ItemId] PRIMARY KEY CLUSTERED  ([ItemId]) ON [PRIMARY]
GO
