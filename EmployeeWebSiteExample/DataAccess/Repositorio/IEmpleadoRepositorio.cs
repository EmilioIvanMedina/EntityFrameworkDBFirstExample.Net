using DataAccess.Entidades;

namespace DataAccess.Repositorio
{
    public interface IEmpleadoRepositorio
    {
        Task<List<Empleado>> ObtenerEmpleados();
    }
}
