CREATE PROCEDURE [dbo].[GetWorker]
	@id int
AS
	SELECT *
	FROM Workers
	WHERE WorkerId = @id
RETURN 0
