CREATE TABLE [dbo].[Products]
(
	ProductId INT NOT NULL IDENTITY (10,1),
	ProductName VARCHAR(20) NOT NULL,
	ProductType INT NOT NULL,
	ProductCategory CHAR(1) NOT NULL,
	MeasurementUnit INT NOT NULL,
	CONSTRAINT PK_ProductId PRIMARY KEY(ProductId),
	CONSTRAINT UQ_Product UNIQUE (ProductName, MeasurementUnit),
	CONSTRAINT FK_MeaserementUnit FOREIGN KEY (MeasurementUnit) REFERENCES MeaserementUnits(UnitId) ON UPDATE CASCADE,
	CONSTRAINT FK_ProductType FOREIGN KEY (ProductType) REFERENCES ProductTypes(TypeId) ON UPDATE CASCADE,
	CONSTRAINT CH_ProductCategory CHECK (ProductCategory in ('A', 'B', 'C'))
)
