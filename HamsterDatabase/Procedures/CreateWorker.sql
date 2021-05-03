CREATE PROCEDURE [dbo].[CreateWorker]
	@fName varchar(20),
	@lName varchar(20),
	@email varchar(60),
	@password int
AS
	INSERT INTO [Workers] (FirstName, LastName, Email, [Password])
	VALUES (@fName, @lName, @email, @password)
RETURN
	