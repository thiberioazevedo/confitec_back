using System;
using DDD.Application.Interfaces;
using DDD.Application.ViewModels;
using DDD.Domain.Core.Bus;
using DDD.Domain.Core.Notifications;
using DDD.Infra.CrossCutting.Identity.Authorization;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Services.Api.Controllers.v1
{
    [Authorize]
    [ApiVersion("1.0")]
    public class EscolaridadeController : ApiController
    {
        private readonly IEscolaridadeAppService _escolaridadeAppService;

        public EscolaridadeController(
            IEscolaridadeAppService escolaridadeAppService,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator,
            IAnexoAppService anexoAppService) : base(notifications, mediator, anexoAppService)
        {
            _escolaridadeAppService = escolaridadeAppService;
        }

        [HttpGet]
        [Authorize]
        [Route("")]
        public IActionResult Get()
        {
            return Response(_escolaridadeAppService.GetAll());
        }

        [HttpGet]
        [Authorize]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var usuarioViewModel = _escolaridadeAppService.GetById(id);

            return Response(usuarioViewModel);
        }
    }
}
