CREATE TABLE [dbo].[Products]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NOT NULL,
	[Amount] INT NOT NULL, 
    [Price] DECIMAL NOT NULL,  
	[CategoryId] INT NOT NULL, 
    CONSTRAINT [FK_Products_ToCategories] FOREIGN KEY ([CategoryId]) REFERENCES [Categories]([Id])
)
