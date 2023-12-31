USE [master]
GO
/****** Object:  Database [SchoolApplication]    Script Date: 23/12/2023 19:39:15 ******/
CREATE DATABASE [SchoolApplication]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SchoolApplication', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\SchoolApplication.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SchoolApplication_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\SchoolApplication_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SchoolApplication].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SchoolApplication] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SchoolApplication] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SchoolApplication] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SchoolApplication] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SchoolApplication] SET ARITHABORT OFF 
GO
ALTER DATABASE [SchoolApplication] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [SchoolApplication] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SchoolApplication] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SchoolApplication] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SchoolApplication] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SchoolApplication] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SchoolApplication] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SchoolApplication] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SchoolApplication] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SchoolApplication] SET  ENABLE_BROKER 
GO
ALTER DATABASE [SchoolApplication] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SchoolApplication] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SchoolApplication] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SchoolApplication] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SchoolApplication] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SchoolApplication] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [SchoolApplication] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SchoolApplication] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SchoolApplication] SET  MULTI_USER 
GO
ALTER DATABASE [SchoolApplication] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SchoolApplication] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SchoolApplication] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SchoolApplication] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
USE [SchoolApplication]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 23/12/2023 19:39:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Anexo]    Script Date: 23/12/2023 19:39:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Anexo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](200) NOT NULL,
	[Formato] [varchar](4) NOT NULL,
	[Arquivo] [varbinary](max) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[UpdatedAt] [datetime2](7) NOT NULL,
	[UpdatedBy] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Anexo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Escolaridade]    Script Date: 23/12/2023 19:39:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Escolaridade](
	[Id] [int] NOT NULL,
	[Nome] [varchar](40) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[UpdatedAt] [datetime2](7) NOT NULL,
	[UpdatedBy] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Escolaridade] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsuarioHistoricoEscolar]    Script Date: 23/12/2023 19:39:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuarioHistoricoEscolar](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](max) NULL,
	[UsuarioId] [int] NOT NULL,
	[AnexoId] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[UpdatedAt] [datetime2](7) NOT NULL,
	[UpdatedBy] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_UsuarioHistoricoEscolar] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 23/12/2023 19:39:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](20) NOT NULL,
	[SobreNome] [varchar](100) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[DataNascimento] [date] NOT NULL,
	[EscolaridadeId] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[UpdatedAt] [datetime2](7) NOT NULL,
	[UpdatedBy] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231223211233_InitialApplicationDbContext', N'6.0.0')
GO
INSERT [dbo].[Escolaridade] ([Id], [Nome], [IsDeleted], [CreatedAt], [CreatedBy], [UpdatedAt], [UpdatedBy]) VALUES (1, N'Infantil', 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'00000000-0000-0000-0000-000000000000', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'00000000-0000-0000-0000-000000000000')
INSERT [dbo].[Escolaridade] ([Id], [Nome], [IsDeleted], [CreatedAt], [CreatedBy], [UpdatedAt], [UpdatedBy]) VALUES (2, N'Fundamental', 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'00000000-0000-0000-0000-000000000000', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'00000000-0000-0000-0000-000000000000')
INSERT [dbo].[Escolaridade] ([Id], [Nome], [IsDeleted], [CreatedAt], [CreatedBy], [UpdatedAt], [UpdatedBy]) VALUES (3, N'Médio ', 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'00000000-0000-0000-0000-000000000000', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'00000000-0000-0000-0000-000000000000')
INSERT [dbo].[Escolaridade] ([Id], [Nome], [IsDeleted], [CreatedAt], [CreatedBy], [UpdatedAt], [UpdatedBy]) VALUES (4, N'Superior ', 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'00000000-0000-0000-0000-000000000000', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'00000000-0000-0000-0000-000000000000')
GO
/****** Object:  Index [IX_UsuarioHistoricoEscolar_AnexoId]    Script Date: 23/12/2023 19:39:16 ******/
CREATE NONCLUSTERED INDEX [IX_UsuarioHistoricoEscolar_AnexoId] ON [dbo].[UsuarioHistoricoEscolar]
(
	[AnexoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_UsuarioHistoricoEscolar_UsuarioId]    Script Date: 23/12/2023 19:39:16 ******/
CREATE NONCLUSTERED INDEX [IX_UsuarioHistoricoEscolar_UsuarioId] ON [dbo].[UsuarioHistoricoEscolar]
(
	[UsuarioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Usuarios_EscolaridadeId]    Script Date: 23/12/2023 19:39:16 ******/
CREATE NONCLUSTERED INDEX [IX_Usuarios_EscolaridadeId] ON [dbo].[Usuarios]
(
	[EscolaridadeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[UsuarioHistoricoEscolar]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioHistoricoEscolar_Anexo_AnexoId] FOREIGN KEY([AnexoId])
REFERENCES [dbo].[Anexo] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UsuarioHistoricoEscolar] CHECK CONSTRAINT [FK_UsuarioHistoricoEscolar_Anexo_AnexoId]
GO
ALTER TABLE [dbo].[UsuarioHistoricoEscolar]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioHistoricoEscolar_Usuarios_UsuarioId] FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuarios] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UsuarioHistoricoEscolar] CHECK CONSTRAINT [FK_UsuarioHistoricoEscolar_Usuarios_UsuarioId]
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_Escolaridade_EscolaridadeId] FOREIGN KEY([EscolaridadeId])
REFERENCES [dbo].[Escolaridade] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK_Usuarios_Escolaridade_EscolaridadeId]
GO
USE [master]
GO
ALTER DATABASE [SchoolApplication] SET  READ_WRITE 
GO
