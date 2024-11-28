using DataAccess.Configuracion;
using DataAccess.Entidades;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Repositorio
{
    public class EmpleadoRepositorio : IEmpleadoRepositorio
    {
        private readonly ConnectionConfiguration _connexion;
        public EmpleadoRepositorio(IOptions<ConnectionConfiguration> connexion)
        {
            _connexion = connexion.Value;
        }

        public async Task<List<Empleado>> ObtenerEmpleados()
        {
            var empleados = new List<Empleado>();

            using(var connection = new SqlConnection(_connexion.CadenaSQL))
            {
                connection.Open();
                var command = new SqlCommand("sp_obtener_empleados", connection);
                command.CommandType = CommandType.StoredProcedure;

                using (var dataReader = await command.ExecuteReaderAsync())
                {
                    while (await dataReader.ReadAsync())
                    {
                        empleados.Add(
                            new Empleado
                            {
                                IdEmpleado = Convert.ToInt32(dataReader["IdEmpleado"]),
                                Nombre = dataReader["Nombre"].ToString(),
                                Correo = dataReader["Correo"].ToString(),
                                Direccion = dataReader["Direccion"].ToString(),
                                Telefono = dataReader["Telefono"].ToString()
                            });
                    }
                }
                connection.Close();
            }    

            return empleados;
        }
    }
}
