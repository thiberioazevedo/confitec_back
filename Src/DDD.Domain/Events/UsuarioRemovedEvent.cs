using System;
using DDD.Domain.Core.Events;

namespace DDD.Domain.Events
{
    public class UsuarioRemovedEvent : Event
    {
        public UsuarioRemovedEvent(long id)
        {
            Id = id;
            AggregateId = id;
        }

        public long Id { get; set; }
    }
}
