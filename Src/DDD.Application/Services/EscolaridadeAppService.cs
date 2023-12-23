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
using DDD.Infra.Data.Repository;
using DDD.Infra.Data.Repository.EventSourcing;

namespace DDD.Application.Services
{
    public class EscolaridadeAppService : IEscolaridadeAppService
    {
        private readonly IMapper _mapper;
        private readonly IEscolaridadeRepository _escolaridadeRepository;

        public EscolaridadeAppService(IMapper mapper,
                                  IEscolaridadeRepository customerRepository,
                                  IMediatorHandler bus,
                                  IEventStoreRepository eventStoreRepository)
        {
            _mapper = mapper;
            _escolaridadeRepository = customerRepository;
        }

        public IEnumerable<EscolaridadeViewModel> GetAll()
        {
            return _escolaridadeRepository.GetAll().ProjectTo<EscolaridadeViewModel>(_mapper.ConfigurationProvider);
        }

        public EscolaridadeViewModel GetById(int id)
        {
            return _mapper.Map<EscolaridadeViewModel>(_escolaridadeRepository.GetById(id));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
