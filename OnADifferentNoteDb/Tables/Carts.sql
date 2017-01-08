CREATE TABLE [dbo].[Carts]
(
	[CartId] INT NOT NULL PRIMARY KEY IDENTITY,
	[CartStatus] VARCHAR(15) NOT NULL,
	[CartDateCreated] DATE NOT NULL,
	[OwnerId] INT NOT NULL,
	[ZipCode] INT,
	CONSTRAINT [FK_Carts_Users] 
	FOREIGN KEY ([OwnerId]) REFERENCES [Users]([UserId])
)
