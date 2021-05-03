CREATE PROCEDURE [dbo].[GetStock]
	@stockedProductId int
AS
	SELECT StockWithExpirationDates.ProductId, StockWithExpirationDates.ProductName, StockWithExpirationDates.ProductType, SUM(StockWithExpirationDates.ActualQuantity) AS Total, AVG(StockWithExpirationDates.UnitPrice) AS AverageUnitPrice,  StockWithExpirationDates.MeasurementUnit
	FROM StockWithExpirationDates
	WHERE ExpirationDate > '2020-12-12' AND StockWithExpirationDates.ActualQuantity > 0 AND StockWithExpirationDates.ProductId = @stockedProductId
	GROUP BY StockWithExpirationDates.ProductId, StockWithExpirationDates.ProductName, StockWithExpirationDates.ProductType, StockWithExpirationDates.MeasurementUnit
RETURN

