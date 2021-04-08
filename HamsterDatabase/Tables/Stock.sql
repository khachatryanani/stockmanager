CREATE TABLE [dbo].[Stock]
(
	StockId INT IDENTITY (101000,1),
	ProductId INT NOT NULL,
	ProductionDate DATETIME2 NOT NULL,
	ProducedQuantity INT NOT NULL,
	StockedDate DATETIME2 NOT NULL,
	ActualQuantity INT,
	UnitPrice MONEY NOT NULL,
	WorkerId INT NOT NULL,
	CONSTRAINT PK_ProductionId PRIMARY KEY (StockId),
	CONSTRAINT UK_ProductionId UNIQUE (ProductId, ProductionDate),
	CONSTRAINT FK_ProductId FOREIGN KEY (ProductId) REFERENCES Products(ProductId) ON UPDATE CASCADE,
	CONSTRAINT FK_WorkerId FOREIGN KEY (WorkerId) REFERENCES Workers(WorkerId),
	CONSTRAINT CH_Quantity CHECK (ProducedQuantity > 0),
	CONSTRAINT CH_UnitPrice CHECK (UnitPrice >= 100)

)