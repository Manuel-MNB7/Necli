USE [Necli]
GO
/****** Object:  Table [dbo].[Cuenta]    Script Date: 30/03/2025 11:05:27 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cuenta](
	[Numero_cuenta] [int] NOT NULL,
	[Id_usuario] [int] NOT NULL,
	[Saldo] [decimal](18, 2) NULL,
	[Fecha_creacion] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Numero_cuenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transaccion]    Script Date: 30/03/2025 11:05:27 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transaccion](
	[Numero] [int] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Numero_cuenta_origen] [int] NOT NULL,
	[Numero_cuenta_destino] [int] NOT NULL,
	[Monto] [decimal](15, 2) NOT NULL,
	[Tipo] [varchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Numero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 30/03/2025 11:05:27 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id_usuario] [int] NOT NULL,
	[Nombres] [varchar](50) NOT NULL,
	[Apellidos] [varchar](50) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Contrasena] [varchar](255) NOT NULL,
	[Telefono] [varchar](15) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Cuenta] ([Numero_cuenta], [Id_usuario], [Saldo], [Fecha_creacion]) VALUES (46, 17, CAST(22222.00 AS Decimal(18, 2)), CAST(N'2025-03-30T18:17:53.230' AS DateTime))
GO
INSERT [dbo].[Cuenta] ([Numero_cuenta], [Id_usuario], [Saldo], [Fecha_creacion]) VALUES (456, 15, CAST(63000.00 AS Decimal(18, 2)), CAST(N'2025-03-29T19:03:37.763' AS DateTime))
GO
INSERT [dbo].[Cuenta] ([Numero_cuenta], [Id_usuario], [Saldo], [Fecha_creacion]) VALUES (1001, 1, CAST(8900000.80 AS Decimal(18, 2)), CAST(N'2025-03-25T18:31:44.610' AS DateTime))
GO
INSERT [dbo].[Cuenta] ([Numero_cuenta], [Id_usuario], [Saldo], [Fecha_creacion]) VALUES (1007, 7, CAST(10068778.00 AS Decimal(18, 2)), CAST(N'2025-03-25T18:31:44.610' AS DateTime))
GO
INSERT [dbo].[Cuenta] ([Numero_cuenta], [Id_usuario], [Saldo], [Fecha_creacion]) VALUES (1009, 9, CAST(8700000.75 AS Decimal(18, 2)), CAST(N'2025-03-25T18:31:44.610' AS DateTime))
GO
INSERT [dbo].[Cuenta] ([Numero_cuenta], [Id_usuario], [Saldo], [Fecha_creacion]) VALUES (1010, 10, CAST(9400000.50 AS Decimal(18, 2)), CAST(N'2025-03-25T18:31:44.610' AS DateTime))
GO
INSERT [dbo].[Cuenta] ([Numero_cuenta], [Id_usuario], [Saldo], [Fecha_creacion]) VALUES (1011, 11, CAST(9198000.30 AS Decimal(18, 2)), CAST(N'2025-03-25T18:31:44.610' AS DateTime))
GO
INSERT [dbo].[Cuenta] ([Numero_cuenta], [Id_usuario], [Saldo], [Fecha_creacion]) VALUES (4516, 19, CAST(1000.00 AS Decimal(18, 2)), CAST(N'2025-03-30T18:41:03.317' AS DateTime))
GO
INSERT [dbo].[Cuenta] ([Numero_cuenta], [Id_usuario], [Saldo], [Fecha_creacion]) VALUES (31064362, 20, CAST(10000.00 AS Decimal(18, 2)), CAST(N'2025-03-30T22:35:13.547' AS DateTime))
GO
INSERT [dbo].[Transaccion] ([Numero], [Fecha], [Numero_cuenta_origen], [Numero_cuenta_destino], [Monto], [Tipo]) VALUES (5001, CAST(N'2025-03-25T18:41:08.287' AS DateTime), 1007, 1010, CAST(100000.00 AS Decimal(15, 2)), N'Salida')
GO
INSERT [dbo].[Transaccion] ([Numero], [Fecha], [Numero_cuenta_origen], [Numero_cuenta_destino], [Monto], [Tipo]) VALUES (5002, CAST(N'2025-03-25T18:41:08.287' AS DateTime), 1010, 1007, CAST(100000.00 AS Decimal(15, 2)), N'Entrada')
GO
INSERT [dbo].[Transaccion] ([Numero], [Fecha], [Numero_cuenta_origen], [Numero_cuenta_destino], [Monto], [Tipo]) VALUES (5003, CAST(N'2025-03-25T18:41:08.287' AS DateTime), 1010, 1009, CAST(75000.00 AS Decimal(15, 2)), N'Salida')
GO
INSERT [dbo].[Transaccion] ([Numero], [Fecha], [Numero_cuenta_origen], [Numero_cuenta_destino], [Monto], [Tipo]) VALUES (5004, CAST(N'2025-03-25T18:41:08.287' AS DateTime), 1009, 1010, CAST(75000.00 AS Decimal(15, 2)), N'Entrada')
GO
INSERT [dbo].[Transaccion] ([Numero], [Fecha], [Numero_cuenta_origen], [Numero_cuenta_destino], [Monto], [Tipo]) VALUES (5005, CAST(N'2025-03-25T18:41:08.290' AS DateTime), 1009, 1011, CAST(50000.00 AS Decimal(15, 2)), N'Salida')
GO
INSERT [dbo].[Transaccion] ([Numero], [Fecha], [Numero_cuenta_origen], [Numero_cuenta_destino], [Monto], [Tipo]) VALUES (5006, CAST(N'2025-03-25T18:41:08.290' AS DateTime), 1011, 1009, CAST(50000.00 AS Decimal(15, 2)), N'Entrada')
GO
INSERT [dbo].[Transaccion] ([Numero], [Fecha], [Numero_cuenta_origen], [Numero_cuenta_destino], [Monto], [Tipo]) VALUES (5007, CAST(N'2025-03-25T18:41:08.290' AS DateTime), 1011, 1001, CAST(120000.00 AS Decimal(15, 2)), N'Salida')
GO
INSERT [dbo].[Transaccion] ([Numero], [Fecha], [Numero_cuenta_origen], [Numero_cuenta_destino], [Monto], [Tipo]) VALUES (5008, CAST(N'2025-03-25T18:41:08.290' AS DateTime), 1001, 1011, CAST(120000.00 AS Decimal(15, 2)), N'Entrada')
GO
INSERT [dbo].[Transaccion] ([Numero], [Fecha], [Numero_cuenta_origen], [Numero_cuenta_destino], [Monto], [Tipo]) VALUES (5009, CAST(N'2025-03-25T18:41:08.290' AS DateTime), 1001, 1007, CAST(200000.00 AS Decimal(15, 2)), N'Salida')
GO
INSERT [dbo].[Transaccion] ([Numero], [Fecha], [Numero_cuenta_origen], [Numero_cuenta_destino], [Monto], [Tipo]) VALUES (5010, CAST(N'2025-03-25T18:41:08.290' AS DateTime), 1007, 1001, CAST(200000.00 AS Decimal(15, 2)), N'Entrada')
GO
INSERT [dbo].[Transaccion] ([Numero], [Fecha], [Numero_cuenta_origen], [Numero_cuenta_destino], [Monto], [Tipo]) VALUES (124506584, CAST(N'2025-03-30T20:21:57.507' AS DateTime), 456, 1011, CAST(1000.00 AS Decimal(15, 2)), N'salida')
GO
INSERT [dbo].[Transaccion] ([Numero], [Fecha], [Numero_cuenta_origen], [Numero_cuenta_destino], [Monto], [Tipo]) VALUES (127815171, CAST(N'2025-03-30T20:18:10.027' AS DateTime), 1011, 456, CAST(1000.00 AS Decimal(15, 2)), N'salida')
GO
INSERT [dbo].[Transaccion] ([Numero], [Fecha], [Numero_cuenta_origen], [Numero_cuenta_destino], [Monto], [Tipo]) VALUES (133394180, CAST(N'2025-03-30T19:24:18.517' AS DateTime), 1010, 1007, CAST(100000.00 AS Decimal(15, 2)), N'salida')
GO
INSERT [dbo].[Transaccion] ([Numero], [Fecha], [Numero_cuenta_origen], [Numero_cuenta_destino], [Monto], [Tipo]) VALUES (138377281, CAST(N'2025-03-30T19:58:32.967' AS DateTime), 1011, 456, CAST(1000.00 AS Decimal(15, 2)), N'entrada')
GO
INSERT [dbo].[Transaccion] ([Numero], [Fecha], [Numero_cuenta_origen], [Numero_cuenta_destino], [Monto], [Tipo]) VALUES (138540604, CAST(N'2025-03-30T20:11:23.303' AS DateTime), 1011, 456, CAST(1000.00 AS Decimal(15, 2)), N'salida')
GO
INSERT [dbo].[Transaccion] ([Numero], [Fecha], [Numero_cuenta_origen], [Numero_cuenta_destino], [Monto], [Tipo]) VALUES (164428847, CAST(N'2025-03-30T20:07:25.643' AS DateTime), 1007, 456, CAST(1000.00 AS Decimal(15, 2)), N'entrada')
GO
INSERT [dbo].[Transaccion] ([Numero], [Fecha], [Numero_cuenta_origen], [Numero_cuenta_destino], [Monto], [Tipo]) VALUES (181093008, CAST(N'2025-03-30T19:50:51.503' AS DateTime), 1007, 46, CAST(10000.00 AS Decimal(15, 2)), N'salida')
GO
INSERT [dbo].[Transaccion] ([Numero], [Fecha], [Numero_cuenta_origen], [Numero_cuenta_destino], [Monto], [Tipo]) VALUES (249574871, CAST(N'2025-03-30T21:01:29.107' AS DateTime), 46, 456, CAST(1000.00 AS Decimal(15, 2)), N'salida')
GO
INSERT [dbo].[Transaccion] ([Numero], [Fecha], [Numero_cuenta_origen], [Numero_cuenta_destino], [Monto], [Tipo]) VALUES (272488109, CAST(N'2025-03-30T20:04:26.453' AS DateTime), 1011, 456, CAST(1000.00 AS Decimal(15, 2)), N'salida')
GO
INSERT [dbo].[Transaccion] ([Numero], [Fecha], [Numero_cuenta_origen], [Numero_cuenta_destino], [Monto], [Tipo]) VALUES (273252021, CAST(N'2025-03-30T19:25:30.420' AS DateTime), 46, 456, CAST(10000.00 AS Decimal(15, 2)), N'salida')
GO
INSERT [dbo].[Transaccion] ([Numero], [Fecha], [Numero_cuenta_origen], [Numero_cuenta_destino], [Monto], [Tipo]) VALUES (297266620, CAST(N'2025-03-30T20:23:47.123' AS DateTime), 1011, 456, CAST(1000.00 AS Decimal(15, 2)), N'salida')
GO
INSERT [dbo].[Transaccion] ([Numero], [Fecha], [Numero_cuenta_origen], [Numero_cuenta_destino], [Monto], [Tipo]) VALUES (310426187, CAST(N'2025-03-30T21:03:41.310' AS DateTime), 46, 456, CAST(1000.00 AS Decimal(15, 2)), N'salida')
GO
INSERT [dbo].[Transaccion] ([Numero], [Fecha], [Numero_cuenta_origen], [Numero_cuenta_destino], [Monto], [Tipo]) VALUES (356151533, CAST(N'2025-03-30T20:56:49.353' AS DateTime), 1011, 456, CAST(1000.00 AS Decimal(15, 2)), N'salida')
GO
INSERT [dbo].[Transaccion] ([Numero], [Fecha], [Numero_cuenta_origen], [Numero_cuenta_destino], [Monto], [Tipo]) VALUES (374256047, CAST(N'2025-03-30T20:01:34.737' AS DateTime), 1011, 456, CAST(1000.00 AS Decimal(15, 2)), N'salida')
GO
INSERT [dbo].[Transaccion] ([Numero], [Fecha], [Numero_cuenta_origen], [Numero_cuenta_destino], [Monto], [Tipo]) VALUES (406295964, CAST(N'2025-03-30T19:16:58.057' AS DateTime), 1007, 1007, CAST(1000.00 AS Decimal(15, 2)), N'salida')
GO
INSERT [dbo].[Transaccion] ([Numero], [Fecha], [Numero_cuenta_origen], [Numero_cuenta_destino], [Monto], [Tipo]) VALUES (417259560, CAST(N'2025-03-30T20:24:10.670' AS DateTime), 456, 1011, CAST(1000.00 AS Decimal(15, 2)), N'salida')
GO
INSERT [dbo].[Transaccion] ([Numero], [Fecha], [Numero_cuenta_origen], [Numero_cuenta_destino], [Monto], [Tipo]) VALUES (466352043, CAST(N'2025-03-30T21:03:28.257' AS DateTime), 456, 46, CAST(1000.00 AS Decimal(15, 2)), N'salida')
GO
INSERT [dbo].[Transaccion] ([Numero], [Fecha], [Numero_cuenta_origen], [Numero_cuenta_destino], [Monto], [Tipo]) VALUES (488617854, CAST(N'2025-03-29T22:10:55.970' AS DateTime), 1009, 1010, CAST(1000.00 AS Decimal(15, 2)), N'salida')
GO
INSERT [dbo].[Transaccion] ([Numero], [Fecha], [Numero_cuenta_origen], [Numero_cuenta_destino], [Monto], [Tipo]) VALUES (594486004, CAST(N'2025-03-30T20:07:42.340' AS DateTime), 456, 1007, CAST(1000.00 AS Decimal(15, 2)), N'entrada')
GO
INSERT [dbo].[Transaccion] ([Numero], [Fecha], [Numero_cuenta_origen], [Numero_cuenta_destino], [Monto], [Tipo]) VALUES (694866119, CAST(N'2025-03-30T19:25:05.007' AS DateTime), 1007, 46, CAST(10000.00 AS Decimal(15, 2)), N'salida')
GO
INSERT [dbo].[Transaccion] ([Numero], [Fecha], [Numero_cuenta_origen], [Numero_cuenta_destino], [Monto], [Tipo]) VALUES (709839455, CAST(N'2025-03-30T19:57:27.217' AS DateTime), 1007, 46, CAST(1000.00 AS Decimal(15, 2)), N'entrada')
GO
INSERT [dbo].[Transaccion] ([Numero], [Fecha], [Numero_cuenta_origen], [Numero_cuenta_destino], [Monto], [Tipo]) VALUES (731182027, CAST(N'2025-03-30T20:18:34.503' AS DateTime), 456, 1011, CAST(1000.00 AS Decimal(15, 2)), N'salida')
GO
INSERT [dbo].[Transaccion] ([Numero], [Fecha], [Numero_cuenta_origen], [Numero_cuenta_destino], [Monto], [Tipo]) VALUES (748942246, CAST(N'2025-03-30T19:57:52.033' AS DateTime), 46, 1007, CAST(1000.00 AS Decimal(15, 2)), N'entrada')
GO
INSERT [dbo].[Transaccion] ([Numero], [Fecha], [Numero_cuenta_origen], [Numero_cuenta_destino], [Monto], [Tipo]) VALUES (751532343, CAST(N'2025-03-30T19:31:53.770' AS DateTime), 1007, 46, CAST(12222.00 AS Decimal(15, 2)), N'entrada')
GO
INSERT [dbo].[Transaccion] ([Numero], [Fecha], [Numero_cuenta_origen], [Numero_cuenta_destino], [Monto], [Tipo]) VALUES (814841007, CAST(N'2025-03-29T22:08:22.090' AS DateTime), 1010, 1009, CAST(1000.00 AS Decimal(15, 2)), N'salida')
GO
INSERT [dbo].[Transaccion] ([Numero], [Fecha], [Numero_cuenta_origen], [Numero_cuenta_destino], [Monto], [Tipo]) VALUES (821058138, CAST(N'2025-03-30T20:11:39.487' AS DateTime), 456, 1011, CAST(1000.00 AS Decimal(15, 2)), N'salida')
GO
INSERT [dbo].[Transaccion] ([Numero], [Fecha], [Numero_cuenta_origen], [Numero_cuenta_destino], [Monto], [Tipo]) VALUES (823425149, CAST(N'2025-03-30T20:24:09.580' AS DateTime), 456, 1011, CAST(1000.00 AS Decimal(15, 2)), N'salida')
GO
INSERT [dbo].[Transaccion] ([Numero], [Fecha], [Numero_cuenta_origen], [Numero_cuenta_destino], [Monto], [Tipo]) VALUES (833037845, CAST(N'2025-03-30T22:27:06.490' AS DateTime), 46, 456, CAST(1000.00 AS Decimal(15, 2)), N'salida')
GO
INSERT [dbo].[Transaccion] ([Numero], [Fecha], [Numero_cuenta_origen], [Numero_cuenta_destino], [Monto], [Tipo]) VALUES (834990952, CAST(N'2025-03-30T21:01:41.953' AS DateTime), 456, 46, CAST(1000.00 AS Decimal(15, 2)), N'salida')
GO
INSERT [dbo].[Transaccion] ([Numero], [Fecha], [Numero_cuenta_origen], [Numero_cuenta_destino], [Monto], [Tipo]) VALUES (863493042, CAST(N'2025-03-30T20:16:03.360' AS DateTime), 1011, 456, CAST(1000.00 AS Decimal(15, 2)), N'salida')
GO
INSERT [dbo].[Transaccion] ([Numero], [Fecha], [Numero_cuenta_origen], [Numero_cuenta_destino], [Monto], [Tipo]) VALUES (887518797, CAST(N'2025-03-30T20:05:03.317' AS DateTime), 456, 1011, CAST(1000.00 AS Decimal(15, 2)), N'salida')
GO
INSERT [dbo].[Transaccion] ([Numero], [Fecha], [Numero_cuenta_origen], [Numero_cuenta_destino], [Monto], [Tipo]) VALUES (902398887, CAST(N'2025-03-30T20:16:19.753' AS DateTime), 456, 1011, CAST(1000.00 AS Decimal(15, 2)), N'salida')
GO
INSERT [dbo].[Transaccion] ([Numero], [Fecha], [Numero_cuenta_origen], [Numero_cuenta_destino], [Monto], [Tipo]) VALUES (920303257, CAST(N'2025-03-30T20:57:14.653' AS DateTime), 456, 1011, CAST(1000.00 AS Decimal(15, 2)), N'salida')
GO
INSERT [dbo].[Transaccion] ([Numero], [Fecha], [Numero_cuenta_origen], [Numero_cuenta_destino], [Monto], [Tipo]) VALUES (923065018, CAST(N'2025-03-30T20:21:43.003' AS DateTime), 1011, 456, CAST(1000.00 AS Decimal(15, 2)), N'salida')
GO
INSERT [dbo].[Transaccion] ([Numero], [Fecha], [Numero_cuenta_origen], [Numero_cuenta_destino], [Monto], [Tipo]) VALUES (949593044, CAST(N'2025-03-30T20:00:48.887' AS DateTime), 1011, 456, CAST(1000.00 AS Decimal(15, 2)), N'salida')
GO
INSERT [dbo].[Transaccion] ([Numero], [Fecha], [Numero_cuenta_origen], [Numero_cuenta_destino], [Monto], [Tipo]) VALUES (958464365, CAST(N'2025-03-30T19:31:53.750' AS DateTime), 1007, 46, CAST(12222.00 AS Decimal(15, 2)), N'salida')
GO
INSERT [dbo].[Usuario] ([Id_usuario], [Nombres], [Apellidos], [Email], [Contrasena], [Telefono]) VALUES (1, N'Kylian', N'Mbappé Loin', N'lm10@fuol.com', N'siu7', N'99992')
GO
INSERT [dbo].[Usuario] ([Id_usuario], [Nombres], [Apellidos], [Email], [Contrasena], [Telefono]) VALUES (7, N'Cristiano', N'Ronaldo', N'cr7@futbol.com', N'siuuu7', N'9999992')
GO
INSERT [dbo].[Usuario] ([Id_usuario], [Nombres], [Apellidos], [Email], [Contrasena], [Telefono]) VALUES (9, N'Karim', N'Benzema', N'kb9@futbol.com', N'ballondor9', N'9999993')
GO
INSERT [dbo].[Usuario] ([Id_usuario], [Nombres], [Apellidos], [Email], [Contrasena], [Telefono]) VALUES (10, N'Lionel', N'Messi', N'lm10@futbol.com', N'goat10', N'9999994')
GO
INSERT [dbo].[Usuario] ([Id_usuario], [Nombres], [Apellidos], [Email], [Contrasena], [Telefono]) VALUES (11, N'Neymar', N'Junior', N'njr11@futbol.com', N'joga11', N'9999995')
GO
INSERT [dbo].[Usuario] ([Id_usuario], [Nombres], [Apellidos], [Email], [Contrasena], [Telefono]) VALUES (12, N'string', N'string', N'string', N'string', N'9999996')
GO
INSERT [dbo].[Usuario] ([Id_usuario], [Nombres], [Apellidos], [Email], [Contrasena], [Telefono]) VALUES (13, N'saith', N'salgado', N'saith@gmail.com', N'12asas', N'9999997')
GO
INSERT [dbo].[Usuario] ([Id_usuario], [Nombres], [Apellidos], [Email], [Contrasena], [Telefono]) VALUES (14, N'xasa', N'asa', N'saas@gmail.com', N'sasa', N'9999998')
GO
INSERT [dbo].[Usuario] ([Id_usuario], [Nombres], [Apellidos], [Email], [Contrasena], [Telefono]) VALUES (15, N'Luis', N'Suárez', N'luissuarez9@example.com', N'ElPistolero9', N'+59812345678')
GO
INSERT [dbo].[Usuario] ([Id_usuario], [Nombres], [Apellidos], [Email], [Contrasena], [Telefono]) VALUES (16, N'kevin', N'perez', N'kevin@gmail.com', N'kevin123.', N'3106436204')
GO
INSERT [dbo].[Usuario] ([Id_usuario], [Nombres], [Apellidos], [Email], [Contrasena], [Telefono]) VALUES (17, N'kevin', N'perez', N'kevin@gmnbail.com', N'kevin123.', N'3106436204')
GO
INSERT [dbo].[Usuario] ([Id_usuario], [Nombres], [Apellidos], [Email], [Contrasena], [Telefono]) VALUES (18, N'kevin', N'perez', N'kevinsasa@gmail.com', N'kevin123.', N'3106436204')
GO
INSERT [dbo].[Usuario] ([Id_usuario], [Nombres], [Apellidos], [Email], [Contrasena], [Telefono]) VALUES (19, N'asas', N'asassa', N'string@dswdw', N'‘ú×N²×rñ«n‚)~eý5 +f•ù+E', N'2121')
GO
INSERT [dbo].[Usuario] ([Id_usuario], [Nombres], [Apellidos], [Email], [Contrasena], [Telefono]) VALUES (20, N'kevin', N'perez', N'lm10@utbol.com', N'goa10', N'991')
GO
/****** Object:  Index [UQ__Cuenta__EF59F76377622DDB]    Script Date: 30/03/2025 11:05:27 p. m. ******/
ALTER TABLE [dbo].[Cuenta] ADD UNIQUE NONCLUSTERED 
(
	[Id_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Usuario__A9D1053421821A33]    Script Date: 30/03/2025 11:05:27 p. m. ******/
ALTER TABLE [dbo].[Usuario] ADD UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Cuenta] ADD  DEFAULT ((0)) FOR [Saldo]
GO
ALTER TABLE [dbo].[Usuario] ADD  DEFAULT ('0000000000') FOR [Telefono]
GO
ALTER TABLE [dbo].[Cuenta]  WITH CHECK ADD FOREIGN KEY([Id_usuario])
REFERENCES [dbo].[Usuario] ([Id_usuario])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Transaccion]  WITH CHECK ADD FOREIGN KEY([Numero_cuenta_origen])
REFERENCES [dbo].[Cuenta] ([Numero_cuenta])
GO
ALTER TABLE [dbo].[Transaccion]  WITH CHECK ADD FOREIGN KEY([Numero_cuenta_destino])
REFERENCES [dbo].[Cuenta] ([Numero_cuenta])
GO
ALTER TABLE [dbo].[Transaccion]  WITH CHECK ADD CHECK  (([Tipo]='Salida' OR [Tipo]='Entrada'))
GO
