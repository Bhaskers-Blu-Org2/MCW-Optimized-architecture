CREATE PROCEDURE [dbo].[InsertTransaction]
	@datetime DATETIME,
	@description NVARCHAR(255),
	@amount FLOAT
AS
	DECLARE @id UNIQUEIDENTIFIER = NEWID()

	DECLARE @balance FLOAT
	SET @balance = (SELECT TOP 1 [Balance] FROM [Transaction] ORDER BY [DateTime] DESC)

	IF (@balance IS NULL)
	BEGIN
		SET @balance = 0
	END

	SET @balance = @balance + @amount;


	INSERT [Transaction]
	(
		[Id],
		[DateTime],
		[Description],
		[Amount],
		[Balance]
	) VALUES (
		NEWID(),
		@datetime,
		@description,
		@amount,
		@balance
	)
