CREATE TABLE [dbo].[ContactInfo]
(
	[CustomerId] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Email] NVARCHAR(50) NOT NULL, 
    [Address] NVARCHAR(MAX) NULL, 
    [PhoneNumber] NCHAR(10) NULL
)
