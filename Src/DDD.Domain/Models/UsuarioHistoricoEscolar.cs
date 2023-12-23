using System;
using DDD.Domain.Core.Models;

namespace DDD.Domain.Models
{
    public class UsuarioHistoricoEscolar : EntityAudit
    {
        public UsuarioHistoricoEscolar(int id, int usuarioId, int anexoId, string nome)
        {
            Id = id;
            UsuarioId = usuarioId;
            AnexoId = anexoId;
            Nome = nome;
        }

        public UsuarioHistoricoEscolar(int usuarioId, int anexoId, string nome)
        {
            UsuarioId = usuarioId;
            AnexoId = anexoId;
            Nome = nome;
        }

        // Empty constructor for EF
        protected UsuarioHistoricoEscolar() { }
        public string Nome { get; protected set; }
        public int UsuarioId { get; protected set; }
        public int AnexoId { get; protected set; }
        public virtual Usuario Usuario { get; protected set; }
        public virtual Anexo Anexo { get; protected set; }

        
    }
}
