using System.ComponentModel.DataAnnotations;

namespace CrudProdutos
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O título é obrigatório.")]
        public required string Titulo { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatória.")]
        public required string Descricao { get; set; }

        [Required(ErrorMessage = "O preço é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero.")]
        public required decimal Preco { get; set; }

        [Required(ErrorMessage = "O estoque é obrigatório.")]
        [Range(0, int.MaxValue, ErrorMessage = "O estoque deve ser um número positivo.")]
        public required int Estoque { get; set; }

        public string? Fotos { get; set; }
    }
}