CREATE TABLE [dbo].[Products]
(
[ProductId] [int] NOT NULL IDENTITY(1, 1),
[Barcode] [nvarchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[RegularPrice] [money] NOT NULL,
[OfferPrice] [money] NULL,
[TillDescription] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Image] [varbinary] (max) NULL,
[Category] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
CREATE NONCLUSTERED INDEX [NonClusteredIndex_Category] ON [dbo].[Products] ([Category]) INCLUDE ([Barcode], [OfferPrice], [ProductId], [RegularPrice], [TillDescription]) ON [PRIMARY]

CREATE UNIQUE NONCLUSTERED INDEX [NonClusteredIndex_ProductId_Barcode] ON [dbo].[Products] ([ProductId], [Barcode]) INCLUDE ([Category], [OfferPrice], [RegularPrice], [TillDescription]) ON [PRIMARY]





GO
ALTER TABLE [dbo].[Products] ADD CONSTRAINT [PK_CurrentPrices_ProductId] PRIMARY KEY CLUSTERED  ([ProductId]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Products] ADD CONSTRAINT [Unique_Barcode] UNIQUE NONCLUSTERED  ([Barcode]) ON [PRIMARY]
GO
