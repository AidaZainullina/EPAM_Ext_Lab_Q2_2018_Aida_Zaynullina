CREATE TABLE [dbo].[UserTestLog]
(
	[UserId] INT NOT NULL foreign key references [User] (Id), 
    [TestId] INT NULL foreign key references [Test] ([Id]), 
    [Data] DATETIME NULL, 
    [ConsumedTime] DATETIME NULL, 
    [Score] INT NULL, 
    [Id] INT NOT NULL primary key
)
