IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = 'TrenCR')
begin
EXEC msdb.dbo.sp_delete_database_backuphistory @database_name = N'TrenCR'
ALTER DATABASE TrenCR SET  SINGLE_USER WITH ROLLBACK IMMEDIATE
USE [master] 
DROP DATABASE TrenCR

end

CREATE database TrenCR
go


use TrenCR
go

CREATE TABLE  Perfil(
Id_Perfil integer not null primary key,
nombre varchar(50) not null
);

INSERT INTO Perfil(Id_Perfil, nombre) VALUES(1, 'Administrador'), (2, 'Usuario')


CREATE TABLE Usuario(
id integer IDENTITY (1, 1) not null PRIMARY KEY,
idPerfil int not null foreign key references Perfil(Id_Perfil),
nombre varchar(100) not null,
apellidos varchar(200) not null,
UserName varchar(40) not null UNIQUE,
password varchar(150) not null,
estado bit not null default(1)
);

INSERT INTO Usuario (idPerfil, nombre, apellidos, UserName, password)
values(1, 'Jose', 'Solano Garita', 'Admin', '12345');

INSERT INTO Usuario (idPerfil, nombre, apellidos, UserName, password)
values(2, 'Johnny', 'Depp', 'Jdepp', '12345');

CREATE TABLE Ruta(
id integer not null PRIMARY KEY identity(1,1),
nombre varchar(150) not null,
capacidad int not null,
estado bit not null default(1)
);


CREATE TABLE Estacion(
id integer not null PRIMARY KEY identity(1,1),
nombre varchar(150) not null,
estado bit not null default(1)
);

CREATE TABLE Estacion_Ruta(
id integer not null PRIMARY KEY identity(1,1),
idRuta integer not null FOREIGN KEY REFERENCES Ruta (id),
idEstacion integer not null FOREIGN KEY REFERENCES Estacion (id),
estado bit not null default(1),
);

CREATE TABLE Horario(
id integer not null PRIMARY KEY identity(1,1),
idEstacionRuta integer not null FOREIGN KEY REFERENCES Estacion_Ruta (id),
hora time not null,
estado bit not null default(1),
);


CREATE TABLE Boleto (
id integer not null PRIMARY KEY identity(1,1),
idHorario integer not null FOREIGN KEY REFERENCES Horario (id),
idUsuario integer not null FOREIGN KEY REFERENCES Usuario (id),
asiento integer not null,
fecha datetime not null default(getdate()),
hora time not null,
estado bit not null default(1),
)

 