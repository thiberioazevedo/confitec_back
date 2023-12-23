using System;
using DDD.Application.Interfaces;
using DDD.Application.Services;
using DDD.Application.ViewModels;
using DDD.Domain.Core.Bus;
using DDD.Domain.Core.Notifications;
using DDD.Domain.Models;
using DDD.Infra.CrossCutting.Identity.Authorization;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Services.Api.Controllers.v1
{
    [Authorize]
    [ApiVersion("1.0")]
    public class UsuarioHistoricoEscolarController : ApiController
    {
        private readonly IUsuarioHistoricoEscolarServiceAppService _usuarioHistoricoEscolarService;

        public UsuarioHistoricoEscolarController(
            IUsuarioHistoricoEscolarServiceAppService usuarioHistoricoEscolarService,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator,
            IAnexoAppService anexoAppService) : base(notifications, mediator, anexoAppService)
        {
            _usuarioHistoricoEscolarService = usuarioHistoricoEscolarService;
        }

        [HttpDelete]
        //[Authorize(Policy = "CanRemoveUsuarioData", Roles = Roles.Admin)]
        [Authorize]
        //[AllowAnonymous]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            _usuarioHistoricoEscolarService.Remove(id);

            return Response();
        }

        public override IActionResult EnviarAnexo([FromForm] IFormFile file, [FromForm] string nome, [FromForm] int id)
        {
            var anexoViewModel = EnviarAnexoBase(file);

            _usuarioHistoricoEscolarService.Add(anexoViewModel.Id ?? 0, id, nome);

            return Response(anexoViewModel);
        }
    }
}
