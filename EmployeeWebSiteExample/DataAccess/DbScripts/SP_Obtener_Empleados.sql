create procedure sp_obtener_empleados
as
begin
	select IdEmpleado, Nombre, Correo, Direccion, Telefono from EMPLEADO
end