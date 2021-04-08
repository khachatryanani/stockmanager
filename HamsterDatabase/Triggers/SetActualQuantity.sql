CREATE TRIGGER [SetActualQuantity]
	ON [dbo].[Stock]
	FOR INSERT
	AS
	BEGIN
		SET NOCOUNT ON
		UPDATE Stock
		SET Stock.ActualQuantity = inserted.ProducedQuantity
		FROM inserted
		WHERE Stock.StockId = inserted.StockId
	END

