using DDD.Application.Interfaces;
using DDD.Application.Services;
using DDD.Domain.CommandHandlers;
using DDD.Domain.Commands;
using DDD.Domain.Core.Bus;
using DDD.Domain.Core.Events;
using DDD.Domain.Core.Notifications;
using DDD.Domain.EventHandlers;
using DDD.Domain.Events;
using DDD.Domain.Interfaces;
using DDD.Domain.Providers.Hubs;
using DDD.Domain.Providers.Webhooks;
using DDD.Domain.Providers.Http;
using DDD.Domain.Providers.Mail;
using DDD.Infra.CrossCutting.Bus;
using DDD.Infra.CrossCutting.Identity.Authorization;
using DDD.Infra.CrossCutting.Identity.Models;
using DDD.Infra.CrossCutting.Identity.Services;
using DDD.Infra.Data.EventSourcing;
using DDD.Infra.Data.Repository;
using DDD.Infra.Data.Repository.EventSourcing;
using DDD.Infra.Data.UoW;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using DDD.Domain.Providers.Crons;
using DDD.Domain.Models;

namespace DDD.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASP.NET HttpContext dependency
            services.AddHttpContextAccessor();
            // services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // ASP.NET Authorization Polices
            services.AddSingleton<IAuthorizationHandler, ClaimsRequirementHandler>();

            // Application
            services.AddScoped<IUsuarioAppService, UsuarioAppService>();
            services.AddScoped<IEscolaridadeAppService, EscolaridadeAppService>();
            services.AddScoped<IUsuarioHistoricoEscolarServiceAppService, UsuarioHistoricoEscolarServiceAppService>();
            services.AddScoped<IAnexoAppService, AnexoAppService>();

            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<INotificationHandler<UsuarioRegisteredEvent>, UsuarioEventHandler>();
            services.AddScoped<INotificationHandler<UsuarioUpdatedEvent>, UsuarioEventHandler>();
            services.AddScoped<INotificationHandler<UsuarioRemovedEvent>, UsuarioEventHandler>();            

            // Domain - Commands
            services.AddScoped<IRequestHandler<RegisterNewUsuarioCommand, bool>, UsuarioCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateUsuarioCommand, bool>, UsuarioCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveUsuarioCommand, bool>, UsuarioCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveUsuarioHistoricoEscolarCommand, bool>, UsuarioHistoricoEscolarCommandHandler>();
            services.AddScoped<IRequestHandler<AddUsuarioHistoricoEscolarCommand, bool>, UsuarioHistoricoEscolarCommandHandler>();
            services.AddScoped<IRequestHandler<AddAnexoCommand, bool>, AnexoCommandHandler>();
            

            // Domain - 3rd parties
            services.AddScoped<IHttpService, HttpService>();
            services.AddScoped<IMailService, MailService>();

            // Domain - Providers
            services.AddScoped<INotificationProvider, NotificationProvider>();
            services.AddScoped<IWebhookProvider, WebhookProvider>();
            services.AddScoped<ICronProvider, CronProvider>();

            // Infra - Data
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IEscolaridadeRepository, EscolaridadeRepository>();
            services.AddScoped<IUsuarioHistoricoEscolarRepository, UsuarioHistoricoEscolarRepository>();
            services.AddScoped<IAnexoRepository, AnexoRepository>();
            
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Infra - Data EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreSqlRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();

            // Infra - Identity Services
            services.AddTransient<IEmailSender, AuthEmailMessageSender>();
            services.AddTransient<ISmsSender, AuthSMSMessageSender>();

            // Infra - Identity
            services.AddScoped<IUser, AspNetUser>();
            services.AddSingleton<IJwtFactory, JwtFactory>();
        }
    }
}
