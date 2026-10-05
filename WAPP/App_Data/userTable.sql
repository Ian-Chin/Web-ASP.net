-- Schema for Database1.mdf
IF OBJECT_ID('dbo.[Table]', 'U') IS NOT NULL
    DROP TABLE dbo.[Table];
GO

IF OBJECT_ID('dbo.userTable', 'U') IS NULL
CREATE TABLE dbo.userTable
(
    Id       INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    fname    NVARCHAR(100) NULL,
    lname    NVARCHAR(100) NULL,
    gender   NVARCHAR(20)  NULL,
    country  NVARCHAR(100) NULL,
    email    NVARCHAR(100) NULL,
    username NVARCHAR(100) NOT NULL UNIQUE,
    password NVARCHAR(100) NOT NULL,
    usertype NVARCHAR(20)  NULL,
    photo    NVARCHAR(255) NULL
);
GO

-- Lab 9: profile picture path
IF COL_LENGTH('dbo.userTable', 'photo') IS NULL
    ALTER TABLE dbo.userTable ADD photo NVARCHAR(255) NULL;
GO
