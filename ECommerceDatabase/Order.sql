CREATE TABLE [dbo].[Order]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [CartId] INT NOT NULL, 
    [CustomerId] INT NOT NULL, 
    [OrderDate] DATE NOT NULL, 
    CONSTRAINT [FK_Order_Customer] FOREIGN KEY ([CustomerId]) REFERENCES [Customer]([Id]),
    CONSTRAINT [FK_Order_Cart] FOREIGN KEY ([CartId]) REFERENCES [Cart]([Id])
)
