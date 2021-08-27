using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Interview
{
    internal class CustomAuthorizationAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            // some auth logic

            var authValue = actionContext.Request.Headers.Authorization?.ToString();

            if (string.IsNullOrEmpty(authValue))
            {
                actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
            }

            base.OnAuthorization(actionContext);
        }
    }
}
