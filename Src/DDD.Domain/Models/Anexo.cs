using System;
using System.Collections.Generic;
using DDD.Domain.Core.Models;

namespace DDD.Domain.Models
{
    public class Anexo : EntityAudit
    {
        public Anexo(int id, string nome, string formato, byte[] arquivo)
        {
            Id = id;
            Nome = nome;
            Formato = formato;
            Arquivo = arquivo;
        }

        public Anexo(string nome, string formato, byte[] arquivo)
        {
            Nome = nome;
            Formato = formato;
            Arquivo = arquivo;
        }

        // Empty constructor for EF
        protected Anexo() { }
        public string Nome { get; private set; }
        public string Formato { get; private set; }
        public byte[] Arquivo { get; private set; }
        public virtual ICollection<UsuarioHistoricoEscolar> UsuarioHistoricoEscolarCollection { get; private set; }
    }
}
