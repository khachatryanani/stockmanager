CREATE PROCEDURE [dbo].[GetStocks]
AS

	--Will use 12.12.20 as todays date, to be changed
	SELECT StockWithExpirationDates.ProductId, StockWithExpirationDates.ProductName, StockWithExpirationDates.ProductType, SUM(StockWithExpirationDates.ActualQuantity) AS Total, AVG(StockWithExpirationDates.UnitPrice) AS AverageUnitPrice,  StockWithExpirationDates.MeasurementUnit
	FROM StockWithExpirationDates
	WHERE ExpirationDate > '2020-12-12' AND StockWithExpirationDates.ActualQuantity > 0
	GROUP BY StockWithExpirationDates.ProductId, StockWithExpirationDates.ProductName, StockWithExpirationDates.ProductType, StockWithExpirationDates.MeasurementUnit
RETURN
