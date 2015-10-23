CREATE PROCEDURE spSelectCargoByID(
		@Cargo_ID int
		)

AS
BEGIN
	SELECT
		Name,
		Description,
		ShortCode,
		Code,
		CodeGNG,
		Mnemocode,
		IsUsed,
		IsEmpty
		
	FROM Cargo
	WHERE 
		Cargo_ID = @Cargo_ID
END