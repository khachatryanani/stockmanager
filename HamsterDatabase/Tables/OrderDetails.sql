CREATE TABLE [dbo].[OrderDetails]
(
	ItemId INT IDENTITY (101000,1),
	OrderId INT NOT NULL,
	ProductId INT NOT NULL,
	Quantity INT NOT NULL,
	UnitPrice MONEY,
	[Status] VARCHAR(10) CONSTRAINT D_Status DEFAULT 'Pending',
	CONSTRAINT PK_OrderItem PRIMARY KEY (ItemId),
	CONSTRAINT UK_OrderDetail UNIQUE (OrderId, ProductId),
	CONSTRAINT FK_OOrderId FOREIGN KEY(OrderId) REFERENCES Orders(OrderId) ON DELETE CASCADE,
	CONSTRAINT FK_OProductId FOREIGN KEY(ProductId) REFERENCES Products(ProductId),
	CONSTRAINT CHD_Status CHECK ([Status] in ('Accepted', 'Pending', 'Delivered', 'Declined'))
)
