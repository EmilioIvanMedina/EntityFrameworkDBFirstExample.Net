begin tran
use pruebas
create table EMPLEADO (
	IdEmpleado int primary key IDENTITY (1, 1) not null,
	Nombre varchar(80) not null,
	Correo nvarchar(80) not null,
	Direccion nvarchar(120) not null,
	Telefono nvarchar(40) null
)

commit tran