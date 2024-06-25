CREATE DATABASE db_Inventario;

USE db_Inventario;

CREATE TABLE Inventario (
    ID INT PRIMARY KEY IDENTITY(1,1),
    CodigoBarras VARCHAR(50),
    NombreProducto VARCHAR(100),
    Stock INT,
    PrecioUnitario DECIMAL(10,2),
    FechaIngreso DATETIME DEFAULT GETDATE()
);

INSERT INTO Inventario (CodigoBarras, NombreProducto, Stock, PrecioUnitario)
VALUES ('123456789', 'Producto Ejemplo', 100, 19.99);

select * from Inventario;

/* Insertar */
CREATE PROCEDURE InsertarProducto
    @P_CodigoBarras VARCHAR(50),
    @P_NombreProducto VARCHAR(100),
    @P_Stock INT,
    @P_PrecioUnitario DECIMAL(10,2)
AS
BEGIN
    INSERT INTO Inventario (CodigoBarras, NombreProducto, Stock, PrecioUnitario)
	VALUES (@P_CodigoBarras, @P_NombreProducto, @P_Stock, @P_PrecioUnitario);
END;


EXEC InsertarProducto '123456789', 'Producto Ejemplo', 100, 19.99;

/* Consultar */
Create PROC spConsulProducto
(@P_Accion SMALLINT,
@P_Texto varchar(10) = NULL)
AS
BEGIN
	
	IF @P_Accion = 1
	BEGIN
		SELECT id, 
			CodigoBarras,
			NombreProducto,
			Stock,
			PrecioUnitario,
			FORMAT(FechaIngreso ,'dd/MM/yyyy') AS FechaIngreso 
		From Inventario 
	END
	ELSE IF @P_Accion = 2
	BEGIN
		SELECT id, 
			CodigoBarras,
			NombreProducto,
			Stock,
			PrecioUnitario,
			FORMAT(FechaIngreso ,'dd/MM/yyyy') AS FechaIngreso 
		From Inventario 
		WHERE NombreProducto LIKE '%' + @P_Texto + '%'
	END
	ELSE IF @P_Accion = 3
	BEGIN
		SELECT id, 
			CodigoBarras,
			NombreProducto,
			Stock,
			PrecioUnitario,
			FORMAT(FechaIngreso ,'dd/MM/yyyy') AS FechaIngreso 
		From Inventario 
		WHERE CodigoBarras LIKE '%' + @P_Texto + '%'
	END
END

spConsulProducto @P_Accion = 1
spConsulProducto @P_Accion = 2, @P_Texto = 'Ejemplo'
spConsulProducto @P_Accion = 3, @P_Texto = '7500435233590'


/* Modificar */
CREATE PROC spModifProducto
@P_CodigoBarras VARCHAR(50),
@P_NombreProducto VARCHAR(100),
@P_Stock INT,
@P_PrecioUnitario DECIMAL(10,2)
AS
BEGIN
	SET NOCOUNT ON	

		UPDATE Inventario SET  NombreProducto = @P_NombreProducto,
    							Stock = @P_Stock, 
    							PrecioUnitario = @P_PrecioUnitario
		WHERE CodigoBarras = @P_CodigoBarras

	SET NOCOUNT OFF
END

spModifProducto @P_CodigoBarras =  '123456789',
    	@P_NombreProducto = 'Nuevo Producto',
    	@P_Stock = 50,
    	@P_PrecioUnitario = 5



/* Eliminar */
CREATE PROC spBorrarProducto
(@P_idProducto INT)
AS
BEGIN 
	SET NOCOUNT ON

		DELETE 
		FROM Inventario
		WHERE id  = @P_idProducto

		SET NOCOUNT OFF
END	

spBorrarProducto @P_idProducto = 2


/* Consultar productos en 0 */

CREATE PROCEDURE ObtenerProductosAgotados
AS
BEGIN
    SELECT *
    FROM Inventario
    WHERE Stock <= 0;
END;

EXEC ObtenerProductosAgotados;





CREATE TABLE INTERFACES(
IdInterfaces SMALLINT IDENTITY(1,1) NOT NULL,
Usuario VARCHAR(25) NOT NULL,
Contraseña VARCHAR(25) NOT NULL,
UGuid VARCHAR(50) NOT NULL
CONSTRAINT DF_UGuid_INT DEFAULT (newid()),
DescripInterfaz VARCHAR (50) NOT NULL,
FecRegistro smalldatetime NOT NULL
CONSTRAINT DF_FecRegistro_INT DEFAULT (getdate()),
CONSTRAINT PK_IdInterface_INT PRIMARY KEY(IdInterfaces))


INSERT INTO INTERFACES (Usuario, Contraseña, DescripInterfaz)
				VALUES ('admin','admin','UI c#')

INSERT INTO INTERFACES (Usuario, Contraseña, DescripInterfaz)
				VALUES ('Juan','Juan','python')

SELECT * FROM INTERFACES


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[spValidaInterfaceTOKEN]
(@P_Usuario VARCHAR(25),
 @P_Contra VARCHAR(25),
 @P_Guid VARCHAR(50))
 AS
 BEGIN
	SET NOCOUNT ON

	SELECT 1 AS Resultado
	FROM INTERFACES
	WHERE Usuario = @P_Usuario AND
		  Contraseña = @P_Contra AND
		  UGuid = @P_Guid
	SET NOCOUNT OFF
END

EXEC spValidaInterfaceTOKEN	@P_Usuario = 'admin',
						@P_Contra = 'admin',
						@P_Guid = 'F5B0ABCD-4FD7-41D3-B8C7-E54AB7288422'
							