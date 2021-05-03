CREATE PROCEDURE [dbo].[GetOrderItems]
	@orderId int
AS
	SELECT OrderDetails.ItemId, OrderDetails.OrderId, Products.ProductName, MeaserementUnits.MeasurementUnit, OrderDetails.Quantity, St.Price, OrderDetails.[Status]
	FROM OrderDetails
	JOIN Products ON OrderDetails.ProductId = Products.ProductId
	JOIN MeaserementUnits ON Products.MeasurementUnit = MeaserementUnits.UnitId
	JOIN (SELECT ProductId, AVG(UnitPrice) as Price FROM StockWithExpirationDates GROUP BY ProductId) AS St ON St.ProductId = OrderDetails.ProductId 
	WHERE OrderDetails.OrderId = @orderId
RETURN 0
