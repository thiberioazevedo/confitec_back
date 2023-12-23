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
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioRepository _customerRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler Bus;

        public UsuarioAppService(IMapper mapper,
                                  IUsuarioRepository customerRepository,
                                  IMediatorHandler bus,
                                  IEventStoreRepository eventStoreRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
            Bus = bus;
            _eventStoreRepository = eventStoreRepository;
        }

        public IEnumerable<UsuarioViewModel> GetAll()
        {
            return _customerRepository.GetAll().ProjectTo<UsuarioViewModel>(_mapper.ConfigurationProvider);
        }

        public IEnumerable<UsuarioViewModel> GetAll(int skip, int take)
        {
            return _customerRepository.GetAll(new UsuarioFilterPaginatedSpecification(skip, take))
                .ProjectTo<UsuarioViewModel>(_mapper.ConfigurationProvider);
        }

        public UsuarioViewModel GetById(int id)
        {
            return _mapper.Map<UsuarioViewModel>(_customerRepository.GetById(id));
        }

        public void Register(UsuarioViewModel customerViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewUsuarioCommand>(customerViewModel);
            Bus.SendCommand(registerCommand);
        }

        public void Update(UsuarioViewModel customerViewModel)
        {
            var updateCommand = _mapper.Map<UpdateUsuarioCommand>(customerViewModel);
            Bus.SendCommand(updateCommand);
        }

        public void Remove(int id)
        {
            var removeCommand = new RemoveUsuarioCommand(id);
            Bus.SendCommand(removeCommand);
        }

        public IList<UsuarioHistoryData> GetAllHistory(int id)
        {
            return UsuarioHistory.ToJavaScriptCustomerHistory(_eventStoreRepository.All(id));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
