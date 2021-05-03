CREATE PROCEDURE [dbo].[GetCustomerOrders]
	@customerId int
AS
	SELECT Orders.OrderId, Orders.CustomerId, Customers.CustomerName, SUM(St.Price) as TotalPrice, Orders.ReceivedDate, W1.FirstName + ' ' + W1.LastName as ReceivedBy, W1.WorkerId as ReceivedById, Orders.[Status], Orders.DeliveredDate, W2.FirstName + ' ' + W2.LastName as DeliveredBy, W2.WorkerId as DeliveredById
	FROM Orders
		JOIN Customers ON Orders.CustomerId = Customers.CustomerId
		JOIN Workers W1 ON W1.WorkerId = Orders.ReceiverId
		LEFT JOIN Workers W2 ON W2.WorkerId = Orders.DelivererId
		JOIN OrderDetails ON Orders.OrderId = OrderDetails.OrderId
		JOIN (SELECT ProductId, AVG(UnitPrice) as Price 
				FROM StockWithExpirationDates	
				GROUP BY ProductId) AS St ON St.ProductId = OrderDetails.ProductId
	WHERE Orders.CustomerId = @customerId
	GROUP BY Orders.OrderId,  Orders.CustomerId, Customers.CustomerName,Orders.TotalPrice, Orders.ReceivedDate, W1.FirstName + ' ' + W1.LastName ,  W1.WorkerId, Orders.[Status], Orders.DeliveredDate, W2.FirstName + ' ' + W2.LastName, W2.WorkerId
RETURN