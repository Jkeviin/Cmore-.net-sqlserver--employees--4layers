-- Crear base de datos
CREATE DATABASE DB_Empresa
-- Usar la base de datos
USE DB_Empresa
-- Crear tabla
CREATE TABLE Empleado(
	id_Emp varchar(15) primary key,
	nombre varchar(30) not null,
	apellido varchar(50) not null,
	telefono varchar(15) null,
	salario float
)

-- Insertar resgistros
INSERT INTO Empleado(id_Emp,nombre,apellido,telefono,salario) VALUES
('1094909543','daniel','alberto','717171771',4000000)

--------------------------------------
-- Manejo de variables ( se declara con el @)
-- Definicion de variables
DECLARE @NOM VARCHAR(20)
DECLARE @NOM2 VARCHAR(20)
DECLARE @SALARIO FLOAT
-- Asignacion de variables
-- CON SET / SELECT
SET @NOM = 'Pedro'
SET @SALARIO = 900 
SELECT @NOM2=nombre FROM Empleado WHERE id_Emp='1094909543'

--IMPRIMIR EL VALOR DE UNA VARIABLE
--PRINT / SELECT

-- SELECT (CAPTURAR O IMPRIMIR UN VALOR)

PRINT 'NOMBRE:'+@NOM	
PRINT @NOM2
SELECT @NOM AS NOMBRE
PRINT 'SALARIO:' + CONVERT(VARCHAR(10),@SALARIO)
SELECT @SALARIO AS SALARIO

-- CONDICIONAL
IF (@SALARIO>3000000)
	begin
	SELECT 'Mayor a 3000000'
	SELECT @SALARIO AS SALARIO
	end
ELSE
	SELECT 'Menor a 3000000'


-- Procedimiento almacenado
CREATE PROCEDURE USP_IngresarEmp
-- Parametros de entrada
as
begin
	select * from Empleado
end

CREATE PROCEDURE USP_consultar_emp
-- Parametros de entrada
	@id_Emp varchar(15)
as
begin
	select * from Empleado where id_Emp= @id_Emp
end

CREATE PROCEDURE USP_insertar_emp
-- Parametros de entrada
	@id_Emp varchar(15),
	@nombre_Emp varchar(30),
	@apellido_Emp varchar(50),
	@telefono_Emp varchar(15),
	@salario_Emp float
as
begin
	--select * from Empleado where id_Emp= @id_Emp
	insert into Empleado(id_Emp,nombre,apellido,telefono,salario) values(@id_Emp,@nombre_Emp,@apellido_Emp,@telefono_Emp,@salario_Emp)
end

--Procedimiento actulizar
CREATE PROCEDURE USP_actualizar_emp
	@nombre_Emp varchar(30),
	@apellido_Emp varchar(50),
	@telefono_Emp varchar(15),
	@salario_Emp float,
	@id_Emp varchar(15)
as
begin
	UPDATE Empleado
	SET nombre=@nombre_Emp,
		apellido=@apellido_Emp,
		telefono=@telefono_Emp,
		salario= @salario_Emp 
	WHERE id_Emp = @id_Emp	
end

CREATE PROCEDURE USP_eliminar_emp
	@id_Emp varchar(15)
as
begin
	DELETE FROM Empleado
	WHERE id_Emp = @id_Emp	
end




--ejecutar un procedimiento
execute USP_IngresarEmp
execute USP_consultar_emp '1'
execute USP_insertar_emp '1','Juan' ,'Sanchez','34567788',1000000
execute USP_actualizar_emp 'Sebastian' ,'Marin','345000000',2000000,'1'
execute USP_eliminar_emp '1'