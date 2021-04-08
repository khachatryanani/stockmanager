CREATE VIEW [dbo].[AvailableStockItems]
	AS 
	--Will use 12.12.20 as todays date, to be changed
	SELECT StockWithExpirationDates.StockId, StockWithExpirationDates.ProductId, StockWithExpirationDates.ActualQuantity, StockWithExpirationDates.StockedDate, StockWithExpirationDates.ExpirationDate
	FROM StockWithExpirationDates
	WHERE StockWithExpirationDates.ActualQuantity > 0 AND StockWithExpirationDates.ExpirationDate > '2020-12-12'
