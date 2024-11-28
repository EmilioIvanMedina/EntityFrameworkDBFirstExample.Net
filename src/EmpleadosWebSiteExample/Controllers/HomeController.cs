using DataAccess.Repositorio;
using EmpleadosWebSiteExample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Diagnostics;

namespace EmpleadosWebSiteExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmpleadoRepositorio _empleadoRepositorio;

        public HomeController(IEmpleadoRepositorio empleadoRepositorio)
        {
            _empleadoRepositorio = empleadoRepositorio;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ObtenerEmpleados()
        {
            var empleados = await _empleadoRepositorio.ObtenerEmpleados();

            return View(empleados);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
