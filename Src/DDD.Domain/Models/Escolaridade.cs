using System;
using DDD.Domain.Core.Models;

namespace DDD.Domain.Models
{
    public class Escolaridade : EntityAudit
    {
        public Escolaridade(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        // Empty constructor for EF
        protected Escolaridade() { }
        public string Nome { get; private set; }
    }
}
