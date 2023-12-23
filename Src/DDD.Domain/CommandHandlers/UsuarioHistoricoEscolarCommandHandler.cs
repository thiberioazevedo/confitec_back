using System;
using System.Threading;
using System.Threading.Tasks;
using DDD.Domain.Commands;
using DDD.Domain.Core.Bus;
using DDD.Domain.Core.Notifications;
using DDD.Domain.Events;
using DDD.Domain.Interfaces;
using DDD.Domain.Models;
using MediatR;

namespace DDD.Domain.CommandHandlers
{
    public class UsuarioHistoricoEscolarCommandHandler : CommandHandler,
        IRequestHandler<RemoveUsuarioHistoricoEscolarCommand, bool>,
        IRequestHandler<AddUsuarioHistoricoEscolarCommand, bool>
    {
        private readonly IUsuarioHistoricoEscolarRepository _usuarioHistoricoEscolarRepository;
        private readonly IMediatorHandler Bus;

        public UsuarioHistoricoEscolarCommandHandler(IUsuarioHistoricoEscolarRepository usuarioHistoricoEscolarRepository,
                                      IUnitOfWork uow,
                                      IMediatorHandler bus,
                                      INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _usuarioHistoricoEscolarRepository = usuarioHistoricoEscolarRepository;
            Bus = bus;
        }

        public Task<bool> Handle(RemoveUsuarioHistoricoEscolarCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            _usuarioHistoricoEscolarRepository.Remove(message.Id);

            if (Commit())
            {
                Bus.RaiseEvent(new UsuarioRemovedEvent(message.Id));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(AddUsuarioHistoricoEscolarCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var usuarioHistoricoEscolar = new UsuarioHistoricoEscolar(message.UsuarioId, message.AnexoId, message.Nome);

            _usuarioHistoricoEscolarRepository.Add(usuarioHistoricoEscolar);

            if (Commit())
            {
                message.Id = usuarioHistoricoEscolar.Id ?? 0;
                Bus.RaiseEvent(new AddUsuarioHistoricoEscolarEvent(usuarioHistoricoEscolar.Id ?? 0, usuarioHistoricoEscolar.UsuarioId, usuarioHistoricoEscolar.AnexoId, usuarioHistoricoEscolar.Nome));
            }

            return Task.FromResult(true);
        }

        public void Dispose()
        {
            _usuarioHistoricoEscolarRepository.Dispose();
        }
    }
}
