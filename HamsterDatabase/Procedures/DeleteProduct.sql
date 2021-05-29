CREATE PROCEDURE [dbo].[DeleteProduct]
	@id int
AS
	DELETE FROM Products
	WHERE ProductId = @id
RETURN 

