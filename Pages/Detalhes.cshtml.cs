using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using razorpages.Dados;
using razorpages.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace razorpages.Pages
{
    public class DetalhesModel : PageModel 
    {
        readonly RazorContext _context;

        public DetalhesModel(RazorContext context)
        {
            _context = context;
        }

        public Cliente Cliente { get; set; }

        public async Task<IActionResult> OnGetAsync(int Id) 
        {
            Cliente = await _context.Clientes.FindAsync(Id);

            if(Cliente == null)
            {
                return RedirectToPage("/Index");
            }

            return Page();
        }
    }
}