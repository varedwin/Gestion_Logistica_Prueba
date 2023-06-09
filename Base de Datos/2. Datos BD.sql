USE [GestionLogisticaBD]
GO
SET IDENTITY_INSERT [dbo].[Logistica] ON 

INSERT [dbo].[Logistica] ([Id], [Nombre]) VALUES (1, N'Terrestre')
INSERT [dbo].[Logistica] ([Id], [Nombre]) VALUES (2, N'Marítimo')
SET IDENTITY_INSERT [dbo].[Logistica] OFF
GO
SET IDENTITY_INSERT [dbo].[Descuento] ON 

INSERT [dbo].[Descuento] ([Id], [Porcentaje], [IdLogistica]) VALUES (1, CAST(5 AS Numeric(8, 0)), 1)
INSERT [dbo].[Descuento] ([Id], [Porcentaje], [IdLogistica]) VALUES (2, CAST(3 AS Numeric(8, 0)), 2)
SET IDENTITY_INSERT [dbo].[Descuento] OFF
GO
SET IDENTITY_INSERT [dbo].[Pais] ON 

INSERT [dbo].[Pais] ([Id], [Nombre]) VALUES (1, N'Colombia')
INSERT [dbo].[Pais] ([Id], [Nombre]) VALUES (2, N'Argentina')
INSERT [dbo].[Pais] ([Id], [Nombre]) VALUES (3, N'Perú')
INSERT [dbo].[Pais] ([Id], [Nombre]) VALUES (4, N'México')
INSERT [dbo].[Pais] ([Id], [Nombre]) VALUES (5, N'Estados Unidos')
INSERT [dbo].[Pais] ([Id], [Nombre]) VALUES (6, N'Canada')
INSERT [dbo].[Pais] ([Id], [Nombre]) VALUES (7, N'España')
SET IDENTITY_INSERT [dbo].[Pais] OFF
GO
SET IDENTITY_INSERT [dbo].[Ciudad] ON 

INSERT [dbo].[Ciudad] ([Id], [IdPais], [Nombre]) VALUES (23, 1, N'Bogotá')
INSERT [dbo].[Ciudad] ([Id], [IdPais], [Nombre]) VALUES (24, 1, N'Cartagena')
INSERT [dbo].[Ciudad] ([Id], [IdPais], [Nombre]) VALUES (25, 2, N'Buenos Aires')
INSERT [dbo].[Ciudad] ([Id], [IdPais], [Nombre]) VALUES (26, 2, N'Córdoba')
INSERT [dbo].[Ciudad] ([Id], [IdPais], [Nombre]) VALUES (27, 3, N'Lima')
INSERT [dbo].[Ciudad] ([Id], [IdPais], [Nombre]) VALUES (28, 4, N'Culiacán')
INSERT [dbo].[Ciudad] ([Id], [IdPais], [Nombre]) VALUES (29, 5, N'Miami')
INSERT [dbo].[Ciudad] ([Id], [IdPais], [Nombre]) VALUES (30, 5, N'New York')
INSERT [dbo].[Ciudad] ([Id], [IdPais], [Nombre]) VALUES (31, 6, N'Toronto')
INSERT [dbo].[Ciudad] ([Id], [IdPais], [Nombre]) VALUES (32, 7, N'Barcelona')
INSERT [dbo].[Ciudad] ([Id], [IdPais], [Nombre]) VALUES (33, 7, N'Madrid')
SET IDENTITY_INSERT [dbo].[Ciudad] OFF
GO
SET IDENTITY_INSERT [dbo].[Bodega] ON 

INSERT [dbo].[Bodega] ([Id], [Nombre], [Direccion], [IdCiudad]) VALUES (1, N'Bod01-Bog', N'Calle 13 # 22 -80', 23)
INSERT [dbo].[Bodega] ([Id], [Nombre], [Direccion], [IdCiudad]) VALUES (2, N'Bod02-Car', N'Carrera 130 # 2 -12', 24)
INSERT [dbo].[Bodega] ([Id], [Nombre], [Direccion], [IdCiudad]) VALUES (3, N'Bod03-BU', N'Calle 1 # 33 -69', 25)
INSERT [dbo].[Bodega] ([Id], [Nombre], [Direccion], [IdCiudad]) VALUES (4, N'Bod04-Cór', N'Carrera 130 # 2 -12', 26)
INSERT [dbo].[Bodega] ([Id], [Nombre], [Direccion], [IdCiudad]) VALUES (5, N'Bod05-Li', N'Calle 8  # 5 -55', 27)
INSERT [dbo].[Bodega] ([Id], [Nombre], [Direccion], [IdCiudad]) VALUES (6, N'Bod06-Cu', N'Calle 99 # 47 -20', 28)
SET IDENTITY_INSERT [dbo].[Bodega] OFF
GO
SET IDENTITY_INSERT [dbo].[Puerto] ON 

INSERT [dbo].[Puerto] ([Id], [Nombre], [IdCiudad]) VALUES (1, N'Pue01-Mi', 29)
INSERT [dbo].[Puerto] ([Id], [Nombre], [IdCiudad]) VALUES (2, N'Pue02-NY', 30)
INSERT [dbo].[Puerto] ([Id], [Nombre], [IdCiudad]) VALUES (3, N'Pue03-TO', 31)
INSERT [dbo].[Puerto] ([Id], [Nombre], [IdCiudad]) VALUES (4, N'Pue04-Ba', 32)
INSERT [dbo].[Puerto] ([Id], [Nombre], [IdCiudad]) VALUES (5, N'Pue05-Ma', 33)
SET IDENTITY_INSERT [dbo].[Puerto] OFF
GO
