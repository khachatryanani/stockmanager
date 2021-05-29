CREATE PROCEDURE [dbo].[UpdateOrder]
	@orderId int,
	@customerid int,
	@receivedDate datetime2,
	@receiverId int,
	@deliveryDate datetime2 = null,
	@delivererId int = null,
	@status varchar(10)
AS
	UPDATE Orders
	SET CustomerId = @customerid, ReceivedDate = @receivedDate, ReceiverId = @receiverId, [Status] = @status, DeliveredDate = @deliveryDate, DelivererId = @delivererId
	WHERE OrderId = @orderId
RETURN 0
