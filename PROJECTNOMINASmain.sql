CREATE DATABASE nomina_systems;

USE nomina_systems;

CREATE TABLE Empresa(
	ID_Empresa			INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Nombre				VARCHAR(100) NOT NULL,
	Razón_social		VARCHAR(100) NOT NULL,
	Dominio_Fiscal		VARCHAR(100)NOT NULL,
	Email				VARCHAR(100) NOT NULL,
	Registro_Patronal	VARCHAR(100) NOT NULL,
	Registro_cont		VARCHAR(100) NOT NULL,
	Inicio_Operaciones	DATE NOT NULL,
	Frec_Pago			VARCHAR(100) NULL
);

select*from Empresa
CREATE TABLE Departamento (
	ID_Departamento INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Nombre			VARCHAR(100) NOT NULL,
	
);

CREATE TABLE Puesto(
	ID_Puesto			INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Nombre				VARCHAR(100) not NULL,
	Nivel				VARCHAR(100)  NULL,
	ID_Empresa			INT NOT NULL, --FK
	ID_Departamento		INT  NULL,--FK
	Salario_Diario		DECIMAL(15,2)  NULL,
	Gerente				Bit null
	CONSTRAINT FK_EMPR_PUESTO
	FOREIGN KEY (ID_Empresa)
	REFERENCES	Empresa (ID_Empresa),
	CONSTRAINT FK_DPTO_PUESTO
	FOREIGN KEY (ID_Departamento)
	REFERENCES	Departamento (ID_Departamento),
);
	

CREATE TABLE Domicilio(
	Id_Dom	INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Cod_Pos	BIGINT  NULL,
	calle	VARCHAR(100)  NULL,
	numero	BIGINT  NULL,
	Colonia	VARCHAR(100)  NULL,
	Mun		VARCHAR(100)  NULL,	
	Estado	VARCHAR(100)  NULL,
);

CREATE TABLE Persona(
	idpersona		int not null IDENTITY(0,1) PRIMARY KEY ,
	CURP			VARCHAR(100)  ,
	Nombre			VARCHAR(100)  NULL,
	Apellido		VARCHAR(100)  NULL,
	Fecha_Nac		DATE  NULL,
	NNS				BIGINT  NULL,
	RFC				VARCHAR(100)  NULL,
	ID_Domicilio	INT  NULL,
	CONSTRAINT FK_DOM_PERSO
	FOREIGN KEY (ID_Domicilio)
	REFERENCES	Domicilio(Id_Dom)
);


CREATE TABLE Empleado( 
	Numero_Empleado	INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Usuario			VARCHAR(100) not null,
	Pass			VARCHAR (100)  NULL,
	Banco			VARCHAR(100)  NULL,
	NoCuenta		BIGINT NULL,
	Activo			BIT  NULL,
	Telefono		BIGINT NULL,
	Fecha_Ingreso	DATE  NULL,
	Mail			VARCHAR(100)  NULL,
	
	--fks
	ID_Empresa		INT   NULL, 
	ID_Departamento	INT  NULL,
	ID_Puesto		INT  NULL,
	CURPfk			int  not NULL,

	CONSTRAINT FK_EMPRESA_EMPL
	FOREIGN KEY (ID_Empresa)
	REFERENCES	Empresa (ID_Empresa),
	CONSTRAINT FK_DPTO_EMPL
	FOREIGN KEY (ID_Departamento)
	REFERENCES	Departamento (ID_Departamento),
	CONSTRAINT FK_PUESTO_EMPL
	FOREIGN KEY (ID_Puesto)
	REFERENCES	Puesto (ID_Puesto),
	CONSTRAINT FK_PERSO_EMPL
	FOREIGN KEY (CURPfk)
	REFERENCES Persona(idpersona)
);



Create TABLE Depto_Empresa_Unique(
ID_AsociativeDEU int IDENTITY(2,2) PRIMARY KEY not null,
ID_Empresat INT null,
ID_Departamentot INT null,
SalarioBase DECIMAL(15,2) not null,
Activo BIT default(1),
CONSTRAINT WHO_EMPRESA
	FOREIGN KEY (ID_Empresat)
	REFERENCES	Empresa (ID_Empresa),
	CONSTRAINT Who_Depto
	FOREIGN KEY (ID_Departamentot)
	REFERENCES	Departamento (ID_Departamento)
);

Create table INCIDENCIAS(
ID_INCIDENCIA BIGINT IDENTITY(1,1) PRIMARY KEY NOT NULL,
Nombre Varchar(40) null,
Valor DECIMAL(15,2) null,
Dias INT null,
Total DECIMAL(15,2),
Identificador VARCHAR(25) null,
FechaInicidencia DATE,
GENERAL BIT
);
 
CREATE TABLE NOMINAS(
ID_NOMINA BIGINT IDENTITY(1,1) PRIMARY KEY NOT NULL,
ID_INCIDENCIAFK BIGINT,
ID_EMPRESAFK INT,
ID_EMPLEADOFK INT,



CONSTRAINT FK_WHO_INCIDENCIA
FOREIGN KEY (ID_INCIDENCIAFK)
REFERENCES	INCIDENCIAS (ID_INCIDENCIA),
CONSTRAINT FK_WHO_EMPRESA
FOREIGN KEY (ID_EMPRESAFK)
REFERENCES	Empresa (ID_Empresa),
CONSTRAINT FK_WHO_EMPLEADO
FOREIGN KEY (ID_EMPLEADOFK)
REFERENCES	Empleado (Numero_Empleado)

)

Create table Nominasfinal(
IDNF int identity(1,1),
idempresa int,
idempleado int,
NombreCompleto varchar(100),
Banco varchar(100),
CURP varchar(100),
NNS BIGINT,
NoCuenta BigInt,
RFC varchar(100),
Puesto varchar(100),
SalarioDiario Decimal(15,2),
TotalPercepciones Decimal(15,2),
TotalDeducciones Decimal(15,2),
TotalIncidencias Decimal(15,2),
TotalPagoNominal Decimal(15,2),
TotalNOMINA Decimal(15,2),
FECHANOMINA DATE

)


--v1 MOtrar todas las incidencias 
--VISTAS *********
CREATE VIEW AA
AS
select a.Numero_Empleado 'numempleado',CONCAT(c.Nombre,' ',c.Apellido) AS 'Nombre Completo',e.Nombre 'Nombre_Incidencia' ,
e.valor'monto',e.dias 'dias',e.Total'total',e.Identificador'identificador',A.ID_Empresa'idepresa',e.FechaInicidencia'fecha'
from empleado a
join Puesto b on a.ID_Puesto = b.ID_Puesto
left join Persona c on a.CURPfk = c.idpersona
left join NOMINAS d on d.ID_EMPLEADOFK = a.Numero_Empleado
left join INCIDENCIAS e on d.ID_INCIDENCIAFK = e.ID_INCIDENCIA
go
if exists (select 1 from sysobjects where name = 'VerName' and type = 'v')
begin
drop view VerName
end
go
create view VerName
as
select CONCAT(a.Nombre ,' ', a.Apellido)'fullname' ,b.Usuario 'useroa', b.Pass 'contra',b.ID_Puesto 'puestillo'
from persona a
join empleado b
on  a.idpersona = b.CURPfk 
where b.Activo = 1
go
if exists (select 1 from sysobjects where name = 'VerEmp' and type = 'v')
begin
drop view VerEmp
end
go
CREATE view VerEmp
as
select b.Numero_Empleado 'idempleado' , CONCAT(a.Nombre,' ',a.Dominio_Fiscal) 'nombre' , b.Usuario 'useroa', b.Pass 'contra'
from Empresa a 
join Empleado b on a.ID_Empresa = b.ID_Empresa

go
if exists (select 1 from sysobjects where name = 'VerEmpleados' and type = 'v')
begin
drop view VerEmpleados
end
go
create view VerEmpleados
as
select a.Nombre 'Empresa',b.ID_Empresa 'ID_Empresa',CONCAT(c.Nombre,' ',c.Apellido)'Nombre_Empleado',
ISNULL(d.Nombre,'Sin Departamento') 'Departamento',e.Nombre 'Puesto',b.Activo  'Activo',b.Usuario'Usuario',b.Pass 'Contraseña'
from Empresa a join
Empleado b on b.ID_Empresa = a.ID_Empresa join
 Persona c on c.idpersona = b.CURPfk left join 
 Departamento d on  b.ID_Departamento = d.ID_Departamento left join
 Puesto e on b.ID_Puesto = e.ID_Puesto
 go
if exists (select 1 from sysobjects where name = 'VerParaPagar' and type = 'v')
begin
drop view VerParaPagar
end
go
create view VerParaPagar
as
select a.Nombre 'Empresa',b.ID_Empresa 'ID_Empresa',a.Frec_Pago 'frecuencia',CONCAT(c.Nombre,' ',c.Apellido)'Nombre_Empleado',
b.Numero_Empleado'idemp'
from Empresa a join
Empleado b on b.ID_Empresa = a.ID_Empresa join
 Persona c on c.idpersona = b.CURPfk 

 go

 

if exists (select 1 from sysobjects where name = 'VerNominaGeneral' and type = 'v')
begin
drop view VerNominaGeneral
end
go


Create view VerNominaGeneral
 as
 select NombreCompleto'NOMBRE_EMPLEADO',Banco 'BANCO',CURP 'CURP',NNS 'NUMERO_SEGURO_SOCIAL',NoCuenta'NUMERO_DE_CUENTA',
 RFC'RFC',Puesto'PUESTO',SalarioDiario'SALARIO_DIARIO',TotalPercepciones'TOTAL_PERCEPCIONES',
 TotalDeducciones 'TOTAL_DEDUCCIONES',TotalIncidencias 'TOTAL_INCIDENCIAS',TotalPagoNominal 'TOTAL_PAGO_NOMINAL',TotalNOMINA 'TOTAL',
 FECHANOMINA 'FECHA' ,idempresa 'IDEMPRESA',idempleado 'IDEMPLEADO'
 From Nominasfinal
 go

Create view VerNominaGeneral2
 as
 select a.NombreCompleto'NOMBRE_EMPLEADO',a.Banco 'BANCO',a.CURP 'CURP',a.NNS 'NUMERO_SEGURO_SOCIAL',a.NoCuenta'NUMERO_DE_CUENTA',
 a.RFC'RFC',a.Puesto'PUESTO',a.SalarioDiario'SALARIO_DIARIO',a.TotalPercepciones'TOTAL_PERCEPCIONES',
 a.TotalDeducciones 'TOTAL_DEDUCCIONES',a.TotalIncidencias 'TOTAL_INCIDENCIAS',a.TotalPagoNominal 'TOTAL_PAGO_NOMINAL',a.TotalNOMINA 'TOTAL',
 a.FECHANOMINA 'FECHA' ,a.idempresa 'IDEMPRESA',a.idempleado 'IDEMPLEADO',b.ID_Departamento 'iddepto',c.Nombre'NAMEDEPTO'
 From Nominasfinal a left join
 Empleado b on a.idempleado = b.Numero_Empleado
 left join Departamento c on c.ID_Departamento = b.ID_Departamento

 go

create view VerEmpleadosGerentito
as
select CONCAT(d.Nombre, ' ',d.Apellido)'NombreCompleto',ISNULL(a.Nombre,'Sin Departamento') 'Departamento',a.ID_Departamento 'id_dpto',b.Nombre'Puesto',b.Nivel 'Nivel',c.ID_Empresa 'idemp', b.Salario_Diario 'Salario_diario',
		d.Fecha_Nac'Fecha_Nacimiento', c.Fecha_Ingreso'Fecha_Ingreso',c.Usuario 'Usuario'
		
	from Empleado c left join
	Puesto b on c.ID_Puesto = b.ID_Puesto
	left join Persona d on c.CURPfk = d.idpersona
	left join Departamento a on c.ID_Departamento = a.ID_Departamento
	where c.Activo = 1

	
	

	go

create view VerDeptoGerente
as
select a.Numero_Empleado 'numempl',b.Nombre'nombredepto',b.ID_Departamento'iddepto'

from empleado a left join
Departamento b on a.ID_Departamento = b.ID_Departamento
go

create view verIdEmpleado
as
select Numero_Empleado 'numeemp',Usuario'usero',ID_Departamento'iddepto'
from Empleado

go
create view empleados
as
select a.Numero_Empleado 'Idempleado',c.Nombre 'Nombre', b.Salario_Diario 'salario', b.Nombre 'nombrep', b.ID_Puesto 'idp', a.ID_Empresa 'idd' from Empleado a
join Puesto b on a.ID_Puesto = b.ID_Puesto
join Persona c on a.CURPfk = c.idpersona
go
--VISTAS ********* 
-- TRIGGERS *********************************


create trigger tEmpleados
on Empleado
instead of delete
as
begin
declare @id int
select @id = Numero_Empleado
from deleted
update Empleado set Activo = 0 where Numero_Empleado = @id
end

create trigger tmodify
on v
for update
as
begin
declare @comision int
select @comision = Numero_Empleado
from inserted
update Empleado set Activo = 0 where Numero_Empleado = @id
end