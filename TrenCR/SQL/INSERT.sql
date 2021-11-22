USE [TrenCR]
GO
SET IDENTITY_INSERT [dbo].[Estacion] ON 
GO
INSERT [dbo].[Estacion] ([id], [nombre], [estado]) VALUES (1, N'Estación Atlantico', 1)
GO
INSERT [dbo].[Estacion] ([id], [nombre], [estado]) VALUES (2, N'UCR', 1)
GO
INSERT [dbo].[Estacion] ([id], [nombre], [estado]) VALUES (3, N'U Latina', 1)
GO
INSERT [dbo].[Estacion] ([id], [nombre], [estado]) VALUES (4, N'CFIA', 1)
GO
INSERT [dbo].[Estacion] ([id], [nombre], [estado]) VALUES (5, N'UACA', 1)
GO
INSERT [dbo].[Estacion] ([id], [nombre], [estado]) VALUES (6, N'Trés Ríos', 1)
GO
INSERT [dbo].[Estacion] ([id], [nombre], [estado]) VALUES (7, N'Estación Cartago', 1)
GO
INSERT [dbo].[Estacion] ([id], [nombre], [estado]) VALUES (8, N'Los Ángeles', 1)
GO
INSERT [dbo].[Estacion] ([id], [nombre], [estado]) VALUES (9, N'Calle Blancos', 1)
GO
INSERT [dbo].[Estacion] ([id], [nombre], [estado]) VALUES (10, N'Colima', 1)
GO
INSERT [dbo].[Estacion] ([id], [nombre], [estado]) VALUES (11, N'Santa Rosa', 1)
GO
INSERT [dbo].[Estacion] ([id], [nombre], [estado]) VALUES (12, N'MiraFlores', 1)
GO
INSERT [dbo].[Estacion] ([id], [nombre], [estado]) VALUES (13, N'Estación Heredia', 1)
GO
INSERT [dbo].[Estacion] ([id], [nombre], [estado]) VALUES (14, N'San Francisco', 1)
GO
SET IDENTITY_INSERT [dbo].[Estacion] OFF
GO
SET IDENTITY_INSERT [dbo].[Ruta] ON 
GO
INSERT [dbo].[Ruta] ([id], [nombre], [capacidad], [estado]) VALUES (1, N'San Jose-Cartago', 150, 1)
GO
INSERT [dbo].[Ruta] ([id], [nombre], [capacidad], [estado]) VALUES (2, N'Cartago-San Jose', 250, 1)
GO
INSERT [dbo].[Ruta] ([id], [nombre], [capacidad], [estado]) VALUES (3, N'San Jose-Heredia-Alajuela', 500, 1)
GO
INSERT [dbo].[Ruta] ([id], [nombre], [capacidad], [estado]) VALUES (4, N'Alajuela-Heredia-San Jose', 500, 1)
GO
SET IDENTITY_INSERT [dbo].[Ruta] OFF
GO
