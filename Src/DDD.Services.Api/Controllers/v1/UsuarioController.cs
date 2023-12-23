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
    public class UsuarioController : ApiController
    {
        private readonly IUsuarioAppService _usuarioAppService;

        public UsuarioController(
            IUsuarioAppService usuarioAppService,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator,
            IAnexoAppService anexoAppService) : base(notifications, mediator, anexoAppService)
        {
            _usuarioAppService = usuarioAppService;
        }

        [HttpGet]
        //[AllowAnonymous]
        [Authorize]
        [Route("")]
        public IActionResult Get()
        {
            return Response(_usuarioAppService.GetAll());
        }

        [HttpGet]
        //[AllowAnonymous]
        [Authorize]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var usuarioViewModel = _usuarioAppService.GetById(id);

            return Response(usuarioViewModel);
        }

        [HttpPost]
        //[Authorize(Policy = "CanWriteUsuarioData", Roles = Roles.Admin)]
        [Authorize]
        [Route("")]
        public IActionResult Post([FromBody]UsuarioViewModel usuarioViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(usuarioViewModel);
            }

            _usuarioAppService.Register(usuarioViewModel);

            return Response(usuarioViewModel);
        }

        [HttpPut]
        //[Authorize(Policy = "CanWriteUsuarioData", Roles = Roles.Admin)]
        [Authorize]
        //[AllowAnonymous]
        [Route("{id}")]
        public IActionResult Put(int id, [FromBody]UsuarioViewModel usuarioViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(usuarioViewModel);
            }

            _usuarioAppService.Update(usuarioViewModel);

            return Response(usuarioViewModel);
        }

        [HttpDelete]
        //[Authorize(Policy = "CanRemoveUsuarioData", Roles = Roles.Admin)]
        [Authorize]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            _usuarioAppService.Remove(id);

            return Response();
        }

        [HttpGet]
        //[AllowAnonymous]
        [Authorize]
        [Route("history/{id:guid}")]
        public IActionResult History(int id)
        {
            var usuarioHistoryData = _usuarioAppService.GetAllHistory(id);
            return Response(usuarioHistoryData);
        }

        [HttpGet]
        //[AllowAnonymous]
        [Authorize]
        [Route("pagination")]
        public IActionResult Pagination(int skip, int take)
        {
            return Response(_usuarioAppService.GetAll(skip, take));
        }
    }
}
