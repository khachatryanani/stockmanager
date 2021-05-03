CREATE PROCEDURE [dbo].[GetStockItems]
	@stockedProductId int
AS
	--Will use 12.12.20 as todays date, to be changed
	SELECT StockId, ProductId, ProductName, ProductType, UnitPrice, MeasurementUnit, StockedDate, ProductionDate, ExpirationDate, ActualQuantity, CreatedBy, WorkerId
	FROM StockWithExpirationDates
	WHERE ExpirationDate > '2020-12-12' AND StockWithExpirationDates.ActualQuantity > 0 AND StockWithExpirationDates.ProductId = @stockedProductId
RETURN
