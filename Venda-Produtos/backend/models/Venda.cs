namespace ProdutoWeb.Models{
    public class Venda{
        [Key]
        public int id { get; set;}
        [Required]
        public int usuario_id { get; set;}
        [Required]
        public int produto_id { get; set;}
        [Required]
        public int quantidade { get; set;}
        [Required]
        public DateTime data_venda { get; set;}
    }
}