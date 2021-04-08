CREATE PROCEDURE [dbo].[GetProducts]
	
AS
	SELECT Products.ProductId, Products.ProductName, Products.ProductCategory, ProductTypes.ProductType, MeaserementUnits.MeasurementUnit 
	FROM Products
		JOIN MeaserementUnits ON Products.MeasurementUnit = MeaserementUnits.UnitId
		JOIN ProductTypes ON ProductTypes.TypeId = Products.ProductType
RETURN 0
