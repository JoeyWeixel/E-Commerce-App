CREATE TABLE [dbo].[Order]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [CartId] NCHAR(10) NOT NULL, 
    [CustomerId] NCHAR(10) NOT NULL, 
    [OrderDate] DATE NOT NULL
)
