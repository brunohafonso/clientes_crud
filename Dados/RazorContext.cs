using razorpages.Models;
using Microsoft.EntityFrameworkCore;

namespace razorpages.Dados
{
    public class RazorContext : DbContext 
    {
       public RazorContext(DbContextOptions options) : base(options) { }

       public DbSet<Cliente> Clientes { get; set; }
    }
}