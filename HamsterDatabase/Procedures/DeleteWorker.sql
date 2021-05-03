CREATE PROCEDURE [dbo].[DeleteWorker]
	@id int
AS
	DELETE FROM Workers
	WHERE WorkerId = @id
RETURN 
