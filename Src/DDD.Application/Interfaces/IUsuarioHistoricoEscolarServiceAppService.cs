using System;
using System.Collections.Generic;
using DDD.Application.EventSourcedNormalizers;
using DDD.Application.ViewModels;

namespace DDD.Application.Interfaces
{
    public interface IUsuarioHistoricoEscolarServiceAppService : IDisposable
    {
        void Remove(int id);
        void Add(int anexoId, int usuarioId, string nome);
    }
}
