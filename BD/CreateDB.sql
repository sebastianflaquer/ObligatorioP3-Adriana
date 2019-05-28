create database ObligatorioP3_2;

create table Viviendas(
	Id int PRIMARY KEY,
	Habilitada bit not null,
	Tipo varchar(1) check(Tipo in('N', 'U')) not null,
	Estado varchar(12) check(Rol in('Recibida', 'Habilitada', 'Inhabilitada', 'Sorteada')),
	Calle varchar(150) not null,
	Numero varchar(20) not null,
	Barrio varchar(60) REFERENCES Barrio not null,
	Descripcion varchar(250) not null,
	Banios int not null,
	Dormitorios int not null,
	Metraje int not null,
	Anio int not null,
	PBaseXMetroCuadrado decimal(12,2) not null,
	PrecioFinal decimal(12,2) not null,
)

create table Barrio(
	Id int PRIMARY KEY identity, 
	Nombre varchar(60),
	Descripcion varchar(250) not null
)

create table Usuario(
	id int PRIMARY KEY IDENTITY,
	Rol varchar(20) check(Rol in('Jefe', 'Postulante')),
	Nombre varchar(60) not null,
	Cedula varchar(60) not null,
	FechaNac date,
	Email varchar(150) not null,
	Pass varchar(20) not null,
	Salt varchar(60) not null
)

create table Sorteo(

)