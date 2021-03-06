USE [master]
GO
/****** Object:  Database [Facturacion]    Script Date: 29/9/15 12:24:59 a. m. ******/
CREATE DATABASE [Facturacion] ON  PRIMARY 
( NAME = N'Facturacion', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\Facturacion.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Facturacion_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\Facturacion_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Facturacion] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Facturacion].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Facturacion] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Facturacion] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Facturacion] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Facturacion] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Facturacion] SET ARITHABORT OFF 
GO
ALTER DATABASE [Facturacion] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Facturacion] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Facturacion] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Facturacion] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Facturacion] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Facturacion] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Facturacion] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Facturacion] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Facturacion] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Facturacion] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Facturacion] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Facturacion] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Facturacion] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Facturacion] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Facturacion] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Facturacion] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Facturacion] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Facturacion] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Facturacion] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Facturacion] SET  MULTI_USER 
GO
ALTER DATABASE [Facturacion] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Facturacion] SET DB_CHAINING OFF 
GO
USE [Facturacion]
GO
/****** Object:  StoredProcedure [dbo].[EliminacionCat]    Script Date: 29/9/15 12:24:59 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Rodiel Martinez
-- Create date: 31/08/15
-- Description:	Eliminar Categoria (Cambiar el Estado)
-- =============================================
CREATE PROCEDURE [dbo].[EliminacionCat] 
	-- Add the parameters for the stored procedure here
@CodCategoria int,
@Estado bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Update [dbo].[CategoriaProd]
	SET
    Estado = @Estado
	From [dbo].[CategoriaProd]
	Where 
	CodCategoria = @CodCategoria
END
GO
/****** Object:  StoredProcedure [dbo].[InsercionCat]    Script Date: 29/9/15 12:25:00 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Rodiel Martinez
-- Create date: 31/08/15
-- Description:	Insertar Categoria
-- =============================================
CREATE PROCEDURE [dbo].[InsercionCat] 
	-- Add the parameters for the stored procedure here
@Descripcion nvarchar(50),
@Estado bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
    -- Insert statements for procedure here
	INSERT INTO [dbo].[CategoriaProd]
	(
     Descripcion,
	 Estado
	)
	VALUES
	(
	@Descripcion,
	@Estado
	)
	SELECT Cast(SCOPE_IDENTITY() as int) AS id
END
GO
/****** Object:  StoredProcedure [dbo].[InsercionCliente]    Script Date: 29/9/15 12:25:00 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Rodiel Martinez
-- Create date: 31/08/15
-- Description:	Insertar Cliente
-- =============================================
CREATE PROCEDURE [dbo].[InsercionCliente] 
	-- Add the parameters for the stored procedure here
	@NombreCliente nvarchar(50),
	@RNC nvarchar(9),
	@Direccion nvarchar(150),
	@Telefono nvarchar(10),
	@TelMovil nvarchar(10),
	@Email nvarchar(50),
	@Contacto nvarchar(20),
	@EstadoCli bit,
	@TipoPrecio int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [dbo].[Cliente]
	(
	[NombreCliente],
	[RNC],
	[Direccion],
	[Telefono],
	[TelMovil],
	[Email],
	[Contacto],
	[EstadoCli],
	[TipoPrecio]
	)
	VALUES
	(
	@NombreCliente,
	@RNC,
	@Direccion,
	@Telefono,
	@TelMovil,
	@Email,
	@Contacto,
	@EstadoCli,
	@TipoPrecio
	)
	SELECT Cast(SCOPE_IDENTITY() as int) AS id
END
GO
/****** Object:  StoredProcedure [dbo].[InsercionFactura]    Script Date: 29/9/15 12:25:00 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Rodiel Martinez
-- Create date: 31/08/15
-- Description:	Insertar Factura
-- =============================================
CREATE PROCEDURE [dbo].[InsercionFactura] 
	-- Add the parameters for the stored procedure here

	@CodCliente int,
	@CodUsuario int,
	@Fecha datetime,
	@SubTotal money,
	@Impuesto money,
	@Descuento money,
	@Total money,
	@Estado bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [dbo].[Factura]
	(
	CodCliente,
	CodUsuario,
	Fecha,
	SubTotal,
	Impuesto,
	Descuento,
	Total,
	Estado
	)
	VALUES
	(
	@CodCliente,
	@CodUsuario,
	@Fecha,
	@SubTotal,
	@Impuesto,
	@Descuento,
	@Total,
	@Estado
	)
END

GO
/****** Object:  StoredProcedure [dbo].[InsercionProd]    Script Date: 29/9/15 12:25:00 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Rodiel Martinez
-- Create date: 30/08/15
-- Description:	Insertar Productos
-- =============================================
CREATE PROCEDURE [dbo].[InsercionProd] 
	-- Add the parameters for the stored procedure here
@CodigoProd nvarchar(10),
@NombreProd nvarchar(10),
@Precio1 money,
@Precio2 money,
@Precio3 money,
@EstadoProd bit,
@ExistenciaProd int,
@CodCategoria int,
@UnidadProd nchar,
@CantidadMin int,
@Impuesto decimal(5,4),
@CostoProd money,
@Nota nvarchar(150)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [dbo].[Producto]
	(
	CodigoProd,
	NombreProd,
	Precio1,
	Precio2,
	Precio3,
	EstadoProd,
	ExistenciaProd,
	CodCategoria,
	UnidadProd,
	CantidadMin,
	Impuesto,
	CostoProd,
	Nota
	)
	VALUES
	(
	@CodigoProd,
	@NombreProd,
	@Precio1,
	@Precio2,
	@Precio3,
	@EstadoProd,
	@ExistenciaProd,
	@CodCategoria,
	@UnidadProd,
	@CantidadMin,
	@Impuesto,
	@CostoProd,
	@Nota
	)
	--Devuelve el codigo asignado al registro
	SELECT Cast(SCOPE_IDENTITY() as int) AS id
END
GO
/****** Object:  StoredProcedure [dbo].[InsercionUsers]    Script Date: 29/9/15 12:25:00 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Rodiel Martinez
-- Create date: 31/08/15
-- Description:	Insertar Usuario
-- =============================================
CREATE PROCEDURE [dbo].[InsercionUsers] 
	-- Add the parameters for the stored procedure here
@Nombre nvarchar(50),
@Administrador bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [dbo].[Usuario]
	(
	Nombre,
	Administrador
	)
	VALUES
	(
	@Nombre,
	@Administrador
	)
	SELECT Cast(SCOPE_IDENTITY() as int) AS id
END
GO
/****** Object:  StoredProcedure [dbo].[ModificacionCat]    Script Date: 29/9/15 12:25:00 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Rodiel Martinez
-- Create date: 31/08/15
-- Description:	Modificar Categoria
-- =============================================
CREATE PROCEDURE [dbo].[ModificacionCat] 
	-- Add the parameters for the stored procedure here
@CodCategoria int,
@Descripcion nvarchar(50),
@Estado bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Update [dbo].[CategoriaProd]
	SET
    Descripcion = @Descripcion,
	Estado = @Estado
	From [dbo].[CategoriaProd]
	Where 
	CodCategoria = @CodCategoria
END
GO
/****** Object:  StoredProcedure [dbo].[ModificacionCliente]    Script Date: 29/9/15 12:25:00 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Rodiel Martinez
-- Create date: 31/08/15
-- Description:	Modificacion de Cliente
-- =============================================
CREATE PROCEDURE [dbo].[ModificacionCliente]
	-- Add the parameters for the stored procedure here
	@CodCliente int,
	@NombreCliente nvarchar(50),
	@RNC nvarchar(9),
	@Direccion nvarchar(150),
	@Telefono nvarchar(10),
	@TelMovil nvarchar(10),
	@Email nvarchar(50),
	@Contacto nvarchar(20),
	@EstadoCli bit,
	@TipoPrecio int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	Update [dbo].[Cliente]
	SET
	NombreCliente = @NombreCliente,
	RNC = @RNC,
	Direccion = @Direccion,
	Telefono = @Telefono,
	TelMovil = @TelMovil,
	Email = @Email,
	Contacto = @Contacto,
	EstadoCli = @EstadoCli,
	TipoPrecio = @TipoPrecio 
	FROM [dbo].[Cliente]
	Where
	CodCliente = @CodCliente
END

GO
/****** Object:  StoredProcedure [dbo].[ModificacionProd]    Script Date: 29/9/15 12:25:00 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Rodiel Martinez
-- Create date: 31/08/15
-- Description:	Modificacion de Producto
-- =============================================
CREATE PROCEDURE [dbo].[ModificacionProd] 
	-- Add the parameters for the stored procedure here
	@CodigoProd nvarchar(10),
	@NombreProd nvarchar(50),
	@Precio1 money,
	@Precio2 money,
	@Precio3 money,
	@EstadoProd bit,
	@ExistenciaProd int,
	@CodCategoria int,
	@UnidadProd nchar,
	@CantidadMin int,
	@Impuesto decimal(5,4),
	@CostoProd money,
	@Nota nvarchar(150)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	Update [dbo].[Producto]
	SET
	NombreProd = @NombreProd,
	Precio1 = @Precio1,
	Precio2 = @Precio2,
	Precio3 = @Precio3,
	EstadoProd = @EstadoProd,
	ExistenciaProd = @ExistenciaProd,
	CodCategoria = @CodCategoria,
	UnidadProd = @UnidadProd,
	CantidadMin = @CantidadMin,
	Impuesto = @Impuesto,
	CostoProd = @CostoProd,
	Nota = @Nota
	FROM [dbo].[Producto]
	Where
	CodigoProd = @CodigoProd
END

GO
/****** Object:  StoredProcedure [dbo].[ModificacionUsers]    Script Date: 29/9/15 12:25:00 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Rodiel Martinez
-- Create date: 31/08/15
-- Description:	Modificacion de Usuario
-- =============================================
CREATE PROCEDURE [dbo].[ModificacionUsers]
	-- Add the parameters for the stored procedure here
	@CodUsuario int,
	@Nombre nvarchar(50),
	@Administrador bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	Update [dbo].[Usuario]
	SET
	Nombre = @Nombre,
	Administrador = @Administrador
	FROM [dbo].[Usuario]
	Where
	CodUsuario = @CodUsuario
END

GO
/****** Object:  StoredProcedure [dbo].[SPFiltroCat]    Script Date: 29/9/15 12:25:00 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Rodiel Martinez
-- Create date: 3/09/15
-- Description:	Seleccion de Registro Categoria
-- =============================================
CREATE PROCEDURE [dbo].[SPFiltroCat] 
	-- Add the parameters for the stored procedure here

@CodCategoria int,
@Descripcion nvarchar(50),
@Estado bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Select * From [dbo].[CategoriaProd]
	Where CodCategoria = @CodCategoria

	END
GO
/****** Object:  StoredProcedure [dbo].[SpNumeradorDocumento]    Script Date: 29/9/15 12:25:00 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Rodiel Martinez Jimenez>
-- Create date: <13/9/15>
-- Description:	<Numerador De Documento>
-- =============================================
CREATE PROCEDURE [dbo].[SpNumeradorDocumento] 
@IdDocumento as char(3)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	Update [dbo].[documento] 
	SET ultimoNumero = ultimonumero + 1 
	Where tipoDocumento = @IdDocumento

    Select ultimonumero 
	from [dbo].[documento] 
	WHERE tipoDocumento = @IdDocumento
end 

GO
/****** Object:  StoredProcedure [dbo].[SpNumeradorTipoComprobante]    Script Date: 29/9/15 12:25:00 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Rodiel Martinez Jimenez>
-- Create date: <13/9/15>
-- Description:	<Numerador De TipoComprobante>
-- =============================================
CREATE PROCEDURE [dbo].[SpNumeradorTipoComprobante]
@IdNCF as char(2)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	Update [dbo].[comprobanteTipo]
	SET secuencia = secuencia + 1 
	Where idNCF = @IdNCF

    Select ultimonumero 
	from [dbo].[documento] 
	WHERE tipoDocumento = @IdNCF
end 

GO
/****** Object:  Table [dbo].[CategoriaProd]    Script Date: 29/9/15 12:25:00 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CategoriaProd](
	[CodCategoria] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](50) NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_CategoriaProd] PRIMARY KEY CLUSTERED 
(
	[CodCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 29/9/15 12:25:00 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[CodCliente] [int] IDENTITY(1,1) NOT NULL,
	[NombreCliente] [nvarchar](50) NOT NULL,
	[RNC] [nvarchar](11) NULL,
	[Direccion] [nvarchar](150) NULL,
	[Telefono] [nvarchar](10) NULL,
	[TelMovil] [nvarchar](10) NULL,
	[Email] [nvarchar](50) NULL,
	[Contacto] [nvarchar](20) NULL,
	[EstadoCli] [bit] NOT NULL,
	[TipoPrecio] [int] NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[CodCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[comprobanteTipo]    Script Date: 29/9/15 12:25:00 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[comprobanteTipo](
	[idNCF] [char](2) NOT NULL,
	[Descripcion] [nchar](50) NULL,
	[prefijo] [varchar](11) NULL,
	[secuencia] [int] NULL,
	[limite] [int] NULL,
	[factura] [bit] NULL,
 CONSTRAINT [PK_comprobanteTipo] PRIMARY KEY CLUSTERED 
(
	[idNCF] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[documento]    Script Date: 29/9/15 12:25:00 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[documento](
	[tipoDocumento] [char](3) NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
	[ultimonumero] [int] NOT NULL,
	[EfectoExistencia] [numeric](2, 0) NULL,
 CONSTRAINT [PK_documento] PRIMARY KEY CLUSTERED 
(
	[tipoDocumento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[inv_movdetalle]    Script Date: 29/9/15 12:25:00 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[inv_movdetalle](
	[idMovimiento] [int] NOT NULL,
	[fila] [int] NOT NULL,
	[Codigo] [int] NOT NULL,
	[Precio] [money] NOT NULL,
	[costo] [money] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[impuesto] [money] NOT NULL,
 CONSTRAINT [PK_inv_movdetalle_1] PRIMARY KEY CLUSTERED 
(
	[idMovimiento] ASC,
	[fila] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[inv_movencabezado]    Script Date: 29/9/15 12:25:00 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[inv_movencabezado](
	[idMovimiento] [int] IDENTITY(1,1) NOT NULL,
	[tipoDocumento] [char](3) NOT NULL,
	[numeroDoc] [int] NOT NULL,
	[CodTercero] [int] NOT NULL,
	[CodUsuario] [int] NOT NULL,
	[rnc] [varchar](11) NULL,
	[idNCF] [char](2) NULL,
	[ncf] [varchar](19) NULL,
	[ncfAfectado] [varchar](19) NULL,
	[Fecha] [datetime] NOT NULL,
	[totalExento] [money] NOT NULL,
	[totalGravado] [nchar](10) NULL,
	[Impuesto] [money] NOT NULL,
	[Descuento] [money] NULL,
	[Total] [money] NOT NULL,
	[Estado] [bit] NOT NULL,
	[EfectoExistencia] [numeric](2, 0) NULL,
 CONSTRAINT [PK_inv_movencabezado] PRIMARY KEY CLUSTERED 
(
	[idMovimiento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 29/9/15 12:25:00 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[CodigoProd] [nvarchar](10) NOT NULL,
	[NombreProd] [nvarchar](50) NOT NULL,
	[Precio1] [money] NOT NULL,
	[Precio2] [money] NULL,
	[Precio3] [money] NULL,
	[EstadoProd] [bit] NOT NULL,
	[ExistenciaProd] [int] NULL,
	[CodCategoria] [int] NOT NULL,
	[UnidadProd] [nchar](10) NOT NULL,
	[CantidadMin] [int] NOT NULL,
	[Impuesto] [decimal](5, 4) NULL,
	[CostoProd] [money] NULL,
	[Nota] [nvarchar](150) NULL,
 CONSTRAINT [PK_Producto_1] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 29/9/15 12:25:00 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[CodUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NULL,
	[Administrador] [bit] NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[CodUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  View [dbo].[ViewProduct]    Script Date: 29/9/15 12:25:00 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ViewProduct]
AS
SELECT        dbo.Producto.CodigoProd, dbo.Producto.NombreProd, dbo.Producto.Precio1, dbo.Producto.Precio2, dbo.Producto.Precio3, dbo.Producto.EstadoProd, dbo.CategoriaProd.Descripcion, dbo.Producto.ExistenciaProd, 
                         dbo.Producto.UnidadProd, dbo.Producto.CantidadMin, dbo.Producto.Impuesto
FROM            dbo.Producto INNER JOIN
                         dbo.CategoriaProd ON dbo.Producto.CodCategoria = dbo.CategoriaProd.CodCategoria

GO
SET IDENTITY_INSERT [dbo].[CategoriaProd] ON 

INSERT [dbo].[CategoriaProd] ([CodCategoria], [Descripcion], [Estado]) VALUES (1, N'Alimento', 1)
INSERT [dbo].[CategoriaProd] ([CodCategoria], [Descripcion], [Estado]) VALUES (2, N'Bebidas', 1)
INSERT [dbo].[CategoriaProd] ([CodCategoria], [Descripcion], [Estado]) VALUES (3, N'Dulces', 1)
INSERT [dbo].[CategoriaProd] ([CodCategoria], [Descripcion], [Estado]) VALUES (4, N'Empaquetados', 1)
INSERT [dbo].[CategoriaProd] ([CodCategoria], [Descripcion], [Estado]) VALUES (5, N'Galletas', 1)
INSERT [dbo].[CategoriaProd] ([CodCategoria], [Descripcion], [Estado]) VALUES (6, N'Gaseosas', 1)
INSERT [dbo].[CategoriaProd] ([CodCategoria], [Descripcion], [Estado]) VALUES (7, N'Prueba', 1)
INSERT [dbo].[CategoriaProd] ([CodCategoria], [Descripcion], [Estado]) VALUES (8, N'Prueba 2', 1)
INSERT [dbo].[CategoriaProd] ([CodCategoria], [Descripcion], [Estado]) VALUES (9, N'Prueba 3', 1)
INSERT [dbo].[CategoriaProd] ([CodCategoria], [Descripcion], [Estado]) VALUES (10, N'Prueba 4', 1)
INSERT [dbo].[CategoriaProd] ([CodCategoria], [Descripcion], [Estado]) VALUES (11, N'Prueba 6', 1)
INSERT [dbo].[CategoriaProd] ([CodCategoria], [Descripcion], [Estado]) VALUES (12, N'sad', 1)
INSERT [dbo].[CategoriaProd] ([CodCategoria], [Descripcion], [Estado]) VALUES (13, N'sad', 1)
INSERT [dbo].[CategoriaProd] ([CodCategoria], [Descripcion], [Estado]) VALUES (14, N'sd', 1)
INSERT [dbo].[CategoriaProd] ([CodCategoria], [Descripcion], [Estado]) VALUES (15, N'teds', 1)
INSERT [dbo].[CategoriaProd] ([CodCategoria], [Descripcion], [Estado]) VALUES (16, N'assas', 1)
SET IDENTITY_INSERT [dbo].[CategoriaProd] OFF
SET IDENTITY_INSERT [dbo].[Cliente] ON 

INSERT [dbo].[Cliente] ([CodCliente], [NombreCliente], [RNC], [Direccion], [Telefono], [TelMovil], [Email], [Contacto], [EstadoCli], [TipoPrecio]) VALUES (1, N'Ramon García', N'', N'', N'', N'', N'', N'', 1, 1)
INSERT [dbo].[Cliente] ([CodCliente], [NombreCliente], [RNC], [Direccion], [Telefono], [TelMovil], [Email], [Contacto], [EstadoCli], [TipoPrecio]) VALUES (2, N'Lucia Santa', N'342343242', N'Calle Santa #4', N'8093456334', N'8093434232', N'SantaLucy@gmail.com', N'', 1, 2)
INSERT [dbo].[Cliente] ([CodCliente], [NombreCliente], [RNC], [Direccion], [Telefono], [TelMovil], [Email], [Contacto], [EstadoCli], [TipoPrecio]) VALUES (3, N'Luis Guzman', N'', N'', N'', N'', N'', N'', 1, 1)
INSERT [dbo].[Cliente] ([CodCliente], [NombreCliente], [RNC], [Direccion], [Telefono], [TelMovil], [Email], [Contacto], [EstadoCli], [TipoPrecio]) VALUES (5, N'Manny Daniel Susana Jimenez', N'243242343', N'Calle#13, Los alamos', N'8093434423', N'8093232323', N'', N'', 1, 1)
SET IDENTITY_INSERT [dbo].[Cliente] OFF
INSERT [dbo].[comprobanteTipo] ([idNCF], [Descripcion], [prefijo], [secuencia], [limite], [factura]) VALUES (N'01', N'Facturas con valor fiscal                         ', N'A0200102101', 3, 100, 1)
INSERT [dbo].[comprobanteTipo] ([idNCF], [Descripcion], [prefijo], [secuencia], [limite], [factura]) VALUES (N'02', N'Facturas para Consumidores Finales
              ', N'A0200102102', 1, 1000, 1)
INSERT [dbo].[comprobanteTipo] ([idNCF], [Descripcion], [prefijo], [secuencia], [limite], [factura]) VALUES (N'03', N'Nota de Debito                                    ', N'A0200102103', 1, 1000, 0)
INSERT [dbo].[comprobanteTipo] ([idNCF], [Descripcion], [prefijo], [secuencia], [limite], [factura]) VALUES (N'04', N'Nota de Credito                                   ', N'A0200102104', 1, 1000, 0)
INSERT [dbo].[comprobanteTipo] ([idNCF], [Descripcion], [prefijo], [secuencia], [limite], [factura]) VALUES (N'11', N'Proveedores Informales                            ', N'A0200102111', 1, 1000, 0)
INSERT [dbo].[comprobanteTipo] ([idNCF], [Descripcion], [prefijo], [secuencia], [limite], [factura]) VALUES (N'12', N'Registro Unico de Ingresos                        ', N'A0200102112', 1, 1000, 0)
INSERT [dbo].[comprobanteTipo] ([idNCF], [Descripcion], [prefijo], [secuencia], [limite], [factura]) VALUES (N'13', N'Gastos Menores                                    ', N'A0200102113', 1, 1000, 0)
INSERT [dbo].[comprobanteTipo] ([idNCF], [Descripcion], [prefijo], [secuencia], [limite], [factura]) VALUES (N'14', N'Para Regímenes Especiales                         ', N'A0200102114', 1, 1000, 1)
INSERT [dbo].[comprobanteTipo] ([idNCF], [Descripcion], [prefijo], [secuencia], [limite], [factura]) VALUES (N'15', N'Gubernamentales                                   ', N'A0200102115', 1, 1000, 1)
INSERT [dbo].[documento] ([tipoDocumento], [Descripcion], [ultimonumero], [EfectoExistencia]) VALUES (N'DEV', N'Devolucion', 0, CAST(1 AS Numeric(2, 0)))
INSERT [dbo].[documento] ([tipoDocumento], [Descripcion], [ultimonumero], [EfectoExistencia]) VALUES (N'EAL', N'Entrada de Almacen', 0, CAST(1 AS Numeric(2, 0)))
INSERT [dbo].[documento] ([tipoDocumento], [Descripcion], [ultimonumero], [EfectoExistencia]) VALUES (N'FAT', N'Factura', 0, CAST(-1 AS Numeric(2, 0)))
INSERT [dbo].[documento] ([tipoDocumento], [Descripcion], [ultimonumero], [EfectoExistencia]) VALUES (N'SAL', N'Salida de Almacen', 0, CAST(-1 AS Numeric(2, 0)))
SET IDENTITY_INSERT [dbo].[Producto] ON 

INSERT [dbo].[Producto] ([Codigo], [CodigoProd], [NombreProd], [Precio1], [Precio2], [Precio3], [EstadoProd], [ExistenciaProd], [CodCategoria], [UnidadProd], [CantidadMin], [Impuesto], [CostoProd], [Nota]) VALUES (5, N'001', N'Arroz', 34.5000, 0.0000, 0.0000, 1, 45, 1, N'U         ', 10, CAST(0.1800 AS Decimal(5, 4)), 20.0000, N'')
INSERT [dbo].[Producto] ([Codigo], [CodigoProd], [NombreProd], [Precio1], [Precio2], [Precio3], [EstadoProd], [ExistenciaProd], [CodCategoria], [UnidadProd], [CantidadMin], [Impuesto], [CostoProd], [Nota]) VALUES (6, N'002', N'Aceite', 16.0000, 12.0000, 23.0000, 1, 5, 4, N'2         ', 12, CAST(0.0000 AS Decimal(5, 4)), 4.0000, N'')
INSERT [dbo].[Producto] ([Codigo], [CodigoProd], [NombreProd], [Precio1], [Precio2], [Precio3], [EstadoProd], [ExistenciaProd], [CodCategoria], [UnidadProd], [CantidadMin], [Impuesto], [CostoProd], [Nota]) VALUES (7, N'003', N'Salami', 45.0000, 30.0000, 45.0000, 1, 50, 4, N'3         ', 10, CAST(0.1800 AS Decimal(5, 4)), 6.0000, N'')
SET IDENTITY_INSERT [dbo].[Producto] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [UK_CodProd]    Script Date: 29/9/15 12:25:00 a. m. ******/
ALTER TABLE [dbo].[Producto] ADD  CONSTRAINT [UK_CodProd] UNIQUE NONCLUSTERED 
(
	[CodigoProd] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[inv_movdetalle]  WITH CHECK ADD  CONSTRAINT [FK_inv_movdetalle_inv_movencabezado1] FOREIGN KEY([idMovimiento])
REFERENCES [dbo].[inv_movencabezado] ([idMovimiento])
GO
ALTER TABLE [dbo].[inv_movdetalle] CHECK CONSTRAINT [FK_inv_movdetalle_inv_movencabezado1]
GO
ALTER TABLE [dbo].[inv_movdetalle]  WITH CHECK ADD  CONSTRAINT [FK_inv_movdetalle_Producto] FOREIGN KEY([Codigo])
REFERENCES [dbo].[Producto] ([Codigo])
GO
ALTER TABLE [dbo].[inv_movdetalle] CHECK CONSTRAINT [FK_inv_movdetalle_Producto]
GO
ALTER TABLE [dbo].[inv_movencabezado]  WITH CHECK ADD  CONSTRAINT [FK_Factura_Cliente] FOREIGN KEY([CodTercero])
REFERENCES [dbo].[Cliente] ([CodCliente])
GO
ALTER TABLE [dbo].[inv_movencabezado] CHECK CONSTRAINT [FK_Factura_Cliente]
GO
ALTER TABLE [dbo].[inv_movencabezado]  WITH CHECK ADD  CONSTRAINT [FK_Factura_Usuario] FOREIGN KEY([CodUsuario])
REFERENCES [dbo].[Usuario] ([CodUsuario])
GO
ALTER TABLE [dbo].[inv_movencabezado] CHECK CONSTRAINT [FK_Factura_Usuario]
GO
ALTER TABLE [dbo].[inv_movencabezado]  WITH CHECK ADD  CONSTRAINT [FK_inv_movencabezado_comprobanteTipo] FOREIGN KEY([idNCF])
REFERENCES [dbo].[comprobanteTipo] ([idNCF])
GO
ALTER TABLE [dbo].[inv_movencabezado] CHECK CONSTRAINT [FK_inv_movencabezado_comprobanteTipo]
GO
ALTER TABLE [dbo].[inv_movencabezado]  WITH CHECK ADD  CONSTRAINT [FK_inv_movencabezado_documento] FOREIGN KEY([tipoDocumento])
REFERENCES [dbo].[documento] ([tipoDocumento])
GO
ALTER TABLE [dbo].[inv_movencabezado] CHECK CONSTRAINT [FK_inv_movencabezado_documento]
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_CategoriaProd] FOREIGN KEY([CodCategoria])
REFERENCES [dbo].[CategoriaProd] ([CodCategoria])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_CategoriaProd]
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD  CONSTRAINT [CK_Cliente] CHECK  (([TipoPrecio]>(0) AND [TipoPrecio]<(4)))
GO
ALTER TABLE [dbo].[Cliente] CHECK CONSTRAINT [CK_Cliente]
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [CK_Producto] CHECK  (([Impuesto]<(1.0000) AND [Impuesto]>=(0)))
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [CK_Producto]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Producto"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 211
               Right = 228
            End
            DisplayFlags = 280
            TopColumn = 6
         End
         Begin Table = "CategoriaProd"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 147
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewProduct'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewProduct'
GO
USE [master]
GO
ALTER DATABASE [Facturacion] SET  READ_WRITE 
GO
