CREATE TABLE [dbo].[Members]
(
[MemberId] [int] NOT NULL IDENTITY(1, 1),
[MembershipCode] [varchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[FirstName] [nvarchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[LastName] [nvarchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Address1] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Address2] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[PostCode] [nvarchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[City] [nvarchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[FavouriteProductId] [int] NOT NULL
) ON [PRIMARY]
CREATE UNIQUE NONCLUSTERED INDEX [NonClusteredIndex_MemberId_MembershipCode_FirstName_LastName_City_FavouriteProductId] ON [dbo].[Members] ([MembershipCode], [FirstName], [LastName], [City], [FavouriteProductId]) INCLUDE ([Address1], [Address2], [PostCode]) ON [PRIMARY]

ALTER TABLE [dbo].[Members] ADD
CONSTRAINT [FK_FavouriteProductId] FOREIGN KEY ([FavouriteProductId]) REFERENCES [dbo].[Products] ([ProductId])


GO
ALTER TABLE [dbo].[Members] ADD CONSTRAINT [PK_Members_MemberId] PRIMARY KEY CLUSTERED  ([MemberId]) ON [PRIMARY]
GO
