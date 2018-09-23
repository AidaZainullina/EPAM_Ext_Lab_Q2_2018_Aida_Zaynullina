CREATE TABLE [dbo].[Questions]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [TestId] NCHAR(10) NULL, 
    [Text] NCHAR(10) NULL, 
    [Variants] INT NULL foreign key  References Variant ([Id])
)
