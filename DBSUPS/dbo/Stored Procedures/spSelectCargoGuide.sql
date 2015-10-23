CREATE PROCEDURE spSelectCargoGuide
AS
BEGIN
	SELECT TOP 10
		Cargo_ID,
		Name,
		Description,
		ShortCode,
		Code,
		CodeGNG,
		Mnemocode,
		IsUsed,
		IsEmpty
		
	FROM Cargo
END