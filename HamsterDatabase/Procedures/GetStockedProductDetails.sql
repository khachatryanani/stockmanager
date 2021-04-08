CREATE PROCEDURE [dbo].[GetStockedProductDetails]
	@productId int
AS
	--SELECT Stock.ProductId, Products.ProductName, ProductTypes.ProductType, Stock.UnitPrice, MeaserementUnits.MeasurementUnit, Stock.StockedDate, Stock.ProductionDate, ExpirationDate =  case Products.ProductCategory
	--																																				when 'A' then DATEADD(DAY,7,StockedDate)
	--																																				when 'B' then DATEADD(DAY,14,StockedDate)
	--																																				else DATEADD(DAY,21,StockedDate)
	--																																				end, Stock.ActualQuantity, Workers.FirstName + ' ' + Workers.LastName as [CreatedBy]
	--FROM Stock
	--	JOIN Products ON Stock.ProductId = Products.ProductId
	--	JOIN MeaserementUnits ON Products.MeasurementUnit = MeaserementUnits.UnitId
	--	JOIN ProductTypes ON Products.ProductType = ProductTypes.TypeId
	--	JOIN Workers ON Stock.WorkerId = Workers.WorkerId
	--WHERE Stock.ActualQuantity > 0 AND Stock.ProductId = @productId

	--Will use 12.12.20 as todays date, to be changed
	SELECT StockId, ProductId, ProductName, ProductType, UnitPrice, MeasurementUnit, StockedDate, ProductionDate, ExpirationDate, ActualQuantity, CreatedBy, WorkerId
	FROM StockWithExpirationDates
	WHERE ExpirationDate > '2020-12-12' AND StockWithExpirationDates.ActualQuantity > 0 AND StockWithExpirationDates.ProductId = @productId
RETURN
