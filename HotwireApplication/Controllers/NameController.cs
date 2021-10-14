using System.Linq;
using System.Net;
using System.Threading.Tasks;
using HotwireApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Net.Http.Headers;

namespace HotwireApplication.Controllers
{
    public class NameController : Controller
    {
        // GET
        [Route("/names", Name = "Names")]
        [HttpGet]
        public ActionResult<NameModel> New()
        {

            return View(new NameModel());
        }

        [Route("/names")]
        [HttpPost]
        public IActionResult Create([FromForm] NameModel nameModel)
        {
            if (!ModelState.IsValid)
            {
                var result = View("New", nameModel);
                if (TurboRequest)
                {
                    result.StatusCode = (int) HttpStatusCode.UnprocessableEntity;
                }

                return result;
            }
            else
            {
                TempData.Add("Notice", "Name registered successfully!");
                var result = RedirectToAction("New");
                if (TurboRequest)
                {
                    return new TurboRedirectResult(result);
                }
                else
                {
                    return result;
                }
            }
        }

        private bool TurboRequest
        {
            get
            {
                // var accepts = 
                //     from header in this.Request.Headers["Accept"]
                //     from preference in header.Split(",")
                //     select preference.TrimEnd(',');
                              
                                
                var acceptHeaders = Request.Headers["Accept"]
                                        .SelectMany(x => x.Split(','))
                                        .Select(x => x.TrimEnd(','));
                return acceptHeaders.Contains("text/vnd.turbo-stream.html");
            }
        }
    }

    class TurboRedirectResult : IActionResult
    {
        private readonly RedirectToActionResult _regularRedirect;

        public TurboRedirectResult(RedirectToActionResult regularRedirect)
        {
            _regularRedirect = regularRedirect;
        }

        public Task ExecuteResultAsync(ActionContext context)
        {
            var urlHelper = _regularRedirect.UrlHelper;
            
            var destinationUrl = urlHelper.Action(
                _regularRedirect.ActionName,
                _regularRedirect.ControllerName,
                _regularRedirect.RouteValues,
                protocol: null,
                host: null,
                fragment: _regularRedirect.Fragment);
            
            context.HttpContext.Response.Headers[HeaderNames.Location] = destinationUrl;
            context.HttpContext.Response.StatusCode = StatusCodes.Status303SeeOther;

            return Task.CompletedTask;
        }
    }
    
}