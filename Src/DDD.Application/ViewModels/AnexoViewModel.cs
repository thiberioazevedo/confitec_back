using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DDD.Application.ViewModels
{
    public class AnexoViewModel
    {
        [Key]
        public int? Id { get; set; }

        [Required(ErrorMessage = "O nome é requerido")]
        [MinLength(2)]
        [MaxLength(20)]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O formato é requerido")]
        [MinLength(3)]
        [MaxLength(4)]
        [DisplayName("Formato")]
        public string Formato { get; set; }

        [Required(ErrorMessage = "O formato é requerido")]
        public byte[] Arquivo { get; set; }
    }
}
