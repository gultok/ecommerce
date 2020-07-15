using ECommerce.Core;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;

namespace ECommerce.Api.Controllers
{
    public class ECommerceBaseController : ControllerBase
    {
        public void ValidateModel()
        {
            if (!ModelState.IsValid)
            {
                var errorMessages = ModelState.Values.SelectMany(x => x.Errors.Select(y => y.ErrorMessage));
                throw new ECommerceException(string.Join(" ", errorMessages), (int)HttpStatusCode.BadRequest);
            }
        }
    }
}
