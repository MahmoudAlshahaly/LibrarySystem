USE [master]
GO
/****** Object:  Database [LibrarySystem]    Script Date: 2023-12-14 4:13:54 AM ******/
CREATE DATABASE [LibrarySystem]
 
GO
USE [LibrarySystem]
GO
/****** Object:  StoredProcedure [dbo].[BookByAuthorOrTitleOrISBN]    Script Date: 2023-12-14 4:13:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE PROC [dbo].[BookByAuthorOrTitleOrISBN] (@pattern nvarchar(50))
 AS
  SELECT 
  BookID ,
  BookISBN ,
  BookTitle ,
  BookDescription ,
  BookAuthor,
  BookStatus 
 from Books where  BookAuthor like  '%'+ @pattern +'%' or BookTitle like  '%'+ @pattern +'%' OR BookISBN like '%'+ @pattern +'%' 

GO
/****** Object:  StoredProcedure [dbo].[BookByID]    Script Date: 2023-12-14 4:13:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create PROC [dbo].[BookByID] (@BookID int)
 AS
 SELECT   
  BookID ,
  BookISBN ,
  BookTitle ,
  BookDescription ,
  BookAuthor,
  BookStatus from Books where BookID = @BookID

GO
/****** Object:  StoredProcedure [dbo].[BookDeleteAll]    Script Date: 2023-12-14 4:13:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create PROC [dbo].[BookDeleteAll]
 AS
 Delete from Books 

GO
/****** Object:  StoredProcedure [dbo].[BookDeleteByID]    Script Date: 2023-12-14 4:13:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create PROC [dbo].[BookDeleteByID] (@BookID int)
 AS
 Delete from Books where BookID=@BookID

GO
/****** Object:  StoredProcedure [dbo].[BookGetAll]    Script Date: 2023-12-14 4:13:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[BookGetAll]
AS

 SELECT   
  BookID ,
  BookISBN ,
  BookTitle ,
  BookDescription ,
  BookAuthor,
  BookStatus from Books
GO
/****** Object:  StoredProcedure [dbo].[BookInsert]    Script Date: 2023-12-14 4:13:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[BookInsert] 
 
 (@BookISBN nvarchar(50),
  @BookTitle nvarchar(50),
  @BookDescription nvarchar(150),
  @BookAuthor nvarchar(50),
  @BookStatus int )
 AS
 insert into Books
 
 (BookISBN ,
  BookTitle ,
  BookDescription ,
  BookAuthor,
  BookStatus )
  values 
  (
  @BookISBN ,
  @BookTitle ,
  @BookDescription ,
  @BookAuthor,
  @BookStatus  )

GO
/****** Object:  StoredProcedure [dbo].[BookUpdate]    Script Date: 2023-12-14 4:13:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE PROC [dbo].[BookUpdate] 
 
  (
  @BookID int,
  @BookISBN nvarchar(50),
  @BookTitle nvarchar(50),
  @BookDescription nvarchar(150),
  @BookAuthor nvarchar(50),
  @BookStatus int )

 AS
 update Books set 
   
   BookISBN=@BookISBN,
   BookTitle=@BookTitle,
   BookDescription=@BookDescription,
   BookAuthor=@BookAuthor,
   BookStatus=@BookStatus
   where BookID=@BookID 

GO
/****** Object:  StoredProcedure [dbo].[BookUpdateStatus]    Script Date: 2023-12-14 4:13:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[BookUpdateStatus] 
 
  (
  @BookID int,
  @BookStatus int )

 AS
 update Books set 
  
   BookStatus=@BookStatus
   where BookID=@BookID 

GO
/****** Object:  StoredProcedure [dbo].[BorrowBookGetAllForUser]    Script Date: 2023-12-14 4:13:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[BorrowBookGetAllForUser](@UserID int)
AS

 SELECT  
  BorrowID ,
  BorrowDate ,
  BorrowStatus ,
  BorrowBooks.BookID ,
  BookTitle, 
  UserID  from BorrowBooks,Books where BorrowBooks.BookID = Books.BookID and UserID=@UserID
GO
/****** Object:  StoredProcedure [dbo].[BorrowBookInsert]    Script Date: 2023-12-14 4:13:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[BorrowBookInsert] 
 
 (@BorrowDate datetime,
  @BorrowStatus int,
  @BookID int,
  @UserID int)
 AS
 insert into BorrowBooks
 
 (BorrowDate ,
  BorrowStatus ,
  BookID ,
  UserID )
  values 
  (
  @BorrowDate ,
  @BorrowStatus ,
  @BookID ,
  @UserID  )

GO
/****** Object:  StoredProcedure [dbo].[BorrowBookUpdateStatus]    Script Date: 2023-12-14 4:13:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[BorrowBookUpdateStatus] 
 
  (
  @BorrowID int,
  @BorrowStatus int )

 AS
 update BorrowBooks set 
  
   BorrowStatus=@BorrowStatus
   where BorrowID=@BorrowID

GO
/****** Object:  StoredProcedure [dbo].[UserByID]    Script Date: 2023-12-14 4:13:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create PROC [dbo].[UserByID] (@UserID int)
 AS
  SELECT 
   UserName ,
  UserPassword ,
  UserType  from Users where UserID = @UserID

GO
/****** Object:  StoredProcedure [dbo].[UserByNameAndPassword]    Script Date: 2023-12-14 4:13:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE PROC [dbo].[UserByNameAndPassword] (@UserName  nvarchar(50), @UserPassword nvarchar(50))
 AS
  SELECT 
  UserID,
  UserName ,
  UserPassword ,
  UserType  from Users where UserName = @UserName and UserPassword=@UserPassword

GO
/****** Object:  StoredProcedure [dbo].[UserDeleteByID]    Script Date: 2023-12-14 4:13:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create PROC [dbo].[UserDeleteByID] (@UserID int)
 AS
 Delete from Users where UserID=@UserID

GO
/****** Object:  StoredProcedure [dbo].[UserGetAll]    Script Date: 2023-12-14 4:13:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[UserGetAll]
AS

 SELECT   
  UserName ,
  UserPassword ,
  UserType  from Users
GO
/****** Object:  StoredProcedure [dbo].[UserInsert]    Script Date: 2023-12-14 4:13:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[UserInsert] 
 
 (@UserName nvarchar(50),
  @UserPassword nvarchar(50),
  @UserType int )
 AS
 insert into Users
 
 (UserName ,
  UserPassword ,
  UserType )
  values 
  (
  @UserName ,
  @UserPassword ,
  @UserType )

GO
/****** Object:  StoredProcedure [dbo].[UserUpdate]    Script Date: 2023-12-14 4:13:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE PROC [dbo].[UserUpdate] 
 
  (

  @UserID int,
  @UserName nvarchar(50),
  @UserPassword nvarchar(50),
  @UserType int )

 AS
 update Users set 
   
   UserName=@UserName,
   UserPassword=@UserPassword,
   UserType=@UserType
   where UserID=@UserID 



GO
/****** Object:  Table [dbo].[Books]    Script Date: 2023-12-14 4:13:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Books](
	[BookID] [int] IDENTITY(1,1) NOT NULL,
	[BookISBN] [nvarchar](50) NULL,
	[BookTitle] [nvarchar](50) NULL,
	[BookDescription] [nvarchar](150) NULL,
	[BookAuthor] [nvarchar](50) NULL,
	[BookStatus] [int] NULL,
 CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED 
(
	[BookID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BorrowBooks]    Script Date: 2023-12-14 4:13:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BorrowBooks](
	[BorrowID] [int] IDENTITY(1,1) NOT NULL,
	[BorrowDate] [datetime] NULL,
	[BorrowStatus] [int] NULL,
	[BookID] [int] NULL,
	[UserID] [int] NULL,
 CONSTRAINT [PK_BorrowBooks] PRIMARY KEY CLUSTERED 
(
	[BorrowID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 2023-12-14 4:13:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[UserPassword] [nvarchar](150) NULL,
	[UserType] [int] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Books] ON 

GO
INSERT [dbo].[Books] ([BookID], [BookISBN], [BookTitle], [BookDescription], [BookAuthor], [BookStatus]) VALUES (1, N'1234', N'C#', N'HHHHHH', N'Mahmoud', 0)
GO
INSERT [dbo].[Books] ([BookID], [BookISBN], [BookTitle], [BookDescription], [BookAuthor], [BookStatus]) VALUES (2, N'2345', N'JAVA', N'MNC JKFJLDS KFJSL', N'kHalid', 0)
GO
INSERT [dbo].[Books] ([BookID], [BookISBN], [BookTitle], [BookDescription], [BookAuthor], [BookStatus]) VALUES (3, N'4444', N'Java Script', N'hello world', N'Tamer Hosny', 0)
GO
INSERT [dbo].[Books] ([BookID], [BookISBN], [BookTitle], [BookDescription], [BookAuthor], [BookStatus]) VALUES (4, N'5555', N'kalila and demna', N'most good', N'mahmoud', 0)
GO
SET IDENTITY_INSERT [dbo].[Books] OFF
GO
SET IDENTITY_INSERT [dbo].[BorrowBooks] ON 

GO
INSERT [dbo].[BorrowBooks] ([BorrowID], [BorrowDate], [BorrowStatus], [BookID], [UserID]) VALUES (1, CAST(N'2023-12-14 02:39:31.800' AS DateTime), 0, 3, 2)
GO
INSERT [dbo].[BorrowBooks] ([BorrowID], [BorrowDate], [BorrowStatus], [BookID], [UserID]) VALUES (2, CAST(N'2023-12-14 03:05:48.527' AS DateTime), 1, 1, 2)
GO
INSERT [dbo].[BorrowBooks] ([BorrowID], [BorrowDate], [BorrowStatus], [BookID], [UserID]) VALUES (3, CAST(N'2023-12-14 03:05:51.883' AS DateTime), 1, 2, 2)
GO
INSERT [dbo].[BorrowBooks] ([BorrowID], [BorrowDate], [BorrowStatus], [BookID], [UserID]) VALUES (4, CAST(N'2023-12-14 03:08:01.990' AS DateTime), 1, 4, 1)
GO
INSERT [dbo].[BorrowBooks] ([BorrowID], [BorrowDate], [BorrowStatus], [BookID], [UserID]) VALUES (5, CAST(N'2023-12-14 03:08:02.640' AS DateTime), 1, 3, 1)
GO
SET IDENTITY_INSERT [dbo].[BorrowBooks] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

GO
INSERT [dbo].[Users] ([UserID], [UserName], [UserPassword], [UserType]) VALUES (1, N'mahmoud', N'MTIz', 1)
GO
INSERT [dbo].[Users] ([UserID], [UserName], [UserPassword], [UserType]) VALUES (2, N'ahmed', N'MTIz', 0)
GO
INSERT [dbo].[Users] ([UserID], [UserName], [UserPassword], [UserType]) VALUES (3, N'samer', N'MTIz', 0)
GO
INSERT [dbo].[Users] ([UserID], [UserName], [UserPassword], [UserType]) VALUES (4, N'ayman', N'MTIz', 0)
GO
INSERT [dbo].[Users] ([UserID], [UserName], [UserPassword], [UserType]) VALUES (5, N'yasser', N'MTIz', 0)
GO
INSERT [dbo].[Users] ([UserID], [UserName], [UserPassword], [UserType]) VALUES (6, N'yaraa', N'MTIz', 1)
GO
INSERT [dbo].[Users] ([UserID], [UserName], [UserPassword], [UserType]) VALUES (7, N'tammer', N'MTIz', 0)
GO
INSERT [dbo].[Users] ([UserID], [UserName], [UserPassword], [UserType]) VALUES (8, N'sarra', N'MTIz', 0)
GO
INSERT [dbo].[Users] ([UserID], [UserName], [UserPassword], [UserType]) VALUES (9, N'saaad', N'MTIz', 0)
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[BorrowBooks]  WITH CHECK ADD  CONSTRAINT [FK_BorrowBooks_Books] FOREIGN KEY([BookID])
REFERENCES [dbo].[Books] ([BookID])
GO
ALTER TABLE [dbo].[BorrowBooks] CHECK CONSTRAINT [FK_BorrowBooks_Books]
GO
ALTER TABLE [dbo].[BorrowBooks]  WITH CHECK ADD  CONSTRAINT [FK_BorrowBooks_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[BorrowBooks] CHECK CONSTRAINT [FK_BorrowBooks_Users]
GO
USE [master]
GO
ALTER DATABASE [LibrarySystem] SET  READ_WRITE 
GO
