CREATE TABLE [dbo].[TransactionItems]
(
[TransactionItemId] [int] NOT NULL IDENTITY(1, 1),
[TransactionId] [int] NOT NULL,
[PricePaid] [money] NOT NULL,
[ItemId] [int] NOT NULL
) ON [PRIMARY]
ALTER TABLE [dbo].[TransactionItems] ADD
CONSTRAINT [FK_ItemId] FOREIGN KEY ([ItemId]) REFERENCES [dbo].[CurrentPrices] ([ItemId])
ALTER TABLE [dbo].[TransactionItems] ADD
CONSTRAINT [FK_TransactionId] FOREIGN KEY ([TransactionId]) REFERENCES [dbo].[Transactions] ([TransactionId])
GO
ALTER TABLE [dbo].[TransactionItems] ADD CONSTRAINT [PK_TransactionItems_TransactionItemId] PRIMARY KEY CLUSTERED  ([TransactionItemId]) ON [PRIMARY]
GO
