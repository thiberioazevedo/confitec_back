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
    public class AnexoCommandHandler : CommandHandler, IRequestHandler<AddAnexoCommand, bool>
    {
        private readonly IAnexoRepository _anexoRepository;
        private readonly IMediatorHandler Bus;

        public AnexoCommandHandler(IAnexoRepository anexoRepository,
            IUnitOfWork uow,
            IMediatorHandler bus,
            INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _anexoRepository = anexoRepository;
            Bus = bus;
        }

        public Task<bool> Handle(AddAnexoCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var anexo = new Anexo(message.Nome, message.Formato, message.Arquivo);

            _anexoRepository.Add(anexo);

            if (Commit())
            {
                message.Id = anexo.Id;
                Bus.RaiseEvent(new AddAnexodEvent(anexo.Id ?? 0, anexo.Nome, anexo.Formato, anexo.Arquivo));
            }

            return Task.FromResult(true);
        }

        public void Dispose()
        {
            _anexoRepository.Dispose();
        }
    }
}
