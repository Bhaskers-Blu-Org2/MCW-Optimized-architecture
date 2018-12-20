
IF(NOT EXISTS(
SELECT 1
FROM sys.tables t
JOIN sys.schemas s ON t.schema_id = s.schema_id
WHERE s.name = 'dbo' AND t.name = 'Transaction'
))
	BEGIN
	CREATE TABLE [dbo].[Transaction]
	(
		[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
		[DateTime] DATETIME NOT NULL,
		[Description] NVARCHAR(255) NOT NULL,
		[Amount] FLOAT NOT NULL,
		[Balance] FLOAT NOT NULL
	)

	PRINT '[Transaction] Table Created'
END
ELSE
BEGIN
	PRINT '[Transaction] Table Already Exists'
END
GO


IF(EXISTS(
SELECT 1
FROM sys.procedures t
JOIN sys.schemas s ON t.schema_id = s.schema_id
WHERE s.name = 'dbo' AND t.name = 'InsertTransaction'
))
	BEGIN
		DROP PROCEDURE [dbo].[InsertTransaction]
	END
	GO

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
GO
PRINT '[InsertTransaction] Procedure Created'
GO


IF(EXISTS(
SELECT 1
FROM sys.procedures t
JOIN sys.schemas s ON t.schema_id = s.schema_id
WHERE s.name = 'dbo' AND t.name = 'GetBalance'
))
	BEGIN
		DROP PROCEDURE [dbo].[GetBalance]
	END
	GO

CREATE PROCEDURE [dbo].[GetBalance]
AS
	DECLARE @balance FLOAT
	SET @balance = (SELECT TOP 1 [Balance] FROM [Transaction] ORDER BY [DateTime] DESC)
	IF (@balance IS NULL)
	BEGIN
		SET @balance = 0;
	END
	SELECT @balance as [AvailableBalance]
GO
PRINT '[AvailableBalance] Procedure Created'
GO


-- Prepopulate with a starting Balance
DECLARE @dt DATETIME = GETUTCDATE()
EXEC	[dbo].[InsertTransaction]
		@datetime = @dt,
		@description = N'Opening Balance',
		@amount = 1250000
GO
