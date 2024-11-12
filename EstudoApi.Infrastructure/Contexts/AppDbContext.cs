using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using EstudoApi.Models;

namespace EstudoApi.Infrastructure.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
    }
}
