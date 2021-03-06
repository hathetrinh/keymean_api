USE [master]
GO
/****** Object:  Database [englishcenter]    Script Date: 06/22/2018 00:27:46 ******/
ALTER DATABASE [englishcenter] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [englishcenter].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [englishcenter] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [englishcenter] SET ANSI_NULLS OFF
GO
ALTER DATABASE [englishcenter] SET ANSI_PADDING OFF
GO
ALTER DATABASE [englishcenter] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [englishcenter] SET ARITHABORT OFF
GO
ALTER DATABASE [englishcenter] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [englishcenter] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [englishcenter] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [englishcenter] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [englishcenter] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [englishcenter] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [englishcenter] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [englishcenter] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [englishcenter] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [englishcenter] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [englishcenter] SET  DISABLE_BROKER
GO
ALTER DATABASE [englishcenter] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [englishcenter] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [englishcenter] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [englishcenter] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [englishcenter] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [englishcenter] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [englishcenter] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [englishcenter] SET  READ_WRITE
GO
ALTER DATABASE [englishcenter] SET RECOVERY SIMPLE
GO
ALTER DATABASE [englishcenter] SET  MULTI_USER
GO
ALTER DATABASE [englishcenter] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [englishcenter] SET DB_CHAINING OFF
GO
USE [englishcenter]
GO
/****** Object:  Table [dbo].[Course]    Script Date: 06/22/2018 00:27:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Course](
	[id_course] [int] IDENTITY(1,1) NOT NULL,
	[name] [char](10) NULL,
	[description] [varchar](500) NULL,
	[number_of_student] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_course] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Course] ON
INSERT [dbo].[Course] ([id_course], [name], [description], [number_of_student]) VALUES (1, N'Course1   ', N'description 1', 50)
INSERT [dbo].[Course] ([id_course], [name], [description], [number_of_student]) VALUES (2, N'Course2   ', N'description 2', 40)
SET IDENTITY_INSERT [dbo].[Course] OFF
/****** Object:  Table [dbo].[Comment]    Script Date: 06/22/2018 00:27:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Comment](
	[id_comment] [int] IDENTITY(1,1) NOT NULL,
	[Content] [varchar](3000) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_comment] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[User]    Script Date: 06/22/2018 00:27:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[id_user] [int] IDENTITY(1,1) NOT NULL,
	[first_name] [varchar](50) NOT NULL,
	[last_name] [varchar](50) NOT NULL,
	[birthday] [varchar](20) NULL,
	[address] [varchar](200) NULL,
	[email] [char](100) NOT NULL,
	[code] [char](10) NULL,
	[pol] [char](10) NULL,
	[password] [nchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_user] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON
INSERT [dbo].[User] ([id_user], [first_name], [last_name], [birthday], [address], [email], [code], [pol], [password]) VALUES (1, N'first', N'last', N'12/12/1991', N'DN', N'a@b.c                                                                                               ', N'123456    ', N'123456    ', NULL)
INSERT [dbo].[User] ([id_user], [first_name], [last_name], [birthday], [address], [email], [code], [pol], [password]) VALUES (4, N'sasa', N'lassssst', N'21/2/1990', N'DN', N'2@sac.z                                                                                             ', N'2121      ', N'231       ', NULL)
INSERT [dbo].[User] ([id_user], [first_name], [last_name], [birthday], [address], [email], [code], [pol], [password]) VALUES (5, N'sa', N'32', N'33/23/222', N'2121e', N'ew@sa.x                                                                                             ', N'21        ', N'22        ', NULL)
INSERT [dbo].[User] ([id_user], [first_name], [last_name], [birthday], [address], [email], [code], [pol], [password]) VALUES (6, N'Thinh 123', N'Nguyen', N'', N'', N'nvthinh@nvthinh.nvthinh                                                                             ', N'          ', N'          ', NULL)
INSERT [dbo].[User] ([id_user], [first_name], [last_name], [birthday], [address], [email], [code], [pol], [password]) VALUES (21, N'sdaaa', N'sdfg', N'1/1/2017', N'a', N'a.@gmail.com                                                                                        ', N'a         ', N'a         ', NULL)
INSERT [dbo].[User] ([id_user], [first_name], [last_name], [birthday], [address], [email], [code], [pol], [password]) VALUES (22, N'a', N'a', N'1/1/2017', N'a', N'trinh@gmail.com                                                                                     ', N'a         ', N'a         ', NULL)
INSERT [dbo].[User] ([id_user], [first_name], [last_name], [birthday], [address], [email], [code], [pol], [password]) VALUES (24, N'first', N'last', N'12/12/1991', N'DN', N'a@b.c123                                                                                            ', NULL, NULL, N'c030437f6e8e94d244bc602606df5235                                                                    ')
SET IDENTITY_INSERT [dbo].[User] OFF
/****** Object:  Table [dbo].[Role]    Script Date: 06/22/2018 00:27:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Role](
	[id_role] [int] IDENTITY(1,1) NOT NULL,
	[name] [char](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_role] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Rating]    Script Date: 06/22/2018 00:27:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Rating](
	[id_rating] [int] IDENTITY(1,1) NOT NULL,
	[id_user] [int] NULL,
	[id_course] [int] NULL,
	[content] [varchar](500) NULL,
	[point] [char](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_rating] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Exercise]    Script Date: 06/22/2018 00:27:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Exercise](
	[id_exercise] [int] IDENTITY(1,1) NOT NULL,
	[title] [char](100) NULL,
	[content] [varchar](3000) NULL,
	[id_course] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_exercise] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Classes]    Script Date: 06/22/2018 00:27:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Classes](
	[id_class] [int] IDENTITY(1,1) NOT NULL,
	[name] [char](50) NULL,
	[size] [char](10) NULL,
	[location] [char](50) NULL,
	[id_course] [int] NULL,
	[start_date] [char](10) NULL,
	[end_date] [char](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_class] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Classes] ON
INSERT [dbo].[Classes] ([id_class], [name], [size], [location], [id_course], [start_date], [end_date]) VALUES (1, N'Class1                                            ', N'50        ', N'DN                                                ', 1, N'12/12/2000', N'12/12/3000')
INSERT [dbo].[Classes] ([id_class], [name], [size], [location], [id_course], [start_date], [end_date]) VALUES (2, N'Class2                                            ', N'50        ', N'DN                                                ', 1, N'12/12/2002', N'12/12/2002')
INSERT [dbo].[Classes] ([id_class], [name], [size], [location], [id_course], [start_date], [end_date]) VALUES (3, N'Class3                                            ', N'40        ', N'DNN                                               ', 2, N'12/12/2002', N'12/12/1212')
SET IDENTITY_INSERT [dbo].[Classes] OFF
/****** Object:  Table [dbo].[UserRole]    Script Date: 06/22/2018 00:27:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRole](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_role] [int] NULL,
	[id_user] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserOrder]    Script Date: 06/22/2018 00:27:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserOrder](
	[id_order] [int] IDENTITY(1,1) NOT NULL,
	[price] [char](10) NULL,
	[promotion_code] [char](10) NULL,
	[status] [char](10) NULL,
	[date_create] [char](10) NULL,
	[user_order] [char](100) NULL,
	[type] [char](10) NULL,
	[date_update] [char](10) NULL,
	[id_user] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_order] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserComment]    Script Date: 06/22/2018 00:27:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserComment](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_user] [int] NULL,
	[id_comment] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserClass]    Script Date: 06/22/2018 00:27:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserClass](
	[id_user_class] [int] IDENTITY(1,1) NOT NULL,
	[id_user] [int] NULL,
	[id_class] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_user_class] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_Rating_0]    Script Date: 06/22/2018 00:27:47 ******/
ALTER TABLE [dbo].[Rating]  WITH CHECK ADD  CONSTRAINT [FK_Rating_0] FOREIGN KEY([id_user])
REFERENCES [dbo].[User] ([id_user])
GO
ALTER TABLE [dbo].[Rating] CHECK CONSTRAINT [FK_Rating_0]
GO
/****** Object:  ForeignKey [FK_Rating_1]    Script Date: 06/22/2018 00:27:47 ******/
ALTER TABLE [dbo].[Rating]  WITH CHECK ADD  CONSTRAINT [FK_Rating_1] FOREIGN KEY([id_course])
REFERENCES [dbo].[Course] ([id_course])
GO
ALTER TABLE [dbo].[Rating] CHECK CONSTRAINT [FK_Rating_1]
GO
/****** Object:  ForeignKey [FK_Exercise_0]    Script Date: 06/22/2018 00:27:47 ******/
ALTER TABLE [dbo].[Exercise]  WITH CHECK ADD  CONSTRAINT [FK_Exercise_0] FOREIGN KEY([id_course])
REFERENCES [dbo].[Course] ([id_course])
GO
ALTER TABLE [dbo].[Exercise] CHECK CONSTRAINT [FK_Exercise_0]
GO
/****** Object:  ForeignKey [FK_Class_0]    Script Date: 06/22/2018 00:27:47 ******/
ALTER TABLE [dbo].[Classes]  WITH CHECK ADD  CONSTRAINT [FK_Class_0] FOREIGN KEY([id_course])
REFERENCES [dbo].[Course] ([id_course])
GO
ALTER TABLE [dbo].[Classes] CHECK CONSTRAINT [FK_Class_0]
GO
/****** Object:  ForeignKey [FK_UserRole_0]    Script Date: 06/22/2018 00:27:47 ******/
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_0] FOREIGN KEY([id_role])
REFERENCES [dbo].[User] ([id_user])
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_UserRole_0]
GO
/****** Object:  ForeignKey [FK_UserRole_1]    Script Date: 06/22/2018 00:27:47 ******/
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_1] FOREIGN KEY([id_user])
REFERENCES [dbo].[Role] ([id_role])
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_UserRole_1]
GO
/****** Object:  ForeignKey [FK_TOrder_0]    Script Date: 06/22/2018 00:27:47 ******/
ALTER TABLE [dbo].[UserOrder]  WITH CHECK ADD  CONSTRAINT [FK_TOrder_0] FOREIGN KEY([id_user])
REFERENCES [dbo].[User] ([id_user])
GO
ALTER TABLE [dbo].[UserOrder] CHECK CONSTRAINT [FK_TOrder_0]
GO
/****** Object:  ForeignKey [FK_UserComment_0]    Script Date: 06/22/2018 00:27:47 ******/
ALTER TABLE [dbo].[UserComment]  WITH CHECK ADD  CONSTRAINT [FK_UserComment_0] FOREIGN KEY([id_user])
REFERENCES [dbo].[User] ([id_user])
GO
ALTER TABLE [dbo].[UserComment] CHECK CONSTRAINT [FK_UserComment_0]
GO
/****** Object:  ForeignKey [FK_UserComment_1]    Script Date: 06/22/2018 00:27:47 ******/
ALTER TABLE [dbo].[UserComment]  WITH CHECK ADD  CONSTRAINT [FK_UserComment_1] FOREIGN KEY([id_comment])
REFERENCES [dbo].[Comment] ([id_comment])
GO
ALTER TABLE [dbo].[UserComment] CHECK CONSTRAINT [FK_UserComment_1]
GO
/****** Object:  ForeignKey [FK_UserClass_0]    Script Date: 06/22/2018 00:27:47 ******/
ALTER TABLE [dbo].[UserClass]  WITH CHECK ADD  CONSTRAINT [FK_UserClass_0] FOREIGN KEY([id_user])
REFERENCES [dbo].[User] ([id_user])
GO
ALTER TABLE [dbo].[UserClass] CHECK CONSTRAINT [FK_UserClass_0]
GO
/****** Object:  ForeignKey [FK_UserClass_1]    Script Date: 06/22/2018 00:27:47 ******/
ALTER TABLE [dbo].[UserClass]  WITH CHECK ADD  CONSTRAINT [FK_UserClass_1] FOREIGN KEY([id_class])
REFERENCES [dbo].[Classes] ([id_class])
GO
ALTER TABLE [dbo].[UserClass] CHECK CONSTRAINT [FK_UserClass_1]
GO
