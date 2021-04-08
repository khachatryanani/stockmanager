CREATE VIEW [dbo].[StockWithExpirationDates]
	AS SELECT Stock.StockId, Stock.ProductId, Products.ProductName, ProductTypes.ProductType, Stock.UnitPrice, MeaserementUnits.MeasurementUnit, Stock.StockedDate, Stock.ProductionDate, ExpirationDate =  case Products.ProductCategory
																																					when 'A' then DATEADD(DAY,7,StockedDate)
																																					when 'B' then DATEADD(DAY,14,StockedDate)
																																					else DATEADD(DAY,21,StockedDate)
																																					end, Stock.ActualQuantity, Workers.FirstName + ' ' + Workers.LastName as [CreatedBy], Workers.WorkerId
	FROM Stock
		JOIN Products ON Stock.ProductId = Products.ProductId
		JOIN MeaserementUnits ON Products.MeasurementUnit = MeaserementUnits.UnitId
		JOIN ProductTypes ON Products.ProductType = ProductTypes.TypeId
		JOIN Workers ON Stock.WorkerId = Workers.WorkerId
	WHERE Stock.ActualQuantity > 0
