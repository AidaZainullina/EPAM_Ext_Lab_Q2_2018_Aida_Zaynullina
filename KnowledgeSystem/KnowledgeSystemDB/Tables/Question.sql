CREATE TABLE [dbo].[Question]
(
	[Id] INT NOT NULL IDENTITY(1, 1) PRIMARY KEY, 
    [TestId] INT NOT NULL foreign key (TestId) references Test (Id), 
    [Text] NCHAR(1000) NULL
)
