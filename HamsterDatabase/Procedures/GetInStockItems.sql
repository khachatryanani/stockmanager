CREATE PROCEDURE [dbo].[GetInStockItems]
AS
	--SELECT Products.ProductId, Products.ProductName, Products.ProductCategory, ProductTypes.ProductType,SUM(Stock.ActualQuantity) as Total, AVG(Stock.UnitPrice) as AveragePrice, MeaserementUnits.MeasurementUnit
	--FROM Stock
	--	JOIN Products ON Stock.ProductId = Products.ProductId
	--	JOIN MeaserementUnits ON Products.MeasurementUnit = MeaserementUnits.UnitId
	--	JOIN ProductTypes ON Products.ProductType = ProductTypes.TypeId
	--WHERE Stock.ActualQuantity > 0
	--GROUP BY Products.ProductId, Products.ProductName, Products.ProductCategory, ProductTypes.ProductType, MeaserementUnits.MeasurementUnit
	--ORDER BY  Products.ProductName

	--Will use 12.12.20 as todays date, to be changed
	SELECT StockWithExpirationDates.ProductId, StockWithExpirationDates.ProductName, StockWithExpirationDates.ProductType, SUM(StockWithExpirationDates.ActualQuantity) AS Total, AVG(StockWithExpirationDates.UnitPrice) AS AverageUnitPrice,  StockWithExpirationDates.MeasurementUnit
	FROM StockWithExpirationDates
	WHERE ExpirationDate > '2020-12-12' AND StockWithExpirationDates.ActualQuantity > 0
	GROUP BY StockWithExpirationDates.ProductId, StockWithExpirationDates.ProductName, StockWithExpirationDates.ProductType, StockWithExpirationDates.MeasurementUnit
RETURN
