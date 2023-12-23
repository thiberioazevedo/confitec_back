using System;
using DDD.Domain.Core.Events;

namespace DDD.Domain.Events
{
    public class UsuarioUpdatedEvent : Event
    {
        public UsuarioUpdatedEvent(long id, string name, string email, DateTime birthDate)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            AggregateId = id;
        }
        public long Id { get; set; }

        public string Name { get; private set; }

        public string Email { get; private set; }

        public DateTime BirthDate { get; private set; }
    }
}
