using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using DDD.Domain.Models;

namespace DDD.Application.ViewModels
{
    public class UsuarioHistoricoEscolarViewModel
    {
        [Key]
        public int? Id { get; set; }

        [Required(ErrorMessage = "O nome é requerido")]
        [MinLength(5)]
        [MaxLength(50)]
        [DisplayName("Nome")]
        public string Nome { get; set; }
        public int UsuarioId { get; protected set; }
        public int AnexoId { get; protected set; }
        //public virtual UsuarioViewModel Usuario { get; protected set; }
        //public virtual AnexoViewModel Anexo { get; protected set; }
    }
}
