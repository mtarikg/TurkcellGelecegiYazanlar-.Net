using Microsoft.AspNetCore.Authorization;
using nbaDemo.Entities;
using System;
using System.Linq;

namespace nbaDemo.API.Subclasses
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        public CustomAuthorizeAttribute(params AuthorizeRoles[] roles)
        {
            Roles = string.Join(",", roles.Select(r => r.ToString()));
        }
    }
}
