CREATE TABLE [dbo].[Customers]
(
	CustomerId INT IDENTITY (1000,1) NOT NULL,
	CustomerName VARCHAR(50) NOT NULL,
	CustomerAddress VARCHAR(50) NOT NULL,
	PhoneNumber NCHAR(15),
	CONSTRAINT PK_CustomerID PRIMARY KEY (CustomerId),
	CONSTRAINT UQ_CustomerAddress UNIQUE (CustomerAddress)
)
