CREATE TABLE [dbo].[Product]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(MAX) NULL, 
    [Price] DECIMAL(18, 2) NOT NULL, 
    [NumInStock] INT NOT NULL
)
