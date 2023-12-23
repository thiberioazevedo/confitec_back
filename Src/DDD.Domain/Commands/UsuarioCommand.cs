using System;
using DDD.Domain.Core.Commands;
using DDD.Domain.Models;

namespace DDD.Domain.Commands
{
    public abstract class UsuarioCommand : Command
    {
        public int Id { get; protected set; }
        public string Nome { get; protected set; }
        public string Sobrenome { get; protected set; }
        public string Email { get; protected set; }
        public DateTime DataNascimento { get; protected set; }
        public int EscolaridadeId { get; protected set; }
        public Escolaridade Escolaridade { get; protected set; }
    }
}
