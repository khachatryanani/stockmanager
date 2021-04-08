CREATE TYPE ExpiredProductList AS TABLE
(
	Id int,
	ReductionDate datetime2,
	ReducedBy int
)
GO

CREATE PROCEDURE [dbo].[ReduceExpiredItems]
	@expiredProdList ExpiredProductList READONLY
AS
	INSERT INTO ExpiredStock
	SELECT StockWithExpirationDates.ProductId, ReductionDate, StockWithExpirationDates.ProductionDate, StockWithExpirationDates.StockedDate,StockWithExpirationDates.ExpirationDate, StockWithExpirationDates.ActualQuantity, StockWithExpirationDates.UnitPrice, StockWithExpirationDates.CreatedBy, ReducedBy
	FROM StockWithExpirationDates 
		JOIN @expiredProdList ON StockWithExpirationDates.StockId = Id

	DELETE FROM Stock
	WHERE Stock.StockId IN (SELECT StockId
							FROM @expiredProdList)
RETURN 0
