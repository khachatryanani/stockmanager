
CREATE TYPE ProductList AS TABLE
(
	ProductId int,
	Quantity int
)
GO

CREATE PROCEDURE [dbo].[CreateNewOrder]
	@customerId int,
	@recievedDate datetime2,
	@receiverId int,
	@productList ProductList READONLY
AS
	DECLARE @orderId int
	INSERT INTO Orders (CustomerId, ReceivedDate, ReceiverId)
	VALUES (@customerId, @recievedDate, @receiverId)

	SET @orderId = @@IDENTITY

	
	INSERT INTO OrderDetails (OrderId, ProductId, Quantity)
	SELECT @orderId, ProductId, Quantity
	FROM @productList

RETURN
