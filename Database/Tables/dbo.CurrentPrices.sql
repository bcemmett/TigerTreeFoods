CREATE TABLE [dbo].[CurrentPrices]
(
[ItemId] [int] NOT NULL IDENTITY(1, 1),
[Barcode] [nvarchar] (30) COLLATE Latin1_General_CI_AS NOT NULL,
[RegularPrice] [money] NOT NULL,
[OfferPrice] [money] NULL,
[TillDescription] [nvarchar] (100) COLLATE Latin1_General_CI_AS NOT NULL
) ON [PRIMARY]
ALTER TABLE [dbo].[CurrentPrices] ADD 
CONSTRAINT [PK_CurrentPrices_ItemId] PRIMARY KEY CLUSTERED  ([ItemId]) ON [PRIMARY]
GO
