USE nomina_systems;
go
--departamento >
if exists (select 1 from sysobjects where name = 'sp_Departamento' and type = 'p')
begin
drop procedure sp_Departamento
end
go

CREATE PROCEDURE sp_Departamento(
@Opc char(1),
@NombreDepto				VARCHAR(20)=NULL
)
AS
BEGIN

if @Opc = 'I'
BEGIN
	INSERT INTO Departamento(Nombre)
	VALUES(@NombreDepto);

END
	

	if @Opc='S'
		BEGIN
		SELECT	ID_Departamento 'Clave',
				Nombre 'Nombre Departamento'
		FROM Departamento
		ORDER BY ID_Departamento ASC
		END

		IF @Opc = 'U'
		begin 
		select ID_Departamento 'iddepto'
		from Departamento 
		where Nombre = @NombreDepto
		end

END
GO


-- idpuesto 
if exists (select 1 from sysobjects where name = 'sp_getidpuesto' and type = 'p')
begin
drop procedure sp_getidpuesto
end
go

create procedure sp_getidpuesto(
		@departamento int = null,
		@empresa		int = null,
		@name			varchar(20)=null
)
AS 
BEGIN
		SELECT b.ID_Puesto 'id'
		FROM Depto_Empresa_Unique a
		JOIN Puesto b on a.ID_Departamentot = b.ID_Departamento
		where a.ID_Empresat= @empresa and a.ID_Departamentot = @departamento and b.Nombre = @name
END
go
--Empresa >
if exists (select 1 from sysobjects where name = 'sp_empresa' and type = 'p')
begin
drop procedure sp_empresa
end
go

CREATE PROCEDURE sp_empresa(
	@Opc					char(1),
	@Id_emp					int =null,
	@Nombre					VARCHAR(20)=NULL,
	@Razón_social			VARCHAR(20)=NULL,
	@Dominio_Fiscal			VARCHAR(20)=NULL,
	@Email					VARCHAR(20)=NULL,
	@Registro_Patronal		VARCHAR(20)=NULL,
	@Registro_cont			VARCHAR(20)=NULL,
	@Inicio_Operaciones		DATE= NULL,
	@frecuencia_pago		VARCHAR(40)=NULL
)
AS 
BEGIN
IF @Opc ='I'
	BEGIN
	INSERT INTO Empresa(Nombre,Razón_social,Dominio_Fiscal,Email,Registro_Patronal,Registro_cont,Inicio_Operaciones,Frec_Pago)
	VALUES(@Nombre,				
		   @Razón_social,		
		   @Dominio_Fiscal,		
		   @Email	,			
		   @Registro_Patronal,	
		   @Registro_cont	,	
		   @Inicio_Operaciones,
		   @frecuencia_pago);
	END
		if @Opc='S'
		BEGIN
		SELECT	ID_Empresa 'Clave',
				Nombre 'Nombre Empresa'
		FROM Empresa
		ORDER BY ID_Empresa ASC
		END
		if @Opc='D'
		BEGIN
		DELETE FROM Empresa
		END

		if @Opc = 'M'
		BEGIN
		UPDATE Empresa
		SET Nombre = ISNULL(@Nombre, Nombre), 
		Razón_social = ISNULL(@Razón_social, Razón_social),
		Dominio_Fiscal =  ISNULL(@Dominio_Fiscal, Dominio_Fiscal),
		Email =  ISNULL(@Email, Email),
		Registro_Patronal =  ISNULL(@Registro_Patronal, Registro_Patronal),
		Registro_cont = ISNULL(@Registro_cont, Registro_cont),
		Inicio_Operaciones  = ISNULL(@Inicio_Operaciones, Inicio_Operaciones),
		Frec_Pago = ISNULL( @frecuencia_pago, Frec_Pago)
		WHERE ID_Empresa = @Id_emp
		END

END
GO

--Puesto >

if exists (select 1 from sysobjects where name = 'sp_PuestoGerente' and type = 'p')
begin
drop procedure sp_PuestoGerente
end
go


Create PROCEDURE sp_PuestoGerente(
	@Opc					char(1),
	@ID_Puesto				INT = NULL,
	--to all
	@Id_empresaFK			int =null, -- not null , fk puesto , empleado
	@CURP VARCHAR(20) = null, --curp para persona
	@curpfk int = null,
	--puesto
	@SalarioDiario			SMALLint =null,
	@NombrePuesto VARCHAR(20) = NULL,
	@User VARCHAR(20)= null,
	@pass VARCHAR(20) = NULL,

	--persona stuff
	@idpersona int =null,
	@NombreP varchar(20) = null,
	@ApellidoP varchar(20) = null
	
	)
AS 
BEGIN
   Declare @Gerente bit = 1
   Declare @Activo bit = 1
		IF @Opc ='I' -- insertar  gerente
		BEGIN

		--primero puesto 
		INSERT INTO Puesto(Nombre,Salario_Diario,ID_Empresa) VALUES (@NombrePuesto,@SalarioDiario,@Id_empresaFK)
		--le asignamos a la variable @id puesto la id del puesto que se crea
		select @ID_Puesto = ID_Puesto from Puesto where nombre = @nombrepuesto and ID_Empresa =@Id_empresaFK;
		insert into Persona(CURP,Nombre,Apellido) VALUES (@CURP,@NombreP,@ApellidoP);
		select @curpfk = idpersona from Persona where CURP = @CURP;
		INSERT INTO Empleado(ID_Puesto,Usuario,Pass,Activo,CURPfk,ID_Empresa) VALUES (@ID_Puesto,@User,@pass,@Activo,@curpfk,@Id_empresaFK);
		--y la misma curp a una persona que es practicamente el empleado
		
		END


		if @Opc='S'
		BEGIN
		SELECT	ID_Puesto 'Clave',
				Nombre 'Nombre'
		FROM Puesto
		ORDER BY ID_Puesto ASC
		END
		

END

GO

--login

if exists (select 1 from sysobjects where name = 'sp_LOGIN' and type = 'p')
begin
drop procedure sp_LOGIN
end
go

CREATE PROCEDURE sp_LOGIN(
	@User VARCHAR(20)= null,
	@pass VARCHAR(20) = NULL
)

	AS

	BEGIN
		SELECT Usuario 'User',Pass 'contra',Numero_Empleado 'id'
		 from Empleado 
		 WHERE Usuario = @User AND Pass = @pass;
	END		
	
						
	GO



	if exists (select 1 from sysobjects where name = 'sp_AllInfo' and type = 'p')
begin
drop procedure sp_AllInfo
end
go
CREATE PROCEDURE sp_AllInfo(
    @opc char(1),
	@User VARCHAR(20)= null,
	@pass VARCHAR(20) = NULL
	
)

	AS

	BEGIN


		 if @opc = 'A'
		 begin
		 SELECT a.Numero_Empleado 'numE',a.Usuario 'Usero',a.Pass 'pass',a.Banco 'bank',a.NoCuenta 'acc',
		a.Mail 'mail',a.Telefono 'tel',a.Activo 'active',a.Fecha_Ingreso 'FecI',b.Nombre 'NamePuesto',
		b.Salario_Diario 'SalarioD',b.Nivel 'lvl',c.Nombre 'namep',c.Apellido 'apellido',
		c.CURP 'curp',c.RFC 'rfc',c.NNS 'nns',c.Fecha_Nac 'fnac',d.calle 'calle',d.Colonia 'col',
		d.numero 'numercalle',d.Cod_Pos 'cp',d.Mun 'municipio',d.Estado 'estado',d.numero 'numer',
		b.ID_Puesto 'idpuesto',c.idpersona'idpersona',d.Id_Dom'iddom',e.ID_Departamento'iddepto',e.Nombre'namedepto'
		 from Empleado a left join 
		 Puesto b on a.ID_Puesto = b.ID_Puesto 
		 join Persona c on a.CURPfk = c.idpersona
		 left join Domicilio d on c.ID_Domicilio = d.Id_Dom
		 left join Departamento e on a.ID_Departamento = e.ID_Departamento 
		  WHERE a.Usuario = @User AND a.Pass = @pass;
		 end 

		 if @opc = 'L'
		 begin
		 select b.Nombre 'NombreP'
		 from Empleado a
		 join puesto b
		 on a.ID_Puesto = b.ID_Puesto
		 WHERE a.Usuario = @User AND a.Pass = @pass;
		 end

		if @opc = 'N'
		begin
		select ID_Empresa 'idd'
		from empleado
		where Usuario = @User AND Pass = @pass;
		end

	

		if @opc = 'X'
		begin
		select Numero_Empleado 'idempleado'
		from empleado
		where Usuario = @User AND Pass = @pass;
		end

		if @opc = 'D'
		begin
		Delete from Empleado
		where Usuario = @User AND Pass = @pass;
		end

	END		
	
						
	GO

	--empleados stuff
if exists (select 1 from sysobjects where name = 'sp_Empleados' and type = 'p')
begin
drop procedure sp_Empleados
end
go

CREATE PROCEDURE sp_Empleados(
	@Opc char (1) ,
	@id tinyint = null

)

	AS

	BEGIN
		if @Opc='A' --buscar si existe solo para los gerentes nomina sirve
		BEGIN
		SELECT *
		FROM Empleado 
		where ID_Empresa = @id 
		END

		if @Opc='B' 
		BEGIN
		SELECT Nombre 'name',Razón_social'razonsoc',Dominio_Fiscal'domfis',Email'email',
		Registro_Patronal'regispat',Registro_cont'regiscont',Inicio_Operaciones'inicop',Frec_Pago 'frecuencia'
		FROM Empresa 
		where ID_Empresa = @id 
		END


	END								
	GO

	if exists (select 1 from sysobjects where name = 'sp_Register' and type = 'p')
begin
drop procedure sp_Register
end
go
CREATE PROCEDURE sp_Register(
		@opc				char(1),
		@Id_Dom				INT =  NULL, 
		@Cod_Pos			bigINT = NULL,
		@calle				VARCHAR(100) = NULL,
		@numero				bigINT=  NULL,
		@Colonia			VARCHAR(100)=  NULL,
		@Mun				VARCHAR(100) = NULL,	
		@Estado				VARCHAR(100) = NULL,
		@CURP				VARCHAR(100)= null ,
		@Nombre				VARCHAR(100) = NULL,
		@Apellido			VARCHAR(100)  NULL,
		@Fecha_Nac			DATE = NULL,
		@NNS				bigINT = NULL,
		@RFC				VARCHAR(100)  =NULL,
		@Usuario			VARCHAR(100) =  null,
		@Pass				VARCHAR (100) = NULL,
		@Banco				VARCHAR(100) = NULL,
		@NoCuenta			bigINT= NULL,
		@Telefono			BIGINT =NULL,
		@Fecha_Ingreso		DATE  =NULL,
		@Mail				VARCHAR(100)  = NULL,
		@curpfk				int=null,
		@ID_Empresa			int=null,
		@ID_Departamento	int=null,
		@ID_Puesto			int=null,
		@Numero_Empleado	int= null,
		 @ID_Domicilio		int = null,
		 @idpersona			int= null
)
AS 
BEGIN
   Declare @Activo bit = 1
		IF @Opc ='I' -- insertar  gerente
		BEGIN
		INSERT INTO Domicilio(Cod_Pos, calle,numero, Colonia,Mun, Estado)VALUES(@Cod_Pos,@calle	,@numero,@Colonia,@Mun,@Estado)
		SELECT @id_Dom =Id_Dom from Domicilio WHERE calle= @calle and Colonia = @Colonia 
		INSERT INTO Persona(CURP,Nombre,Apellido,Fecha_Nac,NNS,RFC,ID_Domicilio)VALUES(@CURP,@Nombre,@Apellido,@Fecha_Nac,@NNS,@RFC,@Id_Dom)
		select @curpfk = idpersona from Persona where CURP = @CURP;
		INSERT INTO Empleado(Usuario,Pass,Banco,NoCuenta,Telefono,Fecha_Ingreso,Activo,Mail,CURPfk,ID_Empresa,ID_Departamento,ID_Puesto) VALUES(@Usuario,@Pass,@Banco,@NoCuenta,@Telefono, @Fecha_Ingreso,@Activo ,@Mail,@curpfk,@ID_Empresa,@ID_Departamento,@ID_Puesto)
		END 

		if @Opc = 'M'
		begin
		UPDATE Empleado
		set Banco = ISNULL(@Banco, Banco),
		Usuario = ISNULL(@Usuario, Usuario),Pass = ISNULL(@Pass, Pass),NoCuenta = ISNULL(@NoCuenta, NoCuenta),
		Telefono = ISNULL(@Telefono, Telefono),Mail = ISNULL(@Mail, Mail),Fecha_Ingreso = ISNULL(@Fecha_Ingreso, Fecha_Ingreso),
		Activo = 1 , ID_Puesto = ISNULL(@ID_Puesto,ID_Puesto),ID_Departamento = ISNULL(@ID_Departamento,ID_Departamento)
		where Numero_Empleado = @Numero_Empleado

update Persona
set Nombre = ISNULL(@Nombre,Nombre), Apellido = ISNULL(@Apellido,Apellido),RFC = ISNULL(@RFC,RFC),
NNS = ISNULL(@NNS,NNS), CURP = ISNULL(@CURP,CURP), Fecha_Nac = ISNULL(@Fecha_Nac,Fecha_Nac)
where idpersona = @idpersona

if @ID_Domicilio != 0
begin
update Domicilio
set calle = ISNULL(@calle,calle),Mun =ISNULL(@Mun,Mun),Estado =ISNULL(@Estado,Estado),
numero = ISNULL(@numero,numero) , Colonia = ISNULL(@Colonia,Colonia), Cod_Pos = ISNULL(@Cod_Pos,Cod_Pos)
where Id_Dom = @ID_Domicilio
end

if @ID_Domicilio = 0
begin
insert into Domicilio(calle,Mun,Estado,numero,Colonia,Cod_Pos) VALUES (@calle,@Mun,@Estado,@numero,@Colonia,
@Cod_Pos)
select @ID_Domicilio = Id_Dom from Domicilio where calle = @calle and Cod_Pos = @Cod_Pos and numero = @numero
Update Persona
set ID_Domicilio = @ID_Domicilio
where  idpersona = @idpersona



end
		end

		END
		GO																																																	  
												 																																								  		
--empresa stufff																						
											 															
--agregar departamentos
if exists (select 1 from sysobjects where name = 'sp_DepartamentosMod' and type = 'p')
begin
drop procedure sp_DepartamentosMod
end
go


Create PROCEDURE sp_DepartamentosMod(
	@Opc					char(1),
	@salarioBase decimal(15,2)  = null,
	@id_emp tinyint = null,
	@id_depto smallint = null
	)
AS 
BEGIN
 if @Opc = 'I'
 begin 
 Insert into Depto_Empresa_Unique(ID_Empresat,ID_Departamentot,SalarioBase)
  VALUES (@id_emp,@id_depto,@salarioBase)
 end 

END
GO																							
if exists (select 1 from sysobjects where name = 'sp_DepartamentosMod2' and type = 'p')
begin
drop procedure sp_DepartamentosMod2
end
go



Create PROCEDURE sp_DepartamentosMod2(
	@Opc					char(1),
	@id_emp tinyint = null,
	@id_depto SMALLINT = null

	)
AS 
BEGIN -- b.ID_Empresat != @id_emp 
 if @Opc = 'V'
 begin 
select a.Nombre , b.ID_Empresat 'who'
from Departamento a 
left join Depto_Empresa_Unique b on a.ID_Departamento = b.ID_Departamentot
where b.ID_Empresat != @id_emp 
 end 

  if @Opc = 'S'
 begin
 select b.Nombre 'nombreDepto', a.ID_Empresat ' empresa',a.ID_Departamentot'deptoid',a.SalarioBase 'salario'
 from Depto_Empresa_Unique a 
 join Departamento b on a.ID_Departamentot = b.ID_Departamento
 where ID_Empresat = @id_emp 
 end
  if @Opc = 'L'
 begin
 select b.Nombre 'nombreDepto', a.ID_Empresat ' empresa'
 from Depto_Empresa_Unique a 
 join Departamento b on a.ID_Departamentot = b.ID_Departamento
 where a.ID_Empresat = @id_emp and a.ID_Departamentot = @id_depto
 end

 if @Opc = 'D'
 begin
 delete
 from Depto_Empresa_Unique
 where ID_Empresat = @id_emp  and ID_Departamentot = @id_depto
 end

END
GO		
if exists (select 1 from sysobjects where name = 'sp_Eliminarpuesto' and type = 'p')
begin
drop procedure sp_Eliminarpuesto
end
go
CREATE PROCEDURE sp_Eliminarpuesto(
		@id_departamento		int=null,
		@id_empresa				int =null
	)
	as
	begin
	delete
	from Puesto
	where ID_Empresa = @id_empresa and ID_Departamento = @id_departamento
	end
	go

if exists (select 1 from sysobjects where name = 'sp_Eliminaremp' and type = 'p')
begin
drop procedure sp_Eliminaremp
end
go
CREATE PROCEDURE sp_Eliminaremp(
		@id_empresa int= null,
		@id_dpto int= null	
	)
	AS
	BEGIN
	DELETE
	FROM Empleado
	WHERE ID_Empresa=@id_empresa AND ID_Departamento=@id_dpto
	end
	go

if exists (select 1 from sysobjects where name = 'sp_Puesto' and type = 'p')
begin
drop procedure sp_Puesto
end
go
Create PROCEDURE sp_Puesto(
	@Opc					char(1),
	@NombrePuesto			VARCHAR(20) = NULL,
	@Nivel					DECIMAL(15,2) = null,
	@Id_empresaFK			int =null, -- not null , fk puesto , empleado
	--@SalarioDiario			SMALLint =null,
	@id_departamento		int = null,
	@SALARIO_DPTO			DECIMAL (15,2) = NULL

)			
AS
	BEGIN
		IF @Opc = 'I'
		BEGIN
		SELECT @SALARIO_DPTO = SalarioBase FROM Depto_Empresa_Unique WHERE ID_Departamentot = @id_departamento																		
		INSERT INTO Puesto(Nombre,Nivel,ID_Empresa,ID_Departamento) VALUES (@NombrePuesto,@Nivel,@Id_empresaFK,@id_departamento)										 															
		Update Puesto
		SET  Salario_Diario = @SALARIO_DPTO * @Nivel
		Where Nombre= @NombrePuesto
		END
	END
GO		
																			
if exists (select 1 from sysobjects where name = 'sp_refresh' and type = 'p')
begin
drop procedure sp_refresh
end
go
CREATE PROCEDURE sp_refresh(
	@condicion				int =null,
	@identificador			int = null
)
AS
BEGIN	
			SELECT ID_Puesto 'id',
					Nombre	'Nombre',ID_Departamento'iddepto'
			FROM Puesto
			WHERE ID_DEPARTAMENTO = @condicion AND ID_Empresa = @identificador
			END
			GO



if exists (select 1 from sysobjects where name = 'Sp_INCIDENCIAS' and type = 'p')
begin
drop procedure Sp_INCIDENCIAS
end
go
CREATE PROCEDURE Sp_INCIDENCIAS(
	@Opc			Char(1),
	@Nombre Varchar(40) = null,
	@Valor DECIMAL(15,2) = null,
	@Dias INT = null,
	@Total DECIMAL(15,2),
	@Identificador VARCHAR(25) = null,
	@FechaInicidencia DATE = null,
	@GENERAL BIT = null,
	@ID_INCIDENCIAFK BIGINT = null,
	@ID_EMPRESAFK TINYINT = null,
	@ID_EMPLEADOFK INT = null
)
AS
BEGIN	
			IF @Opc = 'I'
			begin

			insert into INCIDENCIAS(Nombre,Valor,Dias,Total,Identificador,FechaInicidencia,GENERAL) VALUES 
			(@Nombre,@Valor,@Dias,@Total,@Identificador,@FechaInicidencia,@GENERAL)

			select @ID_INCIDENCIAFK = ID_INCIDENCIA from INCIDENCIAS where Nombre = @Nombre and Identificador = @Identificador and
			Total = @Total and GENERAL = @GENERAL

			insert into NOMINAS(ID_INCIDENCIAFK,ID_EMPRESAFK,ID_EMPLEADOFK) SELECT @ID_INCIDENCIAFK,@ID_EMPRESAFK,Numero_Empleado
			from Empleado 
			WHERE ID_Empresa = @ID_EMPRESAFK

			end

			if @Opc = 'D'
			begin
			select @ID_EMPLEADOFK = Numero_Empleado from Empleado wheRE ID_Empresa = @ID_EMPRESAFK
			end

			if @Opc = 'V'
			begin
			insert into INCIDENCIAS(Nombre,Valor,Dias,Total,Identificador,FechaInicidencia,GENERAL) VALUES 
			(@Nombre,@Valor,@Dias,@Total,@Identificador,@FechaInicidencia,@GENERAL)

			select @ID_INCIDENCIAFK = ID_INCIDENCIA from INCIDENCIAS where Nombre = @Nombre and Identificador = @Identificador and
			Total = @Total and GENERAL = @GENERAL

			insert into NOMINAS(ID_INCIDENCIAFK,ID_EMPRESAFK,ID_EMPLEADOFK) VALUES (@ID_INCIDENCIAFK,@ID_EMPRESAFK,@ID_EMPLEADOFK)
			end

			END
			GO

if exists (select 1 from sysobjects where name = 'VerNomina1persona' and type = 'p')
begin
drop procedure VerNomina1persona
end
go
	CREATE PROCEDURE VerNomina1persona(
	@Opc			Char(1),
	@Numero_Empleado	INT =null,
	@ID_Empresa			TINYINT = null,
	@fechainicial varchar(20) = null,
	@fechafinal varchar(20) = null,
	@FrecuenciaPago varchar(20) = null
)
AS
BEGIN	

if @Opc = 'A' -- PARA IR PAGANDO
begin

if @FrecuenciaPago = 'Catorcenal' 
begin
select  CONCAT(MAX(c.Nombre),' ',MAX(c.Apellido)) as'Nombre_Completo', MAX(a.Banco) 'Banco',
MAX(a.NoCuenta) as 'No.Cuenta', MAX(c.NNS) as 'No_Seguro_Social' , MAX(c.RFC)as 'RFC' ,MAX(c.CURP) as'CURP',  MAX(b.Nombre)as 'Puesto',
MAX(b.Salario_Diario)as 'salario_diario' ,
Sum(case when e.Identificador = 'Percepcion' then e.Total END) as 'total_percepciones',
Sum(case when e.Identificador = 'Deduccion' then e.Total END) as 'total_Deducciones',
SUM(e.Total) as 'Total_INcidencias' , MAX(salario_diario) * 14 as 'total_cuatorsena',
MAX(salario_diario) * 14 + SUM(e.Total) as 'TOTAL NOMINA'
from empleado a
join Puesto b on a.ID_Puesto = b.ID_Puesto
left join Persona c on a.CURPfk = c.idpersona
left join NOMINAS d on d.ID_EMPLEADOFK = a.Numero_Empleado
left join INCIDENCIAS e on d.ID_INCIDENCIAFK = e.ID_INCIDENCIA
where a.ID_Empresa = @ID_Empresa and a.Numero_Empleado = @Numero_Empleado and e.FechaInicidencia between @fechainicial and @fechafinal
end

if @FrecuenciaPago = 'Quincenal'
begin
select  CONCAT(MAX(c.Nombre),' ',MAX(c.Apellido)) as'Nombre_Completo', MAX(a.Banco) 'Banco',
MAX(a.NoCuenta) as 'No.Cuenta', MAX(c.NNS) as 'No_Seguro_Social' , MAX(c.RFC)as 'RFC' ,MAX(c.CURP) as'CURP',  MAX(b.Nombre)as 'Puesto',
MAX(b.Salario_Diario)as 'salario_diario' ,
Sum(case when e.Identificador = 'Percepcion' then e.Total END) as 'total_percepciones',
Sum(case when e.Identificador = 'Deduccion' then e.Total END) as 'total_Deducciones',
SUM(e.Total) as 'Total_INcidencias' , MAX(salario_diario) * 15 as 'total_cuatorsena',
MAX(salario_diario) * 15 + SUM(e.Total) as 'TOTAL NOMINA'
from empleado a
join Puesto b on a.ID_Puesto = b.ID_Puesto
left join Persona c on a.CURPfk = c.idpersona
left join NOMINAS d on d.ID_EMPLEADOFK = a.Numero_Empleado
left join INCIDENCIAS e on d.ID_INCIDENCIAFK = e.ID_INCIDENCIA
where a.ID_Empresa = @ID_Empresa and a.Numero_Empleado = @Numero_Empleado and e.FechaInicidencia between @fechainicial and @fechafinal
end

if @FrecuenciaPago = 'Semanal'
begin
select  CONCAT(MAX(c.Nombre),' ',MAX(c.Apellido)) as'Nombre_Completo', MAX(a.Banco) 'Banco',
MAX(a.NoCuenta) as 'No.Cuenta', MAX(c.NNS) as 'No_Seguro_Social' , MAX(c.RFC)as 'RFC' ,MAX(c.CURP) as'CURP',  MAX(b.Nombre)as 'Puesto',
MAX(b.Salario_Diario)as 'salario_diario' ,
Sum(case when e.Identificador = 'Percepcion' then e.Total END) as 'total_percepciones',
Sum(case when e.Identificador = 'Deduccion' then e.Total END) as 'total_Deducciones',
SUM(e.Total) as 'Total_INcidencias' , MAX(salario_diario) * 7 as 'total_cuatorsena',
MAX(salario_diario) * 7 + SUM(e.Total) as 'TOTAL NOMINA'
from empleado a
join Puesto b on a.ID_Puesto = b.ID_Puesto
left join Persona c on a.CURPfk = c.idpersona
left join NOMINAS d on d.ID_EMPLEADOFK = a.Numero_Empleado
left join INCIDENCIAS e on d.ID_INCIDENCIAFK = e.ID_INCIDENCIA
where a.ID_Empresa = @ID_Empresa and a.Numero_Empleado = @Numero_Empleado and e.FechaInicidencia between @fechainicial and @fechafinal
end

if @FrecuenciaPago = 'Mensual'
begin
select  CONCAT(MAX(c.Nombre),' ',MAX(c.Apellido)) as'Nombre_Completo', MAX(a.Banco) 'Banco',
MAX(a.NoCuenta) as 'No.Cuenta', MAX(c.NNS) as 'No_Seguro_Social' , MAX(c.RFC)as 'RFC' ,MAX(c.CURP) as'CURP',  MAX(b.Nombre)as 'Puesto',
MAX(b.Salario_Diario)as 'salario_diario' ,
Sum(case when e.Identificador = 'Percepcion' then e.Total END) as 'total_percepciones',
Sum(case when e.Identificador = 'Deduccion' then e.Total END) as 'total_Deducciones',
SUM(e.Total) as 'Total_INcidencias' , MAX(salario_diario) * 30 as 'total_cuatorsena',
MAX(salario_diario) * 30 + SUM(e.Total) as 'TOTAL NOMINA'
from empleado a
join Puesto b on a.ID_Puesto = b.ID_Puesto
left join Persona c on a.CURPfk = c.idpersona
left join NOMINAS d on d.ID_EMPLEADOFK = a.Numero_Empleado
left join INCIDENCIAS e on d.ID_INCIDENCIAFK = e.ID_INCIDENCIA
where a.ID_Empresa = @ID_Empresa and a.Numero_Empleado = @Numero_Empleado and e.FechaInicidencia between @fechainicial and @fechafinal
end



end

if @Opc = 'B' --ver SOLO todas las incidencias de un empleado
begin
select a.Numero_Empleado 'numempleado',CONCAT(c.Nombre,' ',c.Apellido) AS 'Nombre Completo',e.Nombre 'Nombre_Incidencia' ,
e.valor'monto',e.dias 'dias',e.Total'total'
from empleado a
join Puesto b on a.ID_Puesto = b.ID_Puesto
left join Persona c on a.CURPfk = c.idpersona
left join NOMINAS d on d.ID_EMPLEADOFK = a.Numero_Empleado
left join INCIDENCIAS e on d.ID_INCIDENCIAFK = e.ID_INCIDENCIA
where  a.Numero_Empleado = @Numero_Empleado and e.FechaInicidencia between @fechainicial and @fechafinal
end
			END
			GO
if exists (select 1 from sysobjects where name = 'Ver2Nominapersona' and type = 'p')
begin
drop procedure Ver2Nominapersona
end
go
	CREATE PROCEDURE Ver2Nominapersona(
	@Opc			Char(1),
	@Numero_Empleado	INT =null,
	@ID_Empresa			TINYINT = null,
	@FrecuenciaPago varchar(20) = null
)
AS
BEGIN	

if @Opc = 'A' -- PARA IR PAGANDO
begin

if @FrecuenciaPago = 'Catorcenal' 
begin
select  CONCAT(MAX(c.Nombre),' ',MAX(c.Apellido)) as'Nombre_Completo', MAX(a.Banco) 'Banco',
MAX(a.NoCuenta) as 'No.Cuenta', MAX(c.NNS) as 'No_Seguro_Social' , MAX(c.RFC)as 'RFC' ,MAX(c.CURP) as'CURP',  MAX(b.Nombre)as 'Puesto',
MAX(b.Salario_Diario)as 'salario_diario' ,
Sum(case when e.Identificador = 'Percepcion' then e.Total END) as 'total_percepciones',
Sum(case when e.Identificador = 'Deduccion' then e.Total END) as 'total_Deducciones',
SUM(e.Total) as 'Total_INcidencias' , MAX(salario_diario) * 14 as 'total_cuatorsena',
MAX(salario_diario) * 14 + SUM(e.Total) as 'TOTAL NOMINA'
from empleado a
join Puesto b on a.ID_Puesto = b.ID_Puesto
left join Persona c on a.CURPfk = c.idpersona
left join NOMINAS d on d.ID_EMPLEADOFK = a.Numero_Empleado
left join INCIDENCIAS e on d.ID_INCIDENCIAFK = e.ID_INCIDENCIA
where a.ID_Empresa = @ID_Empresa and a.Numero_Empleado = @Numero_Empleado 
end

if @FrecuenciaPago = 'Quincenal'
begin
select  CONCAT(MAX(c.Nombre),' ',MAX(c.Apellido)) as'Nombre_Completo', MAX(a.Banco) 'Banco',
MAX(a.NoCuenta) as 'No.Cuenta', MAX(c.NNS) as 'No_Seguro_Social' , MAX(c.RFC)as 'RFC' ,MAX(c.CURP) as'CURP',  MAX(b.Nombre)as 'Puesto',
MAX(b.Salario_Diario)as 'salario_diario' ,
Sum(case when e.Identificador = 'Percepcion' then e.Total END) as 'total_percepciones',
Sum(case when e.Identificador = 'Deduccion' then e.Total END) as 'total_Deducciones',
SUM(e.Total) as 'Total_INcidencias' , MAX(salario_diario) * 15 as 'total_cuatorsena',
MAX(salario_diario) * 15 + SUM(e.Total) as 'TOTAL NOMINA'
from empleado a
join Puesto b on a.ID_Puesto = b.ID_Puesto
left join Persona c on a.CURPfk = c.idpersona
left join NOMINAS d on d.ID_EMPLEADOFK = a.Numero_Empleado
left join INCIDENCIAS e on d.ID_INCIDENCIAFK = e.ID_INCIDENCIA
where a.ID_Empresa = @ID_Empresa and a.Numero_Empleado = @Numero_Empleado 
end

if @FrecuenciaPago = 'Semanal'
begin
select  CONCAT(MAX(c.Nombre),' ',MAX(c.Apellido)) as'Nombre_Completo', MAX(a.Banco) 'Banco',
MAX(a.NoCuenta) as 'No.Cuenta', MAX(c.NNS) as 'No_Seguro_Social' , MAX(c.RFC)as 'RFC' ,MAX(c.CURP) as'CURP',  MAX(b.Nombre)as 'Puesto',
MAX(b.Salario_Diario)as 'salario_diario' ,
Sum(case when e.Identificador = 'Percepcion' then e.Total END) as 'total_percepciones',
Sum(case when e.Identificador = 'Deduccion' then e.Total END) as 'total_Deducciones',
SUM(e.Total) as 'Total_INcidencias' , MAX(salario_diario) * 7 as 'total_cuatorsena',
MAX(salario_diario) * 7 + SUM(e.Total) as 'TOTAL NOMINA'
from empleado a
join Puesto b on a.ID_Puesto = b.ID_Puesto
left join Persona c on a.CURPfk = c.idpersona
left join NOMINAS d on d.ID_EMPLEADOFK = a.Numero_Empleado
left join INCIDENCIAS e on d.ID_INCIDENCIAFK = e.ID_INCIDENCIA
where a.ID_Empresa = @ID_Empresa and a.Numero_Empleado = @Numero_Empleado 
end

if @FrecuenciaPago = 'Mensual'
begin
select  CONCAT(MAX(c.Nombre),' ',MAX(c.Apellido)) as'Nombre_Completo', MAX(a.Banco) 'Banco',
MAX(a.NoCuenta) as 'No.Cuenta', MAX(c.NNS) as 'No_Seguro_Social' , MAX(c.RFC)as 'RFC' ,MAX(c.CURP) as'CURP',  MAX(b.Nombre)as 'Puesto',
MAX(b.Salario_Diario)as 'salario_diario' ,
Sum(case when e.Identificador = 'Percepcion' then e.Total END) as 'total_percepciones',
Sum(case when e.Identificador = 'Deduccion' then e.Total END) as 'total_Deducciones',
SUM(e.Total) as 'Total_INcidencias' , MAX(salario_diario) * 30 as 'total_cuatorsena',
MAX(salario_diario) * 30 + SUM(e.Total) as 'TOTAL NOMINA'
from empleado a
join Puesto b on a.ID_Puesto = b.ID_Puesto
left join Persona c on a.CURPfk = c.idpersona
left join NOMINAS d on d.ID_EMPLEADOFK = a.Numero_Empleado
left join INCIDENCIAS e on d.ID_INCIDENCIAFK = e.ID_INCIDENCIA
where a.ID_Empresa = @ID_Empresa and a.Numero_Empleado = @Numero_Empleado 
end



end

if @Opc = 'B' --ver SOLO todas las incidencias de un empleado
begin
select a.Numero_Empleado 'numempleado',CONCAT(c.Nombre,' ',c.Apellido) AS 'Nombre Completo',e.Nombre 'Nombre_Incidencia' ,
e.valor'monto',e.dias 'dias',e.Total'total'
from empleado a
join Puesto b on a.ID_Puesto = b.ID_Puesto
left join Persona c on a.CURPfk = c.idpersona
left join NOMINAS d on d.ID_EMPLEADOFK = a.Numero_Empleado
left join INCIDENCIAS e on d.ID_INCIDENCIAFK = e.ID_INCIDENCIA
where  a.Numero_Empleado = @Numero_Empleado 
end
			END
			GO


if exists (select 1 from sysobjects where name = 'sp_AgregarAnomFIN' and type = 'p')
begin
drop procedure sp_AgregarAnomFIN
end
go

CREATE PROCEDURE sp_AgregarAnomFIN(
@idempresa int,
@idempleado int,
@NombreCompleto varchar(40),
@Banco varchar(40),
@CURP varchar(40),
@NNS BigInt,
@NoCuenta BigInt,
@RFC varchar(40),
@Puesto varchar(40),
@SalarioDiario Decimal(15,2),
@TotalPercepciones Decimal(15,2),
@TotalDeducciones Decimal(15,2),
@TotalIncidencias Decimal(15,2),
@TotalPagoNominal Decimal(15,2),
@TotalNOMINA Decimal(15,2),
@FECHANOMINA DATE
)
AS
BEGIN	
			
INSERT INTO Nominasfinal(idempresa,idempleado,NombreCompleto,Banco,NoCuenta,RFC,Puesto,SalarioDiario,TotalPercepciones,TotalDeducciones,
TotalIncidencias,TotalPagoNominal,TotalNOMINA,FECHANOMINA,NNS,CURP) values (@idempresa,@idempleado,@NombreCompleto,@Banco,@NoCuenta,@RFC,
@Puesto,@SalarioDiario,@TotalPercepciones,@TotalDeducciones,@TotalIncidencias,@TotalPagoNominal,@TotalNOMINA,@FECHANOMINA,@NNS,@CURP)
			END
			GO