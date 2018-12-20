CREATE PROCEDURE [dbo].[GetBalance]
AS
	DECLARE @balance FLOAT
	SET @balance = (SELECT TOP 1 [Balance] FROM [Transaction] ORDER BY [DateTime] DESC)
	IF (@balance IS NULL)
	BEGIN
		SET @balance = 0;
	END
	SELECT @balance as [AvailableBalance]
