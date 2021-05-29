CREATE PROCEDURE [dbo].[UpdateOrderItem]
	@itemId int,
	@productId int,
	@quantity int,
	@status varchar(10)

AS
	DECLARE @currentStatus varchar(10) = (SELECT [Status] FROM OrderDetails WHERE ItemId = @itemId)
	IF @status = 'Accepted' AND @currentStatus = 'Pending' 
		EXEC AcceptOrderItem @itemID

	UPDATE OrderDetails
	SET ProductId = @productId, Quantity = @quantity, [Status] = @status
	WHERE ItemId = @itemId
RETURN 0
