CREATE PROCEDURE [dbo].[GetOrder]
@orderId int
AS
	SELECT Orders.OrderId, Orders.CustomerId, Customers.CustomerName, SUM(St.Price) as TotalPrice, Orders.ReceivedDate, W1.WorkerId as ReceiverId, W1.FirstName as ReceiverFirstName, W1.LastName as ReceiverLastName, Orders.[Status], Orders.DeliveredDate, W2.WorkerId as DelivererId, W2.FirstName as DelivererFirstName, W2.LastName as DelivererLastName
	FROM Orders
		JOIN Customers ON Orders.CustomerId = Customers.CustomerId
		JOIN Workers W1 ON W1.WorkerId = Orders.ReceiverId
		LEFT JOIN Workers W2 ON W2.WorkerId = Orders.DelivererId
		JOIN OrderDetails ON Orders.OrderId = OrderDetails.OrderId
		JOIN (SELECT ProductId, AVG(UnitPrice) as Price 
				FROM StockWithExpirationDates	
				GROUP BY ProductId) AS St ON St.ProductId = OrderDetails.ProductId
	WHERE Orders.OrderId = @orderId
	GROUP BY Orders.OrderId, Orders.CustomerId, Customers.CustomerName, Orders.TotalPrice, Orders.ReceivedDate, W1.WorkerId, W1.FirstName, W1.LastName , Orders.[Status], Orders.DeliveredDate, W2.WorkerId, W2.FirstName, W2.LastName
	
RETURN 0