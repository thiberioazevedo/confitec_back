using System;
using System.Collections.Generic;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DDD.Application.EventSourcedNormalizers;
using DDD.Application.Interfaces;
using DDD.Application.ViewModels;
using DDD.Domain.Commands;
using DDD.Domain.Core.Bus;
using DDD.Domain.Interfaces;
using DDD.Domain.Models;
using DDD.Domain.Specifications;
using DDD.Infra.Data.Repository.EventSourcing;

namespace DDD.Application.Services
{
    public class UsuarioHistoricoEscolarServiceAppService : IUsuarioHistoricoEscolarServiceAppService
    {
        private readonly IMediatorHandler Bus;

        public UsuarioHistoricoEscolarServiceAppService(IMediatorHandler bus)
        {
            Bus = bus;
        }

        public void Remove(int id)
        {
            var removeCommand = new RemoveUsuarioHistoricoEscolarCommand(id);
            Bus.SendCommand(removeCommand);
        }

        public void Add(int anexoId, int usuarioId, string nome)
        {
            var addCommand = new AddUsuarioHistoricoEscolarCommand(anexoId, usuarioId, nome);
            Bus.SendCommand(addCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
