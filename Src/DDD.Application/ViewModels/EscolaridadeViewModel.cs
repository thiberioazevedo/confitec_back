using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DDD.Application.ViewModels
{
    public class EscolaridadeViewModel
    {
        [Key]
        public int? Id { get; set; }

        [Required(ErrorMessage = "O nome é requerido")]
        [MinLength(2)]
        [MaxLength(40)]
        [DisplayName("Nome")]
        public string Nome { get; set; }
    }
}
