using System;
using DDD.Domain.Core.Events;

namespace DDD.Domain.Events
{
    public class UsuarioRegisteredEvent : Event
    {
        public UsuarioRegisteredEvent(int id, string name, string email, DateTime birthDate)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            AggregateId = id;
        }
        public int Id { get; set; }

        public string Name { get; private set; }

        public string Email { get; private set; }

        public DateTime BirthDate { get; private set; }
    }
}
