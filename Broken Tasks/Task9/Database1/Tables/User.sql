﻿CREATE TABLE [dbo].[Users]
(
	[UserId] int IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [UserRole] SMALLINT NOT NULL, CONSTRAINT [FK_M_USERS_M_USERROLE] FOREIGN KEY (UserRole) REFERENCES [Role](RoleId),
	[UserName] NCHAR(10) NULL, 
    [UserEmail] NCHAR(10) NULL, 
    [UserPassword] NCHAR(10) NULL
)
