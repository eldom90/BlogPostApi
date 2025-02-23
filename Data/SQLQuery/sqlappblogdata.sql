USE [master]
GO
/****** Object:  Database [BlogPostDB]    Script Date: 10. 6. 2020. 19:32:30 ******/
CREATE DATABASE [BlogPostDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BlogPostDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\BlogPostDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BlogPostDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\BlogPostDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [BlogPostDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BlogPostDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BlogPostDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BlogPostDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BlogPostDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BlogPostDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BlogPostDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [BlogPostDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BlogPostDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BlogPostDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BlogPostDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BlogPostDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BlogPostDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BlogPostDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BlogPostDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BlogPostDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BlogPostDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BlogPostDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BlogPostDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BlogPostDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BlogPostDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BlogPostDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BlogPostDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BlogPostDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BlogPostDB] SET RECOVERY FULL 
GO
ALTER DATABASE [BlogPostDB] SET  MULTI_USER 
GO
ALTER DATABASE [BlogPostDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BlogPostDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BlogPostDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BlogPostDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BlogPostDB] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'BlogPostDB', N'ON'
GO
ALTER DATABASE [BlogPostDB] SET QUERY_STORE = OFF
GO
USE [BlogPostDB]
GO
/****** Object:  Table [dbo].[Post]    Script Date: 10. 6. 2020. 19:32:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Post](
	[postId] [int] IDENTITY(1,1) NOT NULL,
	[slug] [nvarchar](max) NULL,
	[title] [nvarchar](250) NULL,
	[description] [nvarchar](max) NULL,
	[body] [nvarchar](max) NULL,
	[createdAt] [datetime] NULL,
	[updatedAt] [datetime] NULL,
 CONSTRAINT [PK_Post] PRIMARY KEY CLUSTERED 
(
	[postId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tag]    Script Date: 10. 6. 2020. 19:32:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tag](
	[tagId] [int] IDENTITY(1,1) NOT NULL,
	[tagName] [nvarchar](250) NULL,
	[postId] [nvarchar](250) NULL,
 CONSTRAINT [PK_Tag] PRIMARY KEY CLUSTERED 
(
	[tagId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Post] ON 

INSERT [dbo].[Post] ([postId], [slug], [title], [description], [body], [createdAt], [updatedAt]) VALUES (1, N'post-1', N'title-1', N'description-1', N'body-1', CAST(N'2020-09-06T00:00:00.000' AS DateTime), CAST(N'2020-09-06T00:00:00.000' AS DateTime))
INSERT [dbo].[Post] ([postId], [slug], [title], [description], [body], [createdAt], [updatedAt]) VALUES (5, N'post-2', N'post-2', N'Ever wonder how?', N'An opinionated commentary, of the most important presentation of the year', CAST(N'2020-09-06T00:00:00.000' AS DateTime), CAST(N'2020-06-10T19:09:59.960' AS DateTime))
INSERT [dbo].[Post] ([postId], [slug], [title], [description], [body], [createdAt], [updatedAt]) VALUES (8, N'internet-trends-2018', N'Internet Trends 2018', N'Ever wonder how?', N'An opinionated commentary, of the most important presentation of the year', CAST(N'2020-06-10T19:00:11.110' AS DateTime), CAST(N'2020-06-10T19:00:11.113' AS DateTime))
INSERT [dbo].[Post] ([postId], [slug], [title], [description], [body], [createdAt], [updatedAt]) VALUES (9, N'internet-trends-2018-1', N'Internet Trends 2018', N'Ever wonder how?', N'An opinionated commentary, of the most important presentation of the year', CAST(N'2020-06-10T19:01:06.150' AS DateTime), CAST(N'2020-06-10T19:01:06.150' AS DateTime))
SET IDENTITY_INSERT [dbo].[Post] OFF
GO
SET IDENTITY_INSERT [dbo].[Tag] ON 

INSERT [dbo].[Tag] ([tagId], [tagName], [postId]) VALUES (1, N'IOS', N'post-1')
INSERT [dbo].[Tag] ([tagId], [tagName], [postId]) VALUES (2, N'Android', N'post-1')
INSERT [dbo].[Tag] ([tagId], [tagName], [postId]) VALUES (41, N'AndroidJS', N'post-2')
INSERT [dbo].[Tag] ([tagId], [tagName], [postId]) VALUES (42, N'trends', N'internet-trends-2018-1')
INSERT [dbo].[Tag] ([tagId], [tagName], [postId]) VALUES (43, N'innovation', N'internet-trends-2018-1')
INSERT [dbo].[Tag] ([tagId], [tagName], [postId]) VALUES (44, N'2018', N'internet-trends-2018-1')
SET IDENTITY_INSERT [dbo].[Tag] OFF
GO
USE [master]
GO
ALTER DATABASE [BlogPostDB] SET  READ_WRITE 
GO
