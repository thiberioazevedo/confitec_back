using System.Threading;
using System.Threading.Tasks;
using DDD.Domain.Events;
using MediatR;

namespace DDD.Domain.EventHandlers
{
    public class UsuarioEventHandler :
        INotificationHandler<UsuarioRegisteredEvent>,
        INotificationHandler<UsuarioUpdatedEvent>,
        INotificationHandler<UsuarioRemovedEvent>
    {
        public Task Handle(UsuarioUpdatedEvent message, CancellationToken cancellationToken)
        {
            // Send some notification e-mail

            return Task.CompletedTask;
        }

        public Task Handle(UsuarioRegisteredEvent message, CancellationToken cancellationToken)
        {
            // Send some greetings e-mail

            return Task.CompletedTask;
        }

        public Task Handle(UsuarioRemovedEvent message, CancellationToken cancellationToken)
        {
            // Send some see you soon e-mail

            return Task.CompletedTask;
        }
    }
}
