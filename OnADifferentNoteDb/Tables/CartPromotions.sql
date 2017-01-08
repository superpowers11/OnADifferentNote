CREATE TABLE [dbo].[CartPromotions]
(
	[CartPromotionId] INT NOT NULL PRIMARY KEY IDENTITY,
	[PromotionId] INT NOT NULL,
	[ApplicableProductId] INT,
	CONSTRAINT [FK_CartPromotions_Promotions] 
	FOREIGN KEY ([PromotionId]) REFERENCES [Promotions]([PromotionId]),
	CONSTRAINT [FK_CartPromotions_Products] 
	FOREIGN KEY ([ApplicableProductId]) REFERENCES [Products]([ProductId]))
