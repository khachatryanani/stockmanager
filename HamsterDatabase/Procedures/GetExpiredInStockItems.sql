CREATE PROCEDURE [dbo].[GetExpiredInStockItems]
	
AS
--Will use 12.12.20 as todays date, to be changed
	SELECT StockId, ProductId, ProductName, ProductType, UnitPrice, MeasurementUnit, StockedDate, ProductionDate, ExpirationDate, ActualQuantity, CreatedBy
	FROM StockWithExpirationDates
	WHERE ExpirationDate <= '2020-12-12'
RETURN 0
