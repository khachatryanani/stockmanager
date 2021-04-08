CREATE PROCEDURE [dbo].[GetOrdersOfCustomer]
	@customerId int
AS
	SELECT Orders.OrderId, Orders.TotalPrice, Orders.ReceivedDate,  W1.FirstName + ' ' + W1.LastName as [Acceptor Name], Orders.[Status],Orders.DeliveredDate, W2.FirstName + ' ' + W2.LastName as [Deliverer Name] 
	FROM Orders
		JOIN Customers ON Orders.CustomerId = Customers.CustomerId
		JOIN Workers as W1 ON W1.WorkerId = Orders.ReceiverId
		LEFT JOIN Workers as W2 ON W2.WorkerId = Orders.DelivererId
	WHERE Orders.CustomerId = @customerId
RETURN