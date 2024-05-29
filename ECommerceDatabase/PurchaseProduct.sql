CREATE TABLE [dbo].[PurchaseProduct]
(
	[ProductId] INT NOT NULL , 
    [CartId] INT NOT NULL, 
    [Quantity] INT NOT NULL, 
    PRIMARY KEY ([ProductId], [CartId]),
    Foreign Key ([ProductId]) references [Product]([Id]),
    Foreign key ([CartId]) references [Cart]([Id])
)
