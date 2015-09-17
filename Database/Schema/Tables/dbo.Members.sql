CREATE TABLE [dbo].[Members]
(
[MemberId] [int] NOT NULL IDENTITY(1, 1),
[MembershipCode] [varchar] (20) COLLATE Latin1_General_CI_AS NOT NULL,
[FirstName] [nvarchar] (30) COLLATE Latin1_General_CI_AS NOT NULL,
[LastName] [nvarchar] (30) COLLATE Latin1_General_CI_AS NOT NULL,
[Address1] [nvarchar] (50) COLLATE Latin1_General_CI_AS NOT NULL,
[Address2] [nvarchar] (50) COLLATE Latin1_General_CI_AS NULL,
[PostCode] [nvarchar] (10) COLLATE Latin1_General_CI_AS NOT NULL,
[City] [nvarchar] (30) COLLATE Latin1_General_CI_AS NOT NULL,
[FavouriteProduct] [int] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Members] ADD CONSTRAINT [PK_Members_MemberId] PRIMARY KEY CLUSTERED  ([MemberId]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Members] ADD CONSTRAINT [FK_FavouriteItem] FOREIGN KEY ([FavouriteProduct]) REFERENCES [dbo].[CurrentPrices] ([ItemId])
GO
