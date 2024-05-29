CREATE TABLE [dbo].[PaymentInfo]
(
	[PaymentId] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Email] NVARCHAR(50) NULL, 
    [Address] NVARCHAR(MAX) NOT NULL, 
    [PaymentMethod] NVARCHAR(50) NOT NULL, 
    [CustomerId] INT NOT NULL, 
    CONSTRAINT [FK_PaymentInfo_Customer] FOREIGN KEY ([CustomerId]) REFERENCES [Customer]([Id])
)