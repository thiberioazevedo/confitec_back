using System;
using System.Collections.Generic;
using DDD.Application.EventSourcedNormalizers;
using DDD.Application.ViewModels;

namespace DDD.Application.Interfaces
{
    public interface IEscolaridadeAppService : IDisposable
    {
        IEnumerable<EscolaridadeViewModel> GetAll();
        EscolaridadeViewModel GetById(int id);
    }
}
