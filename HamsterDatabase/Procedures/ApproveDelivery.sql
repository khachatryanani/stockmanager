
CREATE PROCEDURE [dbo].[ApproveDelivery]
@orderId int,
@deliveryDate DATETIME2,
@delivererId int
AS
	UPDATE Orders
	SET Orders.DeliveredDate = @deliveryDate
	WHERE Orders.OrderId = @orderId

	UPDATE Orders
	SET Orders.DelivererId = @delivererId
	WHERE Orders.OrderId = @orderId

	UPDATE Orders
	SET Orders.Status = 'Delivered'
	WHERE Orders.OrderId = @orderId

	Update OrderDetails
	SET OrderDetails.Status = 'Delivered'
	WHERE OrderDetails.OrderId = @orderId

RETURN 0
