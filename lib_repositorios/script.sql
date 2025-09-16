CREATE DATABASE Proyecto;
GO
USE Proyecto;
GO
CREATE TABLE [Empleados] (
    [Id_empleado] INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    [Nombre] NVARCHAR(50) NOT NULL,
    [Puesto] NVARCHAR(50) NOT NULL,
    [Telefono] NVARCHAR(20) NOT NULL,
    [Email] NVARCHAR(100) NOT NULL,
    [Fecha_contratacion] DATE NOT NULL
);
CREATE TABLE [Categorias](
    [Id_categorias] INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    [Nombre] NVARCHAR (50) NOT NULL,
    [Fecha_creacion] SMALLDATETIME DEFAULT GETDATE (),
    [Descripcion] NVARCHAR (200) NOT NULL,
    [Estado] BIT,
    [Prioridad] INT NOT NULL
);
CREATE TABLE [Inventarios] (
    [Id_inventario] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [Nombre] NVARCHAR(50) NOT NULL,
    [Stock] INT NOT NULL,
    [Ubicacion] NVARCHAR(50) NOT NULL,
    [Fecha_actualizacion] SMALLDATETIME DEFAULT GETDATE(),
    [Tipo_producto] NVARCHAR(50) NOT NULL
);

CREATE TABLE [Membresias](
    [Id_membresia] INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    [Tipo] NVARCHAR (100) NOT NULL,
    [Precio] DECIMAL (10,2),
    [Beneficio] NVARCHAR (100),
    [Fecha_inicio] SMALLDATETIME DEFAULT GETDATE (),
    [Fecha_fin] SMALLDATETIME DEFAULT GETDATE ()
);
CREATE TABLE [Clientes] (
    [Id_cliente] INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    [Nombre] NVARCHAR(50) NOT NULL,
    [Email] NVARCHAR(30) NOT NULL,
    [Direccion] NVARCHAR(70),
    [Telefono] NVARCHAR(20),
    [Fecha_registro] DATE NOT NULL,
    [Membresia] INT REFERENCES [Membresias] ([Id_membresia]) NOT NULL
);
CREATE TABLE [Comics](
    [Id_comic] INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    [Nombre] NVARCHAR (50) NOT NULL,
    [Editorial] NVARCHAR (100),
    [Autor] NVARCHAR (50) NOT NULL,
    [Ilustrador] NVARCHAR (50) NOT NULL,
    [Precio] DECIMAL (10,2),
    [Categoria] INT REFERENCES [Categorias] ([Id_categorias]) NOT NULL,
    [Inventario] INT REFERENCES [Inventarios] ([Id_inventario]) NOT NULL
);

CREATE TABLE [Proveedores](
    [Id_proveedor] INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    [Nombre] NVARCHAR (50) NOT NULL,
    [Telefono] NVARCHAR (20) NOT NULL,
    [Email] NVARCHAR(100) NOT NULL,
    [Direccion] NVARCHAR(70),
    [Ciudad] NVARCHAR(50) NOT NULL
);
CREATE TABLE [Ventas] (
    [Id_venta] INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    [Fecha_venta] SMALLDATETIME DEFAULT GETDATE (),
    [Total] DECIMAL(10,2) NOT NULL,
    [Metodo_pago] NVARCHAR(50) NOT NULL,
    [Estado_venta] NVARCHAR(20) NOT NULL,
    [Tipo_venta] NVARCHAR(50) NOT NULL,
    [Empleado] INT REFERENCES [Empleados] ([Id_empleado]) NOT NULL,
    [Proveedor] INT REFERENCES [Proveedores] ([Id_proveedor]) NOT NULL,
    [Membresia] INT REFERENCES [Membresias] ([Id_membresia]) NOT NULL
);
CREATE TABLE [Detalle_Ventas]( 
    [Id] INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    [Precio_unitario] DECIMAL (10,2) NOT NULL,
    [Cantidad] INT NOT NULL,
    [Subtotal] DECIMAL(10,2) NOT NULL,
    [Descuento] DECIMAL(10,2) NOT NULL,
    [Tipo_producto_vendido] NVARCHAR(50) NOT NULL,
    [Venta] INT REFERENCES [Ventas] ([Id_venta]) NOT NULL,
    [Comic] INT REFERENCES [Comics] ([Id_comic]) NOT NULL
);
CREATE TABLE [Pagos](
    [Id_pago] INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    [Metodo] NVARCHAR (50) NOT NULL,
    [Fecha_pago] SMALLDATETIME DEFAULT GETDATE (),
    [Monto] DECIMAL (10,2) NOT NULL,
    [Estado] NVARCHAR(20) NOT NULL,
    [Referencia_transaccion] NVARCHAR(100)
);
CREATE TABLE [Compras](    
    [Id_compra] INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    [Fecha_compra] SMALLDATETIME DEFAULT GETDATE (),
    [Nombre_comic] NVARCHAR (50),
    [Cantidad] INT NOT NULL,
    [Total] DECIMAL(10,2) NOT NULL,
    [Estado_compra] NVARCHAR(20) NOT NULL,
    [Cliente] INT REFERENCES [Clientes] ([Id_cliente]) NOT NULL
);
CREATE TABLE [Detalle_compras]( 
    [Id] INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    [Precio_unitario] DECIMAL (10,2) NOT NULL,
    [Cantidad] INT NOT NULL,
    [Subtotal] DECIMAL(10,2) NOT NULL,
    [Descuento] DECIMAL(10,2) NOT NULL,
    [Tipo_producto_comprado] NVARCHAR(50) NOT NULL,
    [Compra] INT REFERENCES [Compras] ([Id_compra]) NOT NULL,
    [Comic] INT REFERENCES [Comics] ([Id_comic]) NOT NULL,
    [Pago] INT REFERENCES [Pagos] ([Id_pago]) NOT NULL
);
CREATE TABLE [Devoluciones](
    [Id_devolucion] INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    [Motivo] NVARCHAR (50) NOT NULL,
    [Fecha_inicio] SMALLDATETIME DEFAULT GETDATE (),
    [Fecha_fin] SMALLDATETIME DEFAULT GETDATE (),
    [Estado_devolucion] NVARCHAR(20) NOT NULL,
    [Cantidad_devuelta] INT NOT NULL,
    [Cliente] INT REFERENCES [Clientes] ([Id_cliente]) NOT NULL,
    [Detalle_compra] INT REFERENCES [Detalle_compras] ([Id]) NOT NULL
);
CREATE TABLE [Promociones](
    [Id_promocion] INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    [Descripcion] NVARCHAR (100),
    [Descuento] DECIMAL (5,2) NOT NULL,
    [Fecha_inicio] SMALLDATETIME DEFAULT GETDATE (),
    [Fecha_fin] SMALLDATETIME DEFAULT GETDATE (),
    [Codigo] NVARCHAR(20)
);
CREATE TABLE [Comic_promociones](
    [Id] INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    [Fecha_asignacion] SMALLDATETIME DEFAULT GETDATE(),
    [Estado] NVARCHAR(20) NOT NULL,
    [Aplicacion] NVARCHAR(50) NOT NULL,
    [Tipo_promocion] NVARCHAR(50) NOT NULL,
    [Observaciones] NVARCHAR(200),
    [Promocion] INT REFERENCES [Promociones] ([Id_promocion]) NOT NULL,
    [Comic] INT REFERENCES [Comics] ([Id_comic]) NOT NULL
);

-- INSERCION DE DATOS
GO

-- EMPLEADOS
INSERT INTO [Empleados] ([Nombre], [Puesto], [Telefono], [Email], [Fecha_contratacion]) VALUES
('Juan Pérez', 'Cajero', '3001234567', 'juan@comicstore.com', '2023-01-15'),
('Laura Gómez', 'Vendedora', '3019876543', 'laura@comicstore.com', '2022-05-20'),
('Carlos Ruiz', 'Administrador', '3124567890', 'carlos@comicstore.com', '2021-10-10'),
('Marta Silva', 'Bodeguera', '3156781234', 'marta@comicstore.com', '2023-03-01'),
('Andrés Díaz', 'Vendedor', '3167896543', 'andres@comicstore.com', '2024-02-28');

-- CATEGORIAS
INSERT INTO [Categorias] ([Nombre], [Descripcion], [Estado], [Prioridad], [Fecha_creacion]) VALUES
('Superhéroes', 'Comics de Marvel y DC', 1, 1, '2024-04-24'),
('Manga', 'Historietas japonesas', 1, 2, '2024-04-24'),
('Independiente', 'Editoriales independientes', 1, 3, '2024-04-24'),
('Novela Gráfica', 'Historias largas y autoconclusivas', 1, 4, '2024-04-24'),
('Infantil', 'Comics para niños', 1, 5, '2024-04-24');

-- INVENTARIOS
INSERT INTO [Inventarios] ([Nombre], [Stock], [Ubicacion], [Tipo_producto], [Fecha_actualizacion]) VALUES
('Bodega Principal', 150, 'Piso 1', 'Comic', '2024-04-24'),
('Bodega Secundaria', 75, 'Piso 2', 'Comic', '2024-04-24'),
('Estantería A', 40, 'Zona de ventas', 'Comic', '2024-04-24'),
('Estantería B', 30, 'Zona de ventas', 'Comic', '2024-04-24'),
('Depósito Extra', 60, 'Sótano', 'Manga', '2024-04-24');

-- MEMBRESIAS
INSERT INTO [Membresias] ([Tipo], [Precio], [Beneficio], [Fecha_inicio], [Fecha_fin]) VALUES
('Gold', 150000, '10% descuento', '2024-04-24', '2025-04-24'),
('Platinum', 250000, '20% descuento', '2024-04-24', '2025-04-24'),
('Silver', 100000, '5% descuento', '2024-04-24', '2025-04-24'),
('Diamond', 350000, '25% descuento', '2024-04-24', '2025-04-24'),
('Free', 0, 'Sin beneficios', '2024-04-24', '2025-04-24');

-- CLIENTES
INSERT INTO [Clientes] ([Nombre], [Email], [Direccion], [Telefono], [Fecha_registro], [Membresia]) VALUES
('Pedro Torres', 'pedro@email.com', 'Calle 10 #5-23', '3201234567', '2024-04-01', 1),
('Ana López', 'ana@email.com', 'Cra 12 #8-10', '3219876543', '2024-03-25', 2),
('Luis Ramírez', 'luis@email.com', 'Av 15 #9-30', '3226547890', '2024-04-10', 3),
('Claudia Ríos', 'claudia@email.com', 'Calle 7 #11-22', '3008765432', '2024-03-15', 4),
('Felipe Mora', 'felipe@email.com', 'Cra 8 #6-15', '3104567890', '2024-04-05', 5);

-- COMICS
INSERT INTO [Comics] ([Nombre], [Editorial], [Autor], [Ilustrador], [Precio], [Categoria], [Inventario]) VALUES
('Batman Año Uno', 'DC', 'Frank Miller', 'David Mazzucchelli', 45000, 1, 1),
('Naruto Vol.1', 'Shueisha', 'Masashi Kishimoto', 'Masashi Kishimoto', 38000, 2, 2),
('Spider-Man Azul', 'Marvel', 'Jeph Loeb', 'Tim Sale', 50000, 1, 3),
('One Piece Vol.10', 'Shueisha', 'Eiichiro Oda', 'Eiichiro Oda', 40000, 2, 4),
('Maus', 'Pantheon', 'Art Spiegelman', 'Art Spiegelman', 60000, 4, 5);

-- PROVEEDORES
INSERT INTO [Proveedores] ([Nombre], [Telefono], [Email], [Direccion], [Ciudad]) VALUES
('Distribuciones Comics SAS', '3124567890', 'ventas@comics.com', 'Calle 20 #4-30', 'Bogotá'),
('Manga Express', '3112345678', 'contacto@mangaexpress.com', 'Av 3 #15-40', 'Medellín'),
('Marvel Colombia', '3209876543', 'info@marvelcol.com', 'Cra 7 #45-21', 'Cali'),
('DC Distribuciones', '3107654321', 'ventas@dcdistribuciones.com', 'Calle 30 #8-10', 'Bogotá'),
('Indie Books', '3191234567', 'info@indiebooks.com', 'Cra 9 #14-20', 'Barranquilla');

-- VENTAS
INSERT INTO [Ventas] ([Fecha_venta], [Total], [Metodo_pago], [Estado_venta], [Tipo_venta], [Empleado], [Proveedor], [Membresia]) VALUES
('2024-04-24', 90000, 'Efectivo', 'Completada', 'Tienda', 1, 1, 1),
('2024-04-23', 38000, 'Tarjeta', 'Completada', 'Online', 2, 2, 2),
('2024-04-22', 50000, 'Transferencia', 'Pendiente', 'Tienda', 3, 3, 3),
('2024-04-21', 80000, 'Efectivo', 'Completada', 'Tienda', 4, 4, 4),
('2024-04-20', 120000, 'Tarjeta', 'Completada', 'Online', 5, 5, 1);

-- DETALLE_VENTAS
INSERT INTO [Detalle_Ventas] ([Precio_unitario], [Cantidad], [Subtotal], [Descuento], [Tipo_producto_vendido], [Venta], [Comic]) VALUES
(45000, 2, 90000, 0, 'Comic', 1, 1),
(38000, 1, 38000, 0, 'Manga', 2, 2),
(50000, 1, 50000, 5, 'Comic', 3, 3),
(40000, 2, 80000, 10, 'Manga', 4, 4),
(60000, 2, 120000, 0, 'Novela Gráfica', 5, 5);

-- PAGOS
INSERT INTO [Pagos] ([Metodo], [Monto], [Estado], [Referencia_transaccion], [Fecha_pago]) VALUES
('Efectivo', 90000, 'Confirmado', 'REF90000', '2024-04-24'),
('Tarjeta', 38000, 'Confirmado', 'REF38000', '2024-04-23'),
('Transferencia', 50000, 'Pendiente', 'REF50000', '2024-04-22'),
('Efectivo', 80000, 'Confirmado', 'REF80000', '2024-04-21'),
('Tarjeta', 120000, 'Confirmado', 'REF120000', '2024-04-20');

-- COMPRAS
INSERT INTO [Compras] ([Fecha_compra], [Nombre_comic], [Cantidad], [Total], [Estado_compra], [Cliente]) VALUES
('2024-04-24', 'Batman Año Uno', 1, 45000, 'Entregada', 1),
('2024-04-23', 'Naruto Vol.1', 1, 38000, 'Entregada', 2),
('2024-04-22', 'Spider-Man Azul', 1, 50000, 'En camino', 3),
('2024-04-21', 'One Piece Vol.10', 2, 80000, 'Entregada', 4),
('2024-04-20', 'Maus', 2, 120000, 'Entregada', 5);

-- DETALLE_COMPRAS
INSERT INTO [Detalle_compras] ([Precio_unitario], [Cantidad], [Subtotal], [Descuento], [Tipo_producto_comprado], [Compra], [Comic], [Pago]) VALUES
(45000, 1, 45000, 0, 'Comic', 1, 1, 1),
(38000, 1, 38000, 0, 'Manga', 2, 2, 2),
(50000, 1, 50000, 5, 'Comic', 3, 3, 3),
(40000, 2, 80000, 10, 'Manga', 4, 4, 4),
(60000, 2, 120000, 0, 'Novela Gráfica', 5, 5, 5);

-- DEVOLUCIONES
INSERT INTO [Devoluciones] ([Motivo], [Fecha_inicio], [Fecha_fin], [Estado_devolucion], [Cantidad_devuelta], [Cliente], [Detalle_compra]) VALUES
('Defecto de impresión', '2024-04-24', '2024-04-24', 'Procesada', 1, 1, 1),
('Hojas sueltas', '2024-04-23', '2024-04-23', 'Procesada', 1, 2, 2),
('Daño en portada', '2024-04-22', '2024-04-22', 'Pendiente', 1, 3, 3),
('Entrega incorrecta', '2024-04-21', '2024-04-21', 'Procesada', 2, 4, 4),
('Producto repetido', '2024-04-20', '2024-04-20', 'Pendiente', 2, 5, 5);

-- PROMOCIONES
INSERT INTO [Promociones] ([Descripcion], [Descuento], [Fecha_inicio], [Fecha_fin], [Codigo]) VALUES
('Promo Verano', 10.00, '2024-06-01', '2024-08-31', 'VERANO10'),
('Semana del Comic', 15.00, '2024-05-15', '2024-05-22', 'COMICWEEK15'),
('Descuento de Halloween', 20.00, '2024-10-25', '2024-10-31', 'HALLOWEEN20'),
('Black Friday', 30.00, '2024-11-24', '2024-11-24', 'BF30'),
('Navidad', 25.00, '2024-12-01', '2024-12-25', 'NAVIDAD25');

-- COMIC_PROMOCIONES
INSERT INTO [Comic_promociones] ([Fecha_asignacion], [Estado], [Aplicacion], [Tipo_promocion], [Observaciones], [Promocion], [Comic]) VALUES
('2024-04-24', 'Activa', 'Descuento directo', 'General', 'Aplica a toda la categoría', 1, 1),
('2024-04-23', 'Activa', 'Descuento directo', 'Especial', 'Solo para este comic', 2, 2),
('2024-04-22', 'Activa', 'Descuento directo', 'General', 'Aplica a toda la categoría', 3, 3),
('2024-04-21', 'Inactiva', 'Código promocional', 'General', 'Necesita código para aplicar', 4, 4),
('2024-04-20', 'Activa', 'Descuento directo', 'Especial', 'Solo para este comic', 5, 5);



select * from Comic_promociones