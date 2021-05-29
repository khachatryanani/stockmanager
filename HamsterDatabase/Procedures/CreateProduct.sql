CREATE PROCEDURE [dbo].[CreateProduct]
	@productName VARCHAR(20),
	@productType INT,
	@productCategory CHAR(1),
	@measurementUnit INT
AS
	INSERT INTO Products(ProductName, ProductType, ProductCategory, MeasurementUnit)
	VALUES (@productName, @productType, @productCategory, @measurementUnit)
RETURN 0
