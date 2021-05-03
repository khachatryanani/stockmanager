CREATE PROCEDURE [dbo].[GetCustomer]
	@id int
AS
	SELECT *
	FROM Customers
	WHERE CustomerId = @id
RETURN 
