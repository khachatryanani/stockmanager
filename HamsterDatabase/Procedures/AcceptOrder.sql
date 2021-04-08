CREATE PROCEDURE [dbo].[AcceptOrder]
	@orderId int
AS
	
	BEGIN
		DECLARE @itemId INT = 0

		WHILE (1 = 1) 
		BEGIN  

			SELECT TOP(1) @itemId = ItemId
			FROM PendingOrderItems
			WHERE ItemId > @itemId AND PendingOrderItems.OrderId = @orderId
			ORDER BY PendingOrderItems.ItemId

			 IF @@ROWCOUNT = 0 BREAK;

			 EXEC dbo.AcceptOrderItems @itemId

		END

	DECLARE @rowCount int = (SELECT COUNT(*) FROM PendingOrderItems WHERE PendingOrderItems.OrderId = @orderId )

	IF(@rowCount = 0)
	BEGIN
		UPDATE Orders
		SET Orders.[Status] = 'Accepted'
		WHERE Orders.OrderId = @orderId
		RETURN 0
	END
	END
RETURN 1
