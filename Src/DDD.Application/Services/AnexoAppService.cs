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
using DDD.Domain.Specifications;
using DDD.Infra.Data.Repository.EventSourcing;

namespace DDD.Application.Services
{
    public class AnexoAppService : IAnexoAppService
    {
        private readonly IMapper _mapper;
        private readonly IAnexoRepository _anexoRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler Bus;

        public AnexoAppService(IMapper mapper,
            IAnexoRepository anexoRepository,
            IMediatorHandler bus,
            IEventStoreRepository eventStoreRepository)
        {
            _mapper = mapper;
            Bus = bus;
            _anexoRepository = anexoRepository;
            _eventStoreRepository = eventStoreRepository;

        }


        public AnexoViewModel Add(AnexoViewModel anexoViewModel)
        {
            var registerCommand = _mapper.Map<AddAnexoCommand>(anexoViewModel);

            Bus.SendCommand(registerCommand);

            anexoViewModel.Id = registerCommand.Id;

            return anexoViewModel;
        }



        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public AnexoViewModel Get(int id)
        {
            return _mapper.Map<AnexoViewModel>(_anexoRepository.GetById(id));
        }
    }
}
