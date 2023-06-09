USE [master]
GO
CREATE DATABASE [GestionLogisticaBD]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'GestionLogisticaBD', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\GestionLogisticaBD.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'GestionLogisticaBD_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\GestionLogisticaBD_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [GestionLogisticaBD] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GestionLogisticaBD].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [GestionLogisticaBD] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [GestionLogisticaBD] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [GestionLogisticaBD] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [GestionLogisticaBD] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [GestionLogisticaBD] SET ARITHABORT OFF 
GO
ALTER DATABASE [GestionLogisticaBD] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [GestionLogisticaBD] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [GestionLogisticaBD] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [GestionLogisticaBD] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [GestionLogisticaBD] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [GestionLogisticaBD] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [GestionLogisticaBD] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [GestionLogisticaBD] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [GestionLogisticaBD] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [GestionLogisticaBD] SET  DISABLE_BROKER 
GO
ALTER DATABASE [GestionLogisticaBD] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [GestionLogisticaBD] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [GestionLogisticaBD] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [GestionLogisticaBD] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [GestionLogisticaBD] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [GestionLogisticaBD] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [GestionLogisticaBD] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [GestionLogisticaBD] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [GestionLogisticaBD] SET  MULTI_USER 
GO
ALTER DATABASE [GestionLogisticaBD] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [GestionLogisticaBD] SET DB_CHAINING OFF 
GO
ALTER DATABASE [GestionLogisticaBD] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [GestionLogisticaBD] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [GestionLogisticaBD] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [GestionLogisticaBD] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [GestionLogisticaBD] SET QUERY_STORE = ON
GO
ALTER DATABASE [GestionLogisticaBD] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [GestionLogisticaBD]
GO
/****** Object:  Table [dbo].[Bodega]    Script Date: 21/05/2023 10:06:30 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bodega](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Direccion] [nvarchar](50) NOT NULL,
	[IdCiudad] [int] NOT NULL,
 CONSTRAINT [PK_Bodega] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ciudad]    Script Date: 21/05/2023 10:06:30 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ciudad](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdPais] [int] NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Ciudad] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 21/05/2023 10:06:30 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[Documento] [nvarchar](50) NOT NULL,
	[Nombres] [nvarchar](max) NOT NULL,
	[Apellidos] [nvarchar](max) NOT NULL,
	[Direccion] [nvarchar](50) NOT NULL,
	[CorreoElectronico] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[Documento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Descuento]    Script Date: 21/05/2023 10:06:30 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Descuento](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Porcentaje] [numeric](8, 0) NOT NULL,
	[IdLogistica] [int] NOT NULL,
 CONSTRAINT [PK_Descuento] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Flota]    Script Date: 21/05/2023 10:06:30 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Flota](
	[Numero] [nvarchar](8) NOT NULL,
 CONSTRAINT [PK_Flota] PRIMARY KEY CLUSTERED 
(
	[Numero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Logistica]    Script Date: 21/05/2023 10:06:30 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Logistica](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Logistica] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pais]    Script Date: 21/05/2023 10:06:30 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pais](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Pais] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PlanEntrega]    Script Date: 21/05/2023 10:06:30 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlanEntrega](
	[NumeroGuia] [nvarchar](10) NOT NULL,
	[TipoProducto] [int] NOT NULL,
	[CantidadProducto] [numeric](18, 0) NOT NULL,
	[FechaRegistro] [datetime] NOT NULL,
	[FechaEntrega] [datetime] NOT NULL,
	[PrecioEnvio] [numeric](18, 0) NOT NULL,
	[DocumentoCliente] [nvarchar](50) NOT NULL,
	[Descuento] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_PlanEntrega] PRIMARY KEY CLUSTERED 
(
	[NumeroGuia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PlanEntrega_Bodega]    Script Date: 21/05/2023 10:06:30 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlanEntrega_Bodega](
	[NumeroGuia] [nvarchar](10) NOT NULL,
	[IdBodega] [int] NOT NULL,
 CONSTRAINT [PK_PlanEntrega_Bodega] PRIMARY KEY CLUSTERED 
(
	[NumeroGuia] ASC,
	[IdBodega] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PlanEntrega_Flota]    Script Date: 21/05/2023 10:06:30 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlanEntrega_Flota](
	[NumeroGuia] [nvarchar](10) NOT NULL,
	[NumeroFlota] [nvarchar](8) NOT NULL,
 CONSTRAINT [PK_PlanEntrega_Flota] PRIMARY KEY CLUSTERED 
(
	[NumeroGuia] ASC,
	[NumeroFlota] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PlanEntrega_Puerto]    Script Date: 21/05/2023 10:06:30 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlanEntrega_Puerto](
	[NumeroGuia] [nvarchar](10) NOT NULL,
	[IdPuerto] [int] NOT NULL,
 CONSTRAINT [PK_PlanEntrega_Puerto] PRIMARY KEY CLUSTERED 
(
	[NumeroGuia] ASC,
	[IdPuerto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PlanEntrega_Vehiculo]    Script Date: 21/05/2023 10:06:30 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlanEntrega_Vehiculo](
	[NumeroGuia] [nvarchar](10) NOT NULL,
	[PlacaVehiculo] [nvarchar](6) NOT NULL,
 CONSTRAINT [PK_PlanEntrega_Vehiculo] PRIMARY KEY CLUSTERED 
(
	[NumeroGuia] ASC,
	[PlacaVehiculo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Puerto]    Script Date: 21/05/2023 10:06:30 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Puerto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[IdCiudad] [int] NOT NULL,
 CONSTRAINT [PK_Puerto] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoProducto]    Script Date: 21/05/2023 10:06:30 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoProducto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[IdLogistica] [int] NOT NULL,
 CONSTRAINT [PK_TipoProducto] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vehiculo]    Script Date: 21/05/2023 10:06:30 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vehiculo](
	[Placa] [nvarchar](6) NOT NULL,
 CONSTRAINT [PK_Vehiculo] PRIMARY KEY CLUSTERED 
(
	[Placa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Bodega]  WITH CHECK ADD  CONSTRAINT [FK_Bodega_Ciudad] FOREIGN KEY([IdCiudad])
REFERENCES [dbo].[Ciudad] ([Id])
GO
ALTER TABLE [dbo].[Bodega] CHECK CONSTRAINT [FK_Bodega_Ciudad]
GO
ALTER TABLE [dbo].[Ciudad]  WITH CHECK ADD  CONSTRAINT [FK_Ciudad_Pais] FOREIGN KEY([IdPais])
REFERENCES [dbo].[Pais] ([Id])
GO
ALTER TABLE [dbo].[Ciudad] CHECK CONSTRAINT [FK_Ciudad_Pais]
GO
ALTER TABLE [dbo].[Descuento]  WITH CHECK ADD  CONSTRAINT [FK_Descuento_Logistica] FOREIGN KEY([IdLogistica])
REFERENCES [dbo].[Logistica] ([Id])
GO
ALTER TABLE [dbo].[Descuento] CHECK CONSTRAINT [FK_Descuento_Logistica]
GO
ALTER TABLE [dbo].[PlanEntrega]  WITH CHECK ADD  CONSTRAINT [FK_PlanEntrega_Cliente] FOREIGN KEY([DocumentoCliente])
REFERENCES [dbo].[Cliente] ([Documento])
GO
ALTER TABLE [dbo].[PlanEntrega] CHECK CONSTRAINT [FK_PlanEntrega_Cliente]
GO
ALTER TABLE [dbo].[PlanEntrega]  WITH CHECK ADD  CONSTRAINT [FK_PlanEntrega_TipoProducto] FOREIGN KEY([TipoProducto])
REFERENCES [dbo].[TipoProducto] ([Id])
GO
ALTER TABLE [dbo].[PlanEntrega] CHECK CONSTRAINT [FK_PlanEntrega_TipoProducto]
GO
ALTER TABLE [dbo].[PlanEntrega_Bodega]  WITH CHECK ADD  CONSTRAINT [FK_PlanEntrega_Bodega_Bodega] FOREIGN KEY([IdBodega])
REFERENCES [dbo].[Bodega] ([Id])
GO
ALTER TABLE [dbo].[PlanEntrega_Bodega] CHECK CONSTRAINT [FK_PlanEntrega_Bodega_Bodega]
GO
ALTER TABLE [dbo].[PlanEntrega_Bodega]  WITH CHECK ADD  CONSTRAINT [FK_PlanEntrega_Bodega_PlanEntrega] FOREIGN KEY([NumeroGuia])
REFERENCES [dbo].[PlanEntrega] ([NumeroGuia])
GO
ALTER TABLE [dbo].[PlanEntrega_Bodega] CHECK CONSTRAINT [FK_PlanEntrega_Bodega_PlanEntrega]
GO
ALTER TABLE [dbo].[PlanEntrega_Flota]  WITH CHECK ADD  CONSTRAINT [FK_PlanEntrega_Flota_Flota] FOREIGN KEY([NumeroFlota])
REFERENCES [dbo].[Flota] ([Numero])
GO
ALTER TABLE [dbo].[PlanEntrega_Flota] CHECK CONSTRAINT [FK_PlanEntrega_Flota_Flota]
GO
ALTER TABLE [dbo].[PlanEntrega_Flota]  WITH CHECK ADD  CONSTRAINT [FK_PlanEntrega_Flota_PlanEntrega] FOREIGN KEY([NumeroGuia])
REFERENCES [dbo].[PlanEntrega] ([NumeroGuia])
GO
ALTER TABLE [dbo].[PlanEntrega_Flota] CHECK CONSTRAINT [FK_PlanEntrega_Flota_PlanEntrega]
GO
ALTER TABLE [dbo].[PlanEntrega_Puerto]  WITH CHECK ADD  CONSTRAINT [FK_PlanEntrega_Puerto_PlanEntrega] FOREIGN KEY([NumeroGuia])
REFERENCES [dbo].[PlanEntrega] ([NumeroGuia])
GO
ALTER TABLE [dbo].[PlanEntrega_Puerto] CHECK CONSTRAINT [FK_PlanEntrega_Puerto_PlanEntrega]
GO
ALTER TABLE [dbo].[PlanEntrega_Puerto]  WITH CHECK ADD  CONSTRAINT [FK_PlanEntrega_Puerto_Puerto] FOREIGN KEY([IdPuerto])
REFERENCES [dbo].[Puerto] ([Id])
GO
ALTER TABLE [dbo].[PlanEntrega_Puerto] CHECK CONSTRAINT [FK_PlanEntrega_Puerto_Puerto]
GO
ALTER TABLE [dbo].[PlanEntrega_Vehiculo]  WITH CHECK ADD  CONSTRAINT [FK_PlanEntrega_Vehiculo_PlanEntrega] FOREIGN KEY([NumeroGuia])
REFERENCES [dbo].[PlanEntrega] ([NumeroGuia])
GO
ALTER TABLE [dbo].[PlanEntrega_Vehiculo] CHECK CONSTRAINT [FK_PlanEntrega_Vehiculo_PlanEntrega]
GO
ALTER TABLE [dbo].[PlanEntrega_Vehiculo]  WITH CHECK ADD  CONSTRAINT [FK_PlanEntrega_Vehiculo_Vehiculo] FOREIGN KEY([PlacaVehiculo])
REFERENCES [dbo].[Vehiculo] ([Placa])
GO
ALTER TABLE [dbo].[PlanEntrega_Vehiculo] CHECK CONSTRAINT [FK_PlanEntrega_Vehiculo_Vehiculo]
GO
ALTER TABLE [dbo].[Puerto]  WITH CHECK ADD  CONSTRAINT [FK_Puerto_Ciudad] FOREIGN KEY([IdCiudad])
REFERENCES [dbo].[Ciudad] ([Id])
GO
ALTER TABLE [dbo].[Puerto] CHECK CONSTRAINT [FK_Puerto_Ciudad]
GO
ALTER TABLE [dbo].[TipoProducto]  WITH CHECK ADD  CONSTRAINT [FK_TipoProducto_Logistica] FOREIGN KEY([IdLogistica])
REFERENCES [dbo].[Logistica] ([Id])
GO
ALTER TABLE [dbo].[TipoProducto] CHECK CONSTRAINT [FK_TipoProducto_Logistica]
GO
/****** Object:  StoredProcedure [dbo].[ConsultarBodega]    Script Date: 21/05/2023 10:06:30 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE PROCEDURE [dbo].[ConsultarBodega]
	@nombre AS NVARCHAR(50)
	AS

	SELECT TOP 1 Id, Nombre, Direccion, IdCiudad
	FROM dbo.Bodega
	WHERE Nombre = @nombre

GO
/****** Object:  StoredProcedure [dbo].[ConsultarCliente]    Script Date: 21/05/2023 10:06:30 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE PROCEDURE [dbo].[ConsultarCliente]
	@documento AS NVARCHAR(50)
	AS

	SELECT TOP 1 Documento, Nombres, Apellidos, Direccion, CorreoElectronico
	FROM dbo.Cliente
	WHERE Documento = @documento

GO
/****** Object:  StoredProcedure [dbo].[ConsultarDescuento]    Script Date: 21/05/2023 10:06:30 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE PROCEDURE [dbo].[ConsultarDescuento]
	@idLogistica AS NVARCHAR(50)
	AS

	SELECT TOP 1 Id, Porcentaje, IdLogistica
	FROM dbo.Descuento
	WHERE IdLogistica = CAST(@idLogistica AS INT)

GO
/****** Object:  StoredProcedure [dbo].[ConsultarPlanEntrega]    Script Date: 21/05/2023 10:06:30 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE PROCEDURE [dbo].[ConsultarPlanEntrega]
	@numeroGuia AS NVARCHAR(10)
	AS

	SELECT TOP 1 NumeroGuia, TipoProducto, CantidadProducto, FechaRegistro, FechaEntrega, PrecioEnvio, DocumentoCliente, Descuento
	FROM dbo.PlanEntrega
	WHERE NumeroGuia =@numeroGuia;

GO
/****** Object:  StoredProcedure [dbo].[ConsultarPuerto]    Script Date: 21/05/2023 10:06:30 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE PROCEDURE [dbo].[ConsultarPuerto]
	@nombre AS NVARCHAR(50)
	AS

	SELECT TOP 1 Id, Nombre, IdCiudad
	FROM dbo.Puerto
	WHERE Nombre = @nombre

GO
/****** Object:  StoredProcedure [dbo].[ConsultarTipoProducto]    Script Date: 21/05/2023 10:06:30 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE PROCEDURE [dbo].[ConsultarTipoProducto]
	@id AS NVARCHAR(50)
	AS

	SELECT TOP 1 Id, Nombre, IdLogistica
	FROM dbo.TipoProducto
	WHERE Id = cast (@id as INT)

GO
/****** Object:  StoredProcedure [dbo].[GuardarCliente]    Script Date: 21/05/2023 10:06:30 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GuardarCliente]
@documento AS NVARCHAR(50),
@nombres AS NVARCHAR(Max),
@apellidos AS NVARCHAR(Max),
@direccion AS NVARCHAR(50),
@CorreoElectronico AS NVARCHAR(50)

AS
BEGIN
IF NOT EXISTS(SELECT Documento FROM dbo.Cliente WHERE Documento = @documento)
BEGIN
INSERT INTO dbo.Cliente(Documento, Nombres, Apellidos, Direccion, CorreoElectronico) 
values (@documento, @nombres, @apellidos, @direccion, @CorreoElectronico);
END

END

GO
/****** Object:  StoredProcedure [dbo].[GuardarPlanEntrega]    Script Date: 21/05/2023 10:06:30 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GuardarPlanEntrega]
@numeroGuia AS NVARCHAR(10),
@tipoProducto AS INT, 
@cantidadProducto AS NUMERIC(18,0),
@fechaRegistro AS DATETIME, 
@fechaEntrega AS DATETIME, 
@precioEnvio AS NUMERIC(18,0), 
@documentoCliente AS NVARCHAR(50),
@descuento AS NUMERIC(18,0)

AS
BEGIN
IF NOT EXISTS(SELECT NumeroGuia FROM dbo.PlanEntrega WHERE NumeroGuia = @numeroGuia)
BEGIN
INSERT INTO dbo.PlanEntrega(NumeroGuia, TipoProducto, CantidadProducto, FechaRegistro, FechaEntrega, PrecioEnvio, DocumentoCliente, Descuento) 
values (@numeroGuia, @tipoProducto, @cantidadProducto, @fechaRegistro, @fechaEntrega, @precioEnvio, @documentoCliente, @descuento);
END

END

GO
/****** Object:  StoredProcedure [dbo].[GuardarPlanEntregaBodega]    Script Date: 21/05/2023 10:06:30 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GuardarPlanEntregaBodega]
@numeroGuia AS NVARCHAR(10),
@idBodega AS NVARCHAR(50)

AS
BEGIN
INSERT INTO dbo.PlanEntrega_Bodega(NumeroGuia, IdBodega) 
values (@numeroGuia, cast(@idBodega as int));

END

GO
/****** Object:  StoredProcedure [dbo].[GuardarPlanEntregaFlota]    Script Date: 21/05/2023 10:06:30 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GuardarPlanEntregaFlota]
@numeroGuia AS NVARCHAR(10),
@numeroFlota AS NVARCHAR(6)

AS
BEGIN
IF NOT EXISTS(SELECT Numero FROM dbo.Flota WHERE Numero = @numeroFlota)
BEGIN
INSERT INTO dbo.Flota(Numero) 
values (@numeroFlota);
END

INSERT INTO dbo.PlanEntrega_Flota(NumeroGuia, NumeroFlota) 
values (@numeroGuia, @numeroFlota);

END

GO
/****** Object:  StoredProcedure [dbo].[GuardarPlanEntregaPuerto]    Script Date: 21/05/2023 10:06:30 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GuardarPlanEntregaPuerto]
@numeroGuia AS NVARCHAR(10),
@idPuerto AS NVARCHAR(50)

AS
BEGIN
INSERT INTO dbo.PlanEntrega_Puerto(NumeroGuia, IdPuerto) 
values (@numeroGuia, cast(@idPuerto as int));

END

GO
/****** Object:  StoredProcedure [dbo].[GuardarPlanEntregaVehiculo]    Script Date: 21/05/2023 10:06:30 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GuardarPlanEntregaVehiculo]
@numeroGuia AS NVARCHAR(10),
@placaVehiculo AS NVARCHAR(6)

AS
BEGIN
IF NOT EXISTS(SELECT Placa FROM dbo.Vehiculo WHERE Placa = @placaVehiculo)
BEGIN
INSERT INTO dbo.Vehiculo(Placa) 
values (@placaVehiculo);
END

INSERT INTO dbo.PlanEntrega_Vehiculo(NumeroGuia, PlacaVehiculo) 
values (@numeroGuia, @placaVehiculo);

END

GO
/****** Object:  StoredProcedure [dbo].[GuardarTipoProducto]    Script Date: 21/05/2023 10:06:30 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GuardarTipoProducto]
@nombre AS NVARCHAR(50),
@idLogistica AS INT

AS
BEGIN
IF NOT EXISTS(SELECT id FROM dbo.TipoProducto WHERE Nombre = @nombre)
BEGIN
INSERT INTO dbo.TipoProducto(Nombre, IdLogistica) 
values (@nombre, @idLogistica);
END

END

GO
USE [master]
GO
ALTER DATABASE [GestionLogisticaBD] SET  READ_WRITE 
GO
