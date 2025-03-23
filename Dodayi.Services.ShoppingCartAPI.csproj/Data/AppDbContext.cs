using Dodayi.Services.ShoppingCartAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.PortableExecutable;

namespace Dodayi.Services.ShoppingCartAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<CartHeader> CartHeaders { get; set; }
        public DbSet<CartDetails> CartDetails { get; set; }

    }
}
