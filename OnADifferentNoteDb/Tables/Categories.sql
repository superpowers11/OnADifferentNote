CREATE TABLE [dbo].[Categories]
(
	[CategoryId] INT NOT NULL PRIMARY KEY IDENTITY,
	[CategoryName] VARCHAR(40) NOT NULL,
	[OrderIndex] INT NOT NULL
)
