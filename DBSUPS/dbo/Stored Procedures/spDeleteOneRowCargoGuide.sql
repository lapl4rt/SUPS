CREATE PROCEDURE spDeleteOneRowCargoGuide
	@CargoID int
AS
	DELETE FROM Cargo
	WHERE 
		Cargo_ID = @CargoID
RETURN 0