CREATE TABLE [dbo].[Orders]
(
	OrderId INT IDENTITY (2101000, 1),
	CustomerId INT NOT NULL,
	TotalPrice MONEY,
	ReceivedDate DATETIME2 NOT NULL,
	ReceiverId INT NOT NULL,
	[Status] VARCHAR(10) CONSTRAINT O_Status DEFAULT 'Pending',
	DeliveredDate DATETIME2,
	DelivererId INT,
	CONSTRAINT PK_OrderId PRIMARY KEY(OrderId),
	CONSTRAINT FK_CustomerId FOREIGN KEY (CustomerId) REFERENCES Customers(CustomerId),
	CONSTRAINT FK_OAcceptorId FOREIGN KEY (ReceiverId) REFERENCES Workers(WorkerId),
	CONSTRAINT FK_ODelivererId FOREIGN KEY (DelivererId) REFERENCES Workers(WorkerId),
	CONSTRAINT CHO_Status CHECK ([Status] in ('Accepted', 'Pending', 'Declined', 'Delivered'))

)
