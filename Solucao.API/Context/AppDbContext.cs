using Microsoft.EntityFrameworkCore;
using Solucao.Domain.Models;
using System;
using System.Linq;

namespace Solucao.API.Context
{
    public class AppDbContext : DbContext
    {

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { }

       
    }
}
