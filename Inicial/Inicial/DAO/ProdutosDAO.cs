using Inicial.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inicial.DAO
{
    public class ProdutosDAO
    {
        public void Adiciona(Produto produto)
        {
            using (var context = new EstoqueContext())
            {
                context.Produtoes.Add(produto);
                context.SaveChanges();
            }
        }

        public IList<Produto> Lista()
        {
            using (var contexto = new EstoqueContext())
            {
                return contexto.Produtoes.Include("Categoria").ToList();
            }
        }

        public Produto BuscaPorId(int id)
        {
            using (var contexto = new EstoqueContext())
            {
                return contexto.Produtoes.Include("Categoria")
                    .Where(p => p.Id == id)
                    .FirstOrDefault();
            }
        }

        public void Atualiza(Produto produto)
        {
            using (var contexto = new EstoqueContext())
            {
                contexto.Entry(produto).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }
    }

}