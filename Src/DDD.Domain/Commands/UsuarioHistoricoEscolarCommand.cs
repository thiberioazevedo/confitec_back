using System;
using DDD.Domain.Core.Commands;
using DDD.Domain.Models;

namespace DDD.Domain.Commands
{
    public abstract class UsuarioHistoricoEscolarCommand : Command
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int UsuarioId { get; set; }
        public int AnexoId { get; set; }
    }
}
