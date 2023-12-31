using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using DDD.Domain.Interfaces;
using Microsoft.AspNetCore.Http;

namespace DDD.Infra.CrossCutting.Identity.Models
{
    public class AspNetUser : IUser
    {
        private readonly IHttpContextAccessor _accessor;

        public AspNetUser(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public Guid Id => new Guid(_accessor.HttpContext.User.Identity.Name);
        public string Name => _accessor.HttpContext.User.Identity.Name;

        public bool IsAuthenticated()
        {
            return _accessor.HttpContext.User.Identity.IsAuthenticated;
        }

        public IEnumerable<Claim> GetClaimsIdentity()
        {
            return _accessor.HttpContext.User.Claims;
        }
    }
}
