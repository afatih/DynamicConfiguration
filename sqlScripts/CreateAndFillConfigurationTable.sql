CREATE DATABASE Beymen
GO

USE [Beymen]
GO
/****** Object:  Table [dbo].[Configurations]    Script Date: 15.07.2021 11:28:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Configurations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Type] [nvarchar](50) NULL,
	[Value] [nvarchar](500) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[ApplicationName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Configurations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Configurations] ON 

INSERT [dbo].[Configurations] ([Id], [Name], [Type], [Value], [IsActive], [ApplicationName]) VALUES (1, N'SiteName', N'String', N'Boyner.com.tr', 1, N'SERVICE-A')
INSERT [dbo].[Configurations] ([Id], [Name], [Type], [Value], [IsActive], [ApplicationName]) VALUES (2, N'IsBasketEnabled', N'Boolean', N'true', 1, N'SERVICE-B')
INSERT [dbo].[Configurations] ([Id], [Name], [Type], [Value], [IsActive], [ApplicationName]) VALUES (3, N'MaxItemCount', N'Int32', N'50', 1, N'SERVICE-A')
SET IDENTITY_INSERT [dbo].[Configurations] OFF
GO
