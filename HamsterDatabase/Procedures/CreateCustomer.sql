CREATE PROCEDURE [dbo].[CreateCustomer]
	@name varchar(50),
	@address varchar(50),
	@phone nchar(15)
AS
	INSERT INTO [Customers] (CustomerName, CustomerAddress, PhoneNumber)
	VALUES(@name, @address, @phone)

RETURN 