using System;
using System.Collections.Generic;
using DDD.Application.EventSourcedNormalizers;
using DDD.Application.ViewModels;

namespace DDD.Application.Interfaces
{
    public interface IUsuarioAppService : IDisposable
    {
        void Register(UsuarioViewModel customerViewModel);
        IEnumerable<UsuarioViewModel> GetAll();
        IEnumerable<UsuarioViewModel> GetAll(int skip, int take);
        UsuarioViewModel GetById(int id);
        void Update(UsuarioViewModel customerViewModel);
        void Remove(int id);
        IList<UsuarioHistoryData> GetAllHistory(int id);
    }
}
