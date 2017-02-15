create database GestionCientes3;
use GestionCientes3;


create table categorias(
idCategoria int unique IDENTITY(1,1),
nombre varchar(30),
primary key(idCategoria)
);


create table clientes(
idCliente int unique IDENTITY(1,1),
nombre varchar(20),
apellidos varchar(30),
telefono varchar(15),
correo varchar(30),
idCategoria int,
primary key(idCliente),
foreign key(idCategoria)references categorias(idCategoria));


INSERT categorias(nombre)  
    VALUES ('Default');
