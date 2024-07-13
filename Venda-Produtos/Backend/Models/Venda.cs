namespace MyApp.Models{
    public class Venda{
        public int id { get; set;}
        public int usuario_id { get; set;}
        public int produto_id { get; set;}
        public int quantidade { get; set;}
        public DateTime data_venda { get; set;}
    }
}