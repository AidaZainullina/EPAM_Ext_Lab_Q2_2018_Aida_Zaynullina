CREATE TABLE [dbo].[Users]
(
	[UserId] int IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [UserRoleID] SMALLINT NOT NULL, CONSTRAINT [FK_User_Role] FOREIGN KEY (UserRoleID) REFERENCES [Role](RoleId),
	[UserName] NCHAR(10) NULL, 
    [UserEmail] NCHAR(10) NULL, 
    [UserPassword] NCHAR(10) NULL
)
