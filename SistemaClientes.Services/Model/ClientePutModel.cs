using System.ComponentModel.DataAnnotations;

namespace SistemaClientes.Services.Model
{
    public class ClientePutModel
    {
        [Required(ErrorMessage = "Por favor, informe o id da empresa.")]
        public Guid IdCliente { get; set; }

        [Required(ErrorMessage = "Por favor, informe seu telefone.")]
        public string Telefone { get; set; }

        [EmailAddress(ErrorMessage = "Por favor, informe um mail válido.")]
        [Required(ErrorMessage = "Por favor, informe seu email.")]
        public string Email { get; set; }
    }
}
