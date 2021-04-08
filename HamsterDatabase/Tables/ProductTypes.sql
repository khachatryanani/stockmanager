CREATE TABLE [dbo].[ProductTypes]
(
	[TypeId] INT IDENTITY (1,1),
	ProductType VARCHAR (20) NOT NULL,
	CONSTRAINT PK_ProductType PRIMARY KEY ([TypeId])

)
