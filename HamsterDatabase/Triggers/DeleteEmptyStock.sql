CREATE TRIGGER [DeleteEmptyStock]
	ON [dbo].[Stock]
	FOR INSERT, UPDATE
	AS
	BEGIN
		DELETE FROM Stock
		WHERE Stock.TotalQuantity = 0
	END
