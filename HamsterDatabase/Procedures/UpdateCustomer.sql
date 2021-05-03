CREATE PROCEDURE [dbo].[UpdateCustomer]
	@id int = 0,
	@name varchar(50),
	@address varchar(50),
	@phone nchar(15)
AS
	UPDATE Customers
	SET CustomerName = @name, CustomerAddress = @address, PhoneNumber = @phone
	WHERE CustomerId = @id

RETURN 
