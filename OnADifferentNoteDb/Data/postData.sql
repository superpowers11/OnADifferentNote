/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
/* Re-add values to Category table */
INSERT INTO [dbo].[Categories]
(CategoryId, CategoryName, OrderIndex)
VALUES (1, 'Electronic', 1),
(2, 'Vintage(i.e. Old)', 2),
(3, 'Gargantuan', 3),
(4, 'Unconventional Material', 4);

/*Re-add values to Product table*/
INSERT INTO [dbo].[Products]
( [ProductName], ProductDescription,
 ProductImageUrl, Dimensions, Price, QuantityInStock,
 FeaturedProduct, CategoryId)
 VALUES ('Picasso Guitar', 'Meld the stunning visual style of Picasso and the
 harmonious sound of guitar, with our Picasso Guitar - a one of a kind instrument.',
 '\Content\images\picasso_guitar.png', '2 ft. x 1.5 ft.', 254.99, 54, 1, 4);

 INSERT INTO Products (ProductName, ProductDescription,
ProductImageUrl, Dimensions, Price, QuantityInStock,
UserRating, FeaturedProduct, CategoryId)
VALUES ('Calliope', 'Old-fashioned carnivals may seem a thing of the past, but the music lives on!
Get a calliope today to embrace the nostalgia.', '\Content\images\calliope.png', '3 ft. x 5ft',
 49.99, 37, '8.9/10', 0, 2);

INSERT INTO Products (ProductName, ProductDescription,
ProductImageUrl, Dimensions, Price, QuantityInStock,
UserRating, FeaturedProduct, CategoryId)
VALUES ('Carrot Flute', 'Why not mix two of humanity''s favorite things - music and food? Get your
carrot flute today!', '\Content\images\carrot_flute.png', '9 in. x 1.5 in.',
 12.99, 17, '7.8/10', 0, 4);

 INSERT INTO Products (ProductName, ProductDescription,
ProductImageUrl, Dimensions, Price, QuantityInStock,
UserRating, FeaturedProduct, CategoryId)
VALUES ('Crwth', 'Get in tune with archaic Welsh culture by playing one of only 4 crwths suriving
today. Guaranteed that most of your hipster friends will not own one of these.', '\Content\images\crwth.png', '16 in. x 7 in.',
 64.99, 4, '9.5/10', 0, 2);
 
INSERT INTO Products (ProductName, ProductDescription,
ProductImageUrl, ProductVideoUrl, Dimensions, Price, QuantityInStock,
UserRating, FeaturedProduct, CategoryId)
VALUES ('Glass Armonica', 'Benjamin Franklin was a pretty popular guy, and so could you be, with an instrument like this. Invented by Ben Franklin himself in 1761, this musical instrument was named armonica after the Italian word armonia, for harmony.

The glass armonica makes harmonious use of friction, as a series of glass bowls spins against the fingers of the lucky musician that gets to play this instrument', '\Content\images\glass_armonica.png', 'http://www.youtube.com/embed/OYEJtQzHt7', '1'' x 5'' x 3.5''',
 154.99, 56, '9.4/10', 0, 2);
 
 
INSERT INTO Products (ProductName, ProductDescription,
ProductImageUrl, Dimensions, Price, QuantityInStock,
UserRating, FeaturedProduct, CategoryId)
VALUES ('Hurdy-Gurdy', 'Join the ranks of musicians in history who have used this crank fiddle, thought to originate in Europe or the Middle East.', '\Content\images\hurdy_gurdy.png', '16 in. x 5 in.',
 54.99, 49, '9.0/10', 0, 2);
 
 INSERT INTO Products (ProductName, ProductDescription,
ProductImageUrl, Dimensions, Price, QuantityInStock,
UserRating, FeaturedProduct, CategoryId)
VALUES ('Hydraulophone', 'As wind instruments use moving air to generate sound, so the hyrdraulophone uses moving water. Played like a in a manner similar to a common piano, this instrument is far from common.', '\Content\images\hydraulophone.png', '5'' x 1 '' x 2.4''',
 49.99, 49, '7.9/10', 0, 4);
 
 INSERT INTO Products (ProductName, ProductDescription,
ProductImageUrl, Dimensions, Price, QuantityInStock,
UserRating, FeaturedProduct, CategoryId)
VALUES ('Jew''s Harp', 'Enjoy this portable, classic, folksy music-maker.', '\Content\images\jews_harp.png', '5 in. x 2.5 in.',
 19.99, 108, '6.9/10', 0, 2);
 
 
 /* Insert 2 Promotions for different products */
INSERT INTO Promotions (PromoName, PromoDescription,PromoStart,
PromoEnd, PromoDateCreated, SalePrice, ZipCode, PromoType, ProductId)
VALUES ('Half-off Carrot Flutes', 'Get a carrot flute for only half the price!!', '2015-11-1', '2015-12-1',
GETDATE(), 6.49, 01984, 'Product', 4);
 
 
 INSERT INTO Promotions (PromoName, PromoDescription,PromoStart,
 PromoEnd, PromoDateCreated, SalePrice, ZipCode, PromoType, ProductId)
 VALUES ('Crwth Sale', 'Get a crwth for 20% off!', '2015-10-1', '2015-10-31',
 GETDATE(), 51.99, 01984, 'Product', 5);
 

