CREATE PROCEDURE [dbo].[spSelectCargo]
(
	@startIndex int = null,
	@pageSize int = null
)

AS
BEGIN

	SET NOCOUNT ON;

	IF @startIndex < 1 SET @startIndex = 1
	IF @pageSize < 1 SET @pageSize = 1

	Select
		cargo.Cargo_ID,
		cargo.Image,
		cargo.Name,
		cargo.Description,
		cargo.ShortCode,
		cargo.Code,
		cargo.CodeGNG,
		cargo.Mnemocode,
		cargo.IsUsed,
		cargo.IsEmpty
		
	From (
		Select *, ROW_NUMBER() OVER(ORDER BY Cargo_ID) AS rowNumber
	    From Cargo
	) AS cargo
	Where rowNumber > @startIndex AND rowNumber <= (@startIndex + @pageSize)
	ORDER BY cargo.Cargo_ID DESC
END
