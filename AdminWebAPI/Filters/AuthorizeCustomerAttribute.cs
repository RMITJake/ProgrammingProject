using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using AdminWebAPI.Models;

namespace AdminWebAPI.Filters;

public class AuthorizeCustomerAttribute : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        // authorize customer if admin
        var customerID = context.HttpContext.Session.GetString("UserID");
        if(!customerID.Equals("admin"))
            context.Result = new RedirectToActionResult("Index", "Login", null);
    }
}
