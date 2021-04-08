CREATE TRIGGER [SetOrderItemsUnitPrices]
	ON [dbo].[OrderDetails]
	FOR INSERT
	AS
	BEGIN
		SET NOCOUNT ON

		UPDATE OrderDetails
		SET OrderDetails.UnitPrice = ActualPrice
		FROM inserted
			JOIN (SELECT Stock.ProductId, AVG(Stock.UnitPrice) as ActualPrice
					FROM Stock
					WHERE Stock.ActualQuantity > 0
					GROUP BY Stock.ProductId)as S on s.ProductId = inserted.ProductId
		WHERE inserted.ItemId = OrderDetails.ItemId
	END
