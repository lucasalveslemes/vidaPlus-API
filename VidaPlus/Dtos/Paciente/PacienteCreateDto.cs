using System;
using System.ComponentModel.DataAnnotations;

namespace VidaPlus.Dtos.Paciente
{
    public class PacienteCreateDto
    {
        [Required, StringLength(100)]
        public string Nome { get; set; }

        [Required, EmailAddress, StringLength(100)]
        public string Email { get; set; }

        [Required, StringLength(11, MinimumLength = 11)]
        public string CPF { get; set; }

        [Required, StringLength(15)]
        public string Telefone { get; set; }

        [Required, StringLength(150)]
        public string Endereco { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [StringLength(1000)]
        public string Observacoes { get; set; } // opcional, texto livre
    }
}
