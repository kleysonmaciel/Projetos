using System.ComponentModel.DataAnnotations;

namespace ProdutoWeb.Models
{
    public class Produto{
        [key]
        public int id { get; set; }
        [Required]
        public string nome { get; set; }
        [Required]
        public string descricao { get; set; }
        [Required]
        public decimal preco { get; set; }
        [Required]
        public int quantidade_estoque { get; set; }
        [Required]
        public string imagem_url { get; set; }
    }
}