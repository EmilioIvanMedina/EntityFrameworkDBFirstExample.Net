using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EFDataAccess.Data;
using EFDataAccess.Models;

namespace EmployeesAspNetCoreRazorPagesWebApp.Pages.Employees
{
    public class IndexModel : PageModel
    {
        private readonly EFDataAccess.Data.PruebasContext _context;

        public IndexModel(EFDataAccess.Data.PruebasContext context)
        {
            _context = context;
        }

        public IList<Empleado> Empleado { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Empleado = await _context.Empleados.ToListAsync();
        }
    }
}
