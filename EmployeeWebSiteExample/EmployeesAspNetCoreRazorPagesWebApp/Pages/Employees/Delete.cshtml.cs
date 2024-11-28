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
    public class DeleteModel : PageModel
    {
        private readonly EFDataAccess.Data.PruebasContext _context;

        public DeleteModel(EFDataAccess.Data.PruebasContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Empleado Empleado { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados.FirstOrDefaultAsync(m => m.IdEmpleado == id);

            if (empleado == null)
            {
                return NotFound();
            }
            else
            {
                Empleado = empleado;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado != null)
            {
                Empleado = empleado;
                _context.Empleados.Remove(Empleado);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
