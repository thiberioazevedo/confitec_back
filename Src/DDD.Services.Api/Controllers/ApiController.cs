using System.IO;
using System.Net;
using System.Net.Http.Headers;
using DDD.Application.Interfaces;
using DDD.Application.ViewModels;
using DDD.Domain.Core.Bus;
using DDD.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Services.Api.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
//[Route("api/[controller]/[action]")]
public abstract class ApiController : ControllerBase
{
    private readonly DomainNotificationHandler _notifications;
    private readonly IMediatorHandler _mediator;
    private readonly IAnexoAppService _anexoAppService;

    protected ApiController(INotificationHandler<DomainNotification> notifications,
                            IMediatorHandler mediator,
                            IAnexoAppService anexoAppService)
    {
        _notifications = (DomainNotificationHandler)notifications;
        _mediator = mediator;
        _anexoAppService = anexoAppService;
    }

    protected IEnumerable<DomainNotification> Notifications => _notifications.GetNotifications();

    protected bool IsValidOperation()
    {
        return (!_notifications.HasNotifications());
    }

    protected new IActionResult Response(object result = null)
    {
        if (IsValidOperation())
        {
            return Ok(new
            {
                success = true,
                data = result
            });
        }

        return BadRequest(new
        {
            success = false,
            errors = _notifications.GetNotifications().Select(n => n.Value)
        });
    }

    protected void NotifyModelStateErrors()
    {
        var erros = ModelState.Values.SelectMany(v => v.Errors);
        foreach (var erro in erros)
        {
            var erroMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
            NotifyError(string.Empty, erroMsg);
        }
    }

    protected void NotifyError(string code, string message)
    {
        _mediator.RaiseEvent(new DomainNotification(code, message));
    }

    protected void AddIdentityErrors(IdentityResult result)
    {
        foreach (var error in result.Errors)
        {
            NotifyError(result.ToString(), error.Description);
        }
    }

    [Authorize]
    [HttpPost]
    [Route("enviar-anexo")]
    public virtual IActionResult EnviarAnexo([FromForm] IFormFile file, [FromForm] string nome, [FromForm] int id)
    {
        return Response(EnviarAnexoBase(file));
    }

    [Authorize]
    [HttpGet]
    [Route("obter-anexo/{id}")]
    public virtual IActionResult ObterAnexo(int id)
    {
        var anexoViewModel = _anexoAppService.Get(id);

        return File(anexoViewModel.Arquivo, "application/octet-stream", anexoViewModel.Nome);
    }

    internal AnexoViewModel EnviarAnexoBase(IFormFile file)
    {
        byte[] byteArray;
        using (var memoryStream = new MemoryStream())
        {
            file.CopyTo(memoryStream);
            byteArray = memoryStream.ToArray();
        }

        var anexoViewModel = new AnexoViewModel { Formato = file.FileName.Split(".").LastOrDefault(), Nome = file.FileName, Arquivo = byteArray };
        _anexoAppService.Add(anexoViewModel);
        return anexoViewModel;
    }
}
