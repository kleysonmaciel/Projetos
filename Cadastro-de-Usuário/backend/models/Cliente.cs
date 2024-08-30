namespace ClienteApi.Models{
    public class Cliente{
        public int id{ get; set; }
        public string nome  { get; set; }
        public string sobrenome { get; set; }
        public string email { get; set; }
        public string cpf { get; set; }
        public string endereco { get; set; }
        public string cep { get; set; }
    }
}