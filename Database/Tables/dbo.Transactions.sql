CREATE TABLE [dbo].[Transactions]
(
[TransactionId] [int] NOT NULL IDENTITY(1, 1),
[MemberId] [int] NULL,
[TotalPrice] [money] NOT NULL,
[PurchaseDate] [datetime] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Transactions] ADD CONSTRAINT [PK_Transactions_TransactionId] PRIMARY KEY CLUSTERED  ([TransactionId]) ON [PRIMARY]
GO
