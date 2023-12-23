using System;
using System.Collections.Generic;
using DDD.Application.EventSourcedNormalizers;
using DDD.Application.ViewModels;

namespace DDD.Application.Interfaces
{
    public interface IAnexoAppService : IDisposable
    {
        AnexoViewModel Add(AnexoViewModel anexoViewModel);
        AnexoViewModel Get(int id);
    }
}
