CREATE PROCEDURE [dbo].[UpdateProduct]
	@productId INT,
	@productName VARCHAR(20),
	@productType INT,
	@measurementUnit INT
AS
	UPDATE Products
	SET ProductName= @productName, ProductType = @productType, MeasurementUnit = @measurementUnit
	WHERE ProductId = @productId
RETURN 0
