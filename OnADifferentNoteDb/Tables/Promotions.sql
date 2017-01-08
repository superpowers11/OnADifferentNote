CREATE TABLE [dbo].[Promotions]
(
		[PromotionId] INT NOT NULL PRIMARY KEY IDENTITY,
	[PromoName] VARCHAR(40) NOT NULL,
	[PromoDescription] VARCHAR(MAX) NOT NULL,
	[PromoStart] DATE NOT NULL,
	[PromoEnd] DATE NOT NULL,
	[PromoDateCreated] DATE NOT NULL,
	[SalePrice] FLOAT,
	[OverallDiscount] FLOAT,
	[ZipCode] INT,
	[PromoType] VARCHAR(25) NOT NULL
)
