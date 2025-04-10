using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CrudProdutosMVC.Models
{

    public class Produto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O título é obrigatório")]
        public required string Titulo { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatória")]
        public required string Descricao { get; set; }

        [Required(ErrorMessage = "O valor é obrigatório")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser positivo")]
        public decimal? Preco { get; set; }

        [Required(ErrorMessage = "O estoque é obrigatório")]
        [Range(0, int.MaxValue, ErrorMessage = "O estoque não pode ser negativo")]
        public required int? Estoque { get; set; }

        public string? Fotos { get; set; }
    }

}
