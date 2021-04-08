CREATE VIEW [dbo].[PendingOrderItems]
	AS SELECT OrderDetails.ItemId, OrderDetails.OrderId, OrderDetails.ProductId
		FROM OrderDetails
		WHERE OrderDetails.[Status] LIKE 'Pending'