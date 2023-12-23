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
    public class UsuarioCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewUsuarioCommand, bool>,
        IRequestHandler<UpdateUsuarioCommand, bool>,
        IRequestHandler<RemoveUsuarioCommand, bool>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMediatorHandler Bus;

        public UsuarioCommandHandler(IUsuarioRepository usuarioRepository,
                                      IUnitOfWork uow,
                                      IMediatorHandler bus,
                                      INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _usuarioRepository = usuarioRepository;
            Bus = bus;
        }

        public Task<bool> Handle(RegisterNewUsuarioCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var usuario = new Usuario(message.Nome, message.Sobrenome, message.Email, message.DataNascimento, message.EscolaridadeId);

            if (_usuarioRepository.GetByEmail(usuario.Email) != null)
            {
                Bus.RaiseEvent(new DomainNotification(message.MessageType, "O email do usuário já foi usado"));
                return Task.FromResult(false);
            }

            _usuarioRepository.Add(usuario);

            if (Commit())
            {
                Bus.RaiseEvent(new UsuarioRegisteredEvent(usuario.Id ?? 0, usuario.Nome, usuario.Email, usuario.DataNascimento));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(UpdateUsuarioCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var usuario = new Usuario(message.Id, message.Nome, message.Sobrenome, message.Email, message.DataNascimento, message.EscolaridadeId);
            var existingUsuario = _usuarioRepository.GetByEmail(message.Email);

            if (existingUsuario != null && existingUsuario.Id != message.Id)
            {
                Bus.RaiseEvent(new DomainNotification(message.MessageType, "O email do usuário já foi usado"));
                return Task.FromResult(false);
            }

            if (existingUsuario == null)
                existingUsuario = _usuarioRepository.GetById(usuario.Id ?? 0, true);

            usuario.SetEntityAuditValues(existingUsuario);
            _usuarioRepository.Update(usuario);

            if (Commit())
                Bus.RaiseEvent(new UsuarioUpdatedEvent(usuario.Id ?? 0, usuario.Nome, usuario.Email, usuario.DataNascimento));

            return Task.FromResult(true);
        }

        public Task<bool> Handle(RemoveUsuarioCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            _usuarioRepository.Remove(message.Id);

            if (Commit())
            {
                Bus.RaiseEvent(new UsuarioRemovedEvent(message.Id));
            }

            return Task.FromResult(true);
        }

        public void Dispose()
        {
            _usuarioRepository.Dispose();
        }
    }
}
