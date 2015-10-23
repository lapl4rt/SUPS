CREATE PROCEDURE spSelectOneRowCargoGuide
	@CargoID int

AS
BEGIN
	SELECT * FROM Cargo
	WHERE 
		Cargo_ID = @CargoID
END