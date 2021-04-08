﻿CREATE TABLE [dbo].[Workers]
(
	WorkerId INT NOT NULL IDENTITY(100,1),
	FirstName VARCHAR(20) NOT NULL,
	LastName VARCHAR(30) NOT NULL,
	Email VARCHAR(60) NOT NULL,
	[Password] INT NOT NULL,
	CONSTRAINT PK_WorkerID PRIMARY KEY(WorkerId),
	CONSTRAINT UK_Email UNIQUE (Email)

)