CREATE TABLE [dbo].[MeaserementUnits]
(
	[UnitId] INT IDENTITY (1,1) NOT NULL,
	MeasurementUnit VARCHAR(20) NOT NULL,
	CONSTRAINT PK_MeaserementUnit PRIMARY KEY ([UnitId])

)
