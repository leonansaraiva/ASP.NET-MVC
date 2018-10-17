using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Inicial.Models
{
    public class Produto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 5, ErrorMessage = "Must have a minimum length of 5.")]
        public String Nome { get; set; }

        [Range(0.0, 10000.0)]
        public float Preco { get; set; }

        public CategoriaDoProduto Categoria { get; set; }

        public int? CategoriaId { get; set; }

        public String Descricao { get; set; }

        public int Quantidade { get; set; }
    }
}