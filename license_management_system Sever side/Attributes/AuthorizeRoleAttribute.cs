using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;

namespace license_management_system_Sever_side.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class AuthorizeRoleAttribute : Attribute, IAuthorizationFilter
    {
        private readonly string[] _roleIds;

        public AuthorizeRoleAttribute(params string[] roleIds)
        {
            _roleIds = roleIds;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var roleIds = context.HttpContext.Request.Query["roleIds"].ToString().Split(',');

            if (!_roleIds.Any(roleId => roleIds.Contains(roleId)))
            {
                context.Result = new ForbidResult();
            }
        }
    }
}
