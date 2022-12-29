using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;

namespace SistemaClientes.Services.Model
{
    public class ClientePostModel
    {
        [MinLength(6, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [MaxLength(150, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe seu nome.")]
        public string Nome { get; set; }

        [MinLength(11, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe seu Cpf.")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Por favor, informe seu telefone.")]
        public string Telefone { get; set; }

        [EmailAddress(ErrorMessage = "Por favor, informe o email válido.")]
        [Required(ErrorMessage = "Por favor, informe seu email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Por favor, informe sua data de nascimento.")]
        public string DataNascimento { get; set; }

    }
}
