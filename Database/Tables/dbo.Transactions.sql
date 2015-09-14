CREATE TABLE [dbo].[Transactions]
(
[TransactionId] [int] NOT NULL IDENTITY(1, 1),
[MemberId] [int] NULL,
[TotalPrice] [money] NOT NULL,
[PurchaseDate] [datetime] NOT NULL
) ON [PRIMARY]
ALTER TABLE [dbo].[Transactions] ADD
CONSTRAINT [FK_MemberId] FOREIGN KEY ([MemberId]) REFERENCES [dbo].[Members] ([MemberId])
GO
ALTER TABLE [dbo].[Transactions] ADD CONSTRAINT [PK_Transactions_TransactionId] PRIMARY KEY CLUSTERED  ([TransactionId]) ON [PRIMARY]
GO
