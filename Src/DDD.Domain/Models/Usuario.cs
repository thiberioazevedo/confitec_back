using System;
using System.Collections.Generic;
using DDD.Domain.Core.Models;

namespace DDD.Domain.Models
{
    public class Usuario : EntityAudit
    {
        public Usuario(int id, string nome, string sobrenome, string email, DateTime birthDate, int escolaridadeId)
        {
            SetThis(id, nome, sobrenome, email, birthDate, escolaridadeId);
        }

        public Usuario(string nome, string sobrenome, string email, DateTime birthDate, int escolaridadeId)
        {
            SetThis(null, nome, sobrenome, email, birthDate, escolaridadeId);
        }

        void SetThis(int? id, string nome, string sobrenome, string email, DateTime birthDate, int escolaridadeId)
        {
            Id = id;
            Nome = nome;
            SobreNome = sobrenome;
            Email = email;
            DataNascimento = birthDate;
            EscolaridadeId = escolaridadeId;

            if (Escolaridade != null && Escolaridade.Id > 0)
            {
                EscolaridadeId = (int)Escolaridade.Id;
                Escolaridade = null;
            }
            else
                EscolaridadeId = escolaridadeId;
        }

        // Empty constructor for EF
        protected Usuario() { }
        public string Nome { get; private set; }
        public string SobreNome { get; private set; }
        public string Email { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public int EscolaridadeId { get; private set; }
        public virtual Escolaridade Escolaridade { get; private set; }
        public virtual ICollection<UsuarioHistoricoEscolar> UsuarioHistoricoEscolarCollection { get; private set; }
    }
}
