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
    public class IndexModel : PageModel
    {
        readonly RazorContext _context;

        public IndexModel(RazorContext context)
        {
            _context = context;
        }
        
        [TempData]
        public string Mensagem { get; set; }
        
        public IList<Cliente> Clientes { get; set; }
        
        public async Task OnGetAsync()
        {
            Clientes = await _context.Clientes.AsNoTracking().ToListAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int Id) 
        {
            var cliente = await _context.Clientes.FindAsync(Id);

            if(cliente != null) 
            {
                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}
