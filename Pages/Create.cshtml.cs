using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using razorpages.Dados;
using razorpages.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Extensions.Logging;


namespace razorpages.Pages
{
    public class CreateModel : PageModel
    {
        readonly RazorContext _context;
        
        [TempData]
        public string Mensagem { get; set; }

        private ILogger<CreateModel> Log;

        [BindProperty]
        public Cliente Cliente { get; set; }
        
        public CreateModel(RazorContext context, ILogger<CreateModel> log)
        {
            _context = context;
            Log = log;
        }

        public void OnGet()
        {
            
        }

        public async Task<IActionResult> OnPostAsync() 
        {
            if(!ModelState.IsValid) { return Page(); }

            _context.Clientes.Add(Cliente);
            await _context.SaveChangesAsync();
            var msg = $"Cliente: {Cliente.Nome} adicionado com sucesso !";
            Mensagem = msg;
            Log.LogCritical(msg);
            return RedirectToPagePermanent("/Index");
        }
    }
}