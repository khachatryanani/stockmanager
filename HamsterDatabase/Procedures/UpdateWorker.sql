CREATE PROCEDURE [dbo].[UpdateWorker]
	@id int,
	@fName varchar(20),
	@lName varchar(20),
	@email varchar(60),
	@password int
AS
	UPDATE Workers
	SET FirstName = @fName, LastName = @lName, Email = @email, [Password]= @password
	WHERE WorkerId = @id
RETURN 
