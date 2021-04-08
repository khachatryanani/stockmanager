CREATE PROC [dbo].[AcceptOrderItems]
	@itemId int
AS
BEGIN
	DECLARE @productId int = (SELECT OrderDetails.ProductId FROM OrderDetails WHERE OrderDetails.ItemId = @itemId )
	DECLARE @quantity int = (SELECT OrderDetails.Quantity FROM OrderDetails WHERE OrderDetails.ItemId = @itemId )
	IF (@quantity < = (SELECT SUM(AvailableStockItems.ActualQuantity) FROM AvailableStockItems WHERE AvailableStockItems.ProductId = @productId GROUP BY AvailableStockItems.ProductId ))
	BEGIN
		DECLARE @actualQuantityFI int
		DECLARE @stockId int
		WHILE (@quantity > 0)
		BEGIN
			SET @actualQuantityFI  = (SELECT TOP(1) AvailableStockItems.ActualQuantity FROM AvailableStockItems WHERE AvailableStockItems.ProductId = @productId ORDER BY AvailableStockItems.StockedDate )
			SET @stockId = (SELECT TOP(1) AvailableStockItems.StockId FROM AvailableStockItems WHERE AvailableStockItems.ProductId = @productId ORDER BY AvailableStockItems.StockedDate )
			IF(@quantity > @actualQuantityFI)
			BEGIN
				SET @quantity = @quantity - @actualQuantityFI

				UPDATE Stock
				SET Stock.ActualQuantity = 0
				WHERE Stock.StockId = @stockId
			END
			ELSE
			BEGIN
				UPDATE Stock
				SET Stock.ActualQuantity = Stock.ActualQuantity - @quantity 
				WHERE Stock.StockId = @stockId

				SET @quantity = 0
			END
		END

		UPDATE OrderDetails
		SET OrderDetails.[Status] = 'Accepted'
		WHERE OrderDetails.ItemId = @itemId
	END
END
