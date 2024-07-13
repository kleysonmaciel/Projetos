namespace ProdutoWeb.Models{
    public class Usuario{
        [key]
        public string id { get; set;}
        [Required]
        public string name { get; set;}
        [Required]
        public string sobrenome { get; set;}
        [Required]
        [EmailAddress]
        public string Email { get; set;}
        [Rquired]
        [StringLength(11)]
        public string cpf { get; set;}
        [Required]
        public string senha_hash { get; set;}
    }
}