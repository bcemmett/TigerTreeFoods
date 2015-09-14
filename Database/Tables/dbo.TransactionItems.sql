CREATE TABLE [dbo].[TransactionItems]
(
[TransactionItemId] [int] NOT NULL IDENTITY(1, 1),
[TransactionId] [int] NOT NULL,
[PricePaid] [money] NOT NULL,
[ItemId] [int] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[TransactionItems] ADD CONSTRAINT [PK_TransactionItems_TransactionItemId] PRIMARY KEY CLUSTERED  ([TransactionItemId]) ON [PRIMARY]
GO
