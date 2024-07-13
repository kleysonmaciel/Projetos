namespace MyApp.Models
{
    public class Produto{
        public int id { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public decimal preco { get; set; }
        public int quantidade_Estoque { get; set; }
        public string imagem_url { get; set; }
    }
}