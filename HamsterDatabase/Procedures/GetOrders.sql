CREATE PROCEDURE [dbo].[GetOrders]

AS
	SELECT Orders.OrderId, Customers.CustomerName, Customers.CustomerAddress, SUM(St.Price) as TotalPrice, Orders.ReceivedDate, W1.FirstName + ' ' + W1.LastName as ReceivedBy, Orders.[Status], Orders.DeliveredDate, W2.FirstName + ' ' + W2.LastName as DeliveredBy
	FROM Orders
		JOIN Customers ON Orders.CustomerId = Customers.CustomerId
		JOIN Workers W1 ON W1.WorkerId = Orders.ReceiverId
		LEFT JOIN Workers W2 ON W2.WorkerId = Orders.DelivererId
		JOIN OrderDetails ON Orders.OrderId = OrderDetails.OrderId
		JOIN (SELECT ProductId, AVG(UnitPrice) as Price 
				FROM StockWithExpirationDates	
				GROUP BY ProductId) AS St ON St.ProductId = OrderDetails.ProductId
		GROUP BY Orders.OrderId, Customers.CustomerName, Customers.CustomerAddress, Orders.TotalPrice, Orders.ReceivedDate, W1.FirstName + ' ' + W1.LastName , Orders.[Status], Orders.DeliveredDate, W2.FirstName + ' ' + W2.LastName
	
RETURN 0