
create database DBTienda

go

use DBTienda

go



create table Menu(
idMenu int primary key identity(1,1),
nombre varchar(50),
icono varchar(50),
url varchar(50)
)

go


create table Cliente(
idCli int primary key identity(1,1),
nomCli varchar(100),
apeCli varchar(100),
telCli varchar(100),
dirCli varchar(100),
correo varchar(40),
estado bit default 1,
fechaRegistro datetime default getdate()
)
go

create table Empleado(
idEmp int primary key identity(1,1),
nomEmp varchar(100),
apeEmp varchar(100),
telEmp varchar(100),
dirEmp varchar(100),
correo varchar(40),
estado bit default 1,
fechaRegistro datetime default getdate()
)
go

create table Categoria(
idCat int primary key identity(1,1),
nombre varchar(50),
estado bit default 1,
fechaRegistro datetime default getdate()
)

go

create table Producto (
idProd int primary key identity(1,1),
nombre varchar(100),
idCat int references Categoria(idCat),
stock int,
precio decimal(10,2),
estado bit default 1,
fechaRegistro datetime default getdate()
)

go

create table NumeroDocumento(
idNumeroDocumento int primary key identity(1,1),
ultimo_Numero int not null,
fechaRegistro datetime default getdate()
)
go

create table Venta(
idVenta int primary key identity(1,1),
numeroDocumento varchar(40),
pago varchar(50),
total decimal(10,2),
fechaRegistro datetime default getdate()
)
go

create table DetalleVenta(
idDetalleVenta int primary key identity(1,1),
idVenta int references Venta(idVenta),
idProd int references Producto(idProd),
cantidad int,
precio decimal(10,2),
total decimal(10,2)
)

go

--COMANDO PARA SOLUCIONAR EL PROBLEMA DE AUTORIZACIÓN PARA GENERAR DIAGRAMAS
ALTER AUTHORIZATION ON DATABASE::DBTienda TO sa;

---------------------------------------------------------------




INSERT INTO Categoria(nombre,estado) values
('Bebidas',1),
('Lácteos',1),
('Cereales',1),
('Carnes',1),
('Pescado/Mariscos',1),
('Snacks',1),
('Golosinas',1),
('Salsas/Condimentos',1)

go
select * from Producto

insert into Producto(nombre,idCat,stock,precio,estado) values
('Algas Konbu',6,20,6,1),
('Chocolate',8,30,4.50,1),
('Queso Cheddar',2,30,5,1),
('Papas Lays',7,25,8,1),
('Marshmallows',8,15,6,1),
('Langostinos',6,10,13.50,1),
('Queso Edam',2,10,5,1),
('Leche',2,10,4.80,1)

go

insert into Menu(nombre,icono,url) values
('DashBoard','dashboard','/pages/dashboard'),
('Clientes','group','/pages/clientes'),
('Empleados','group','/pages/empleados'),
('Productos','collections_bookmark','/pages/productos'),
('Venta','currency_exchange','/pages/venta'),
('Historial Ventas','edit_note','/pages/historial_venta'),
('Reportes','receipt','/pages/reportes')

go


insert into numerodocumento(ultimo_Numero,fechaRegistro) values
(0,getdate())



