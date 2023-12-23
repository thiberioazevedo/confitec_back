using System;
using DDD.Domain.Core.Events;

namespace DDD.Domain.Events
{
    public class AddAnexodEvent : Event
    {
        public AddAnexodEvent(int id, string nome, string formato, byte[] arquivo)
        {
            Nome = nome;
            Formato = formato;
            Arquivo = arquivo;
        }
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Formato { get; set; }

        public byte[] Arquivo { get; set; }
    }
}
