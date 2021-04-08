CREATE TABLE [dbo].[ExpiredStock]
(
	[ProductId] INT NOT NULL,
	[ReductionDate] DATETIME2 NOT NULL,
	ProductionDate DATETIME2 NOT NULL,
	StockedDate DATETIME2 NOT NULL,
	ExpiredDate DATETIME2 NOT NULL,
	[Quantity] INT NOT NULL,
	[UnitPrice] MONEY NOT NULL,
	[CreatedBy] INT NOT NULL,
	[ReducedBy] INT NOT NULL,
	CONSTRAINT PK_ExpiredStock PRIMARY KEY (ProductId, ReductionDate),
	CONSTRAINT FK_ExpiredStock FOREIGN KEY (ProductId) REFERENCES Products(ProductId),
	CONSTRAINT CH_ReducedQuantity CHECK (Quantity > 0)
)
