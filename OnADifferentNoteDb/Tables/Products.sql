CREATE TABLE [dbo].[Products]
(
	[ProductId] INT NOT NULL PRIMARY KEY IDENTITY,
	[ProductName] VARCHAR(30) NOT NULL,
	[ProductDescription] VARCHAR(MAX) NOT NULL,
	[ProductImageUrl] VARCHAR(MAX) NOT NULL,
	[ProductVideoUrl] VARCHAR(MAX),
	[Dimensions] VARCHAR(20),
	[Price] FLOAT NOT NULL,
	[QuantityInStock] INT NOT NULL,
	[UserRating] VARCHAR(10),
	[FeaturedProduct] BIT NOT NULL,
	[CategoryId] INT NOT NULL,
	CONSTRAINT [FK_Products_Categories] 
	FOREIGN KEY ([CategoryId]) REFERENCES [Categories]([CategoryId])
)