CREATE TABLE [dbo].[UserTestLog]
(
	[UserId] INT NOT NULL,
		constraint [FK_LogId_User] foreign key ([UserId]) references [User] ([Id]), 
    [TestId] INT NULL,
		constraint [FK_LogTest_Test] foreign key ([TestId]) references [Test] ([Id]), 
    [Data] DATETIME NULL, 
    [ConsumedTime] DATETIME NULL, 
    [Score] INT NULL, 
    [Id] INT NOT NULL primary key
)
