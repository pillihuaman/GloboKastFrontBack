--create database globalKas;
   use globalKas;
   create table rol
	( 
	idrol int primary key identity(1,1), 
	descripcion varchar(200),
	estado bit 
	)

insert into  rol (descripcion,estado) values ('votante',1);
insert into  rol (descripcion,estado) values ('administrador',2);
 create table Usuario
 (
 IDUSUARIO int primary key identity(1,1),
 CORREO varchar(200),
 PASSWORD VARCHAR(MAX),
 IDROL INT  ,
 DESCRIPCION  VARCHAR(200),
 ESTADO BIT,
 FECHACREACION DATETIME,
 
 FOREIGN KEY (idrol) REFERENCES rol(idrol)
 )
 --insert  into usuario(CORREO,PASSWORD,IDROL,DESCRIPCION,ESTADO,FECHACREACION)
 --values ('pillihuamanhz@gmail.com','',2,'administrador',1,getdate())
 -- insert  into usuario(CORREO,PASSWORD,IDROL,DESCRIPCION,ESTADO,FECHACREACION)
 --values ('mendelPillihuaman@gmail.com','',1,'votante',1,getdate())
 -- insert  into usuario(CORREO,PASSWORD,IDROL,DESCRIPCION,ESTADO,FECHACREACION)
 --values ('pillihuaman@gmail.com','',1,'votante',1,getdate())
 -- insert  into usuario(CORREO,PASSWORD,IDROL,DESCRIPCION,ESTADO,FECHACREACION)
 --values ('empresaso1@gmail.com','',1,'votante',1,getdate());

  create table cliente(
  idcliente int primary key identity(1,1),
  idusuario int ,
  nombre varchar(200),
  )
  insert into cliente(nombre,idusuario) values('maria',1)
  insert into cliente(nombre,idusuario) values('Pedro camacho',1)
  insert into cliente(nombre,idusuario) values('Rosio mariage',1)
  insert into cliente(nombre,idusuario) values('angela rodriguez',1)
  insert into cliente(nombre,idusuario) values('maripia morena',1)
  insert into cliente(nombre,idusuario) values('zarmir hurtado',2)
  insert into cliente(nombre,idusuario) values('claudia paredes',1)
  insert into cliente(nombre,idusuario) values('felix jose',1)
  insert into cliente(nombre,idusuario) values('wclaudia paredes',1)
  insert into cliente(nombre,idusuario) values('Rodriguez felix jose',1)


   create table calificacion
   (
     idCalificacion int primary key identity(1,1),
     idcliente int ,
     punto int ,
	 fechacreacion datetime ,
	 FOREIGN KEY (idcliente) REFERENCES cliente(idcliente)
   )
    
	 insert into calificacion(idcliente,punto,fechacreacion) 
	 values(1,10,getdate())
    insert into calificacion(idcliente,punto,fechacreacion) 
	 values(3,8,getdate())
    insert into calificacion(idcliente,punto,fechacreacion) 
	 values(1,2,getdate())
    insert into calificacion(idcliente,punto,fechacreacion) 
	 values(5,10,getdate())
	  insert into calificacion(idcliente,punto,fechacreacion) 
	 values(5,3,getdate())
	  insert into calificacion(idcliente,punto,fechacreacion) 
	 values(1,7,getdate())
	  insert into calificacion(idcliente,punto,fechacreacion) 
	 values(2,8,getdate())
	  insert into calificacion(idcliente,punto,fechacreacion) 
	 values(6,10,getdate())
	  insert into calificacion(idcliente,punto,fechacreacion) 
	  values(3,8,getdate())
	  insert into calificacion(idcliente,punto,fechacreacion) 
	 values(3,5,getdate())

  
   --PM> add-migration init -Context GloboKasDbContext