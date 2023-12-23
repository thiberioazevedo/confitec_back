using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using DDD.Domain.Models;

namespace DDD.Application.ViewModels
{
    public class UsuarioViewModel
    {
        [Key]
        public int? Id { get; set; }

        [Required(ErrorMessage = "O nome é requerido")]
        [MinLength(2)]
        [MaxLength(20)]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O sobreNome é requerido")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Sobrenome")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "O email é requerido")]
        [EmailAddress]
        [MaxLength(50)]
        [DisplayName("Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A data de nascimento é requerida")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        [DisplayName("Data de nascimento")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "A escolaridade é requerida")]
        [DisplayFormat(ApplyFormatInEditMode = true)]
        [DisplayName("EscolaridadeId")]
        public int EscolaridadeId { get; set; }

        public EscolaridadeViewModel Escolaridade { get; set; }
        public virtual ICollection<UsuarioHistoricoEscolarViewModel> UsuarioHistoricoEscolarCollection { get; private set; }
    }
}
