using Inicial.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inicial.DAO
{
    public class EstoqueContext : DbContext
    {
        public DbSet<Produto> Produtoes { get; set; }

        public DbSet<CategoriaDoProduto> CategoriaDoProdutoes { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Properties.Settings.Default.ConnectionString);
        }

    }
}