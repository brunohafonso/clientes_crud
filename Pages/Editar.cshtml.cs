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
    public class EditarModel : PageModel
    {
       readonly RazorContext _context;
        
       public string Mensagem { get; set; }
       
       [BindProperty]
       public Cliente Cliente { get; set; }
        
        public EditarModel(RazorContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int id) 
        {

            Cliente = await _context.Clientes.FindAsync(id);

            if(Cliente == null) 
            {
               return RedirectToPage("/Index");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid) 
            {
                return Page();
            }

            _context.Attach(Cliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
            
                throw new Exception($"Erro ao atulizar dados do {Cliente.Nome} " + ex.Message);
            }

            Mensagem = $"Cliente: {Cliente.Nome} atualizado com sucesso !";
            return RedirectToPage("./Index");
        }       
    }
}