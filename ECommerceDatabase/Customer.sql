CREATE TABLE [dbo].[Customer]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [CartId] INT NULL,
	CONSTRAINT [FK_Customer_Cart] FOREIGN KEY ([CartId]) REFERENCES [Cart]([Id])
)
