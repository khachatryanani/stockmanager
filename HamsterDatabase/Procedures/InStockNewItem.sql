CREATE PROCEDURE [dbo].[InStockNewItem]
	@productId int,
	@productionDate datetime2,
	@stockedDate datetime2,
	@producedQuantity int,
	@unitPrice decimal,
	@workerId int
AS
	INSERT INTO Stock (ProductId, ProductionDate, StockedDate, ProducedQuantity, UnitPrice, WorkerId)
	VALUES (@productId, @productionDate, @stockedDate, @producedQuantity, @unitPrice, @workerId)
RETURN 