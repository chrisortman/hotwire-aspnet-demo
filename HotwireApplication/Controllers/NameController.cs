using System.Linq;
using System.Net;
using System.Threading.Tasks;
using HotwireApplication.Hubs;
using HotwireApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;

namespace HotwireApplication.Controllers
{
    public class NameController : Controller
    {

        private readonly TodoContext _context;
        private readonly IHubContext<StreamsHub> _hubContext;
        
        public NameController(TodoContext context, IHubContext<StreamsHub> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }

        // GET
        [Route("/names", Name = "Names")]
        [HttpGet]
        public ActionResult<NamesListModel> Index()
        {

            var namesModel = new NamesListModel()
            {
                Names = _context.Names.Select(x => new NameModel()
                {
                    Firstname = x.First,
                    Lastname = x.Last
                }).ToList()
            };

            return View(namesModel);
        }

        [Route("/names/new", Name = "NewName")]
        [HttpGet]
        public ActionResult<NameModel> New()
        {
            return View(new NameModel());
        }
        
        [Route("/names")]
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] NameModel nameModel)
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
                var name = new Name()
                {
                    First = nameModel.Firstname,
                    Last = nameModel.Lastname
                };

                _context.Names.Add(name);
                await _context.SaveChangesAsync();

                await _hubContext.Clients.All.SendAsync("ReceiveMessage", "poop",
                    "<turbo-stream action='append' target='messagesList'><template><h1>HI</h1></template></turbo-stream>");
                
                TempData.Add("Notice", "Name registered successfully!");
                var result = RedirectToAction("Index");
                if (TurboRequest)
                {

                    // var turboRedirect = new TurboRedirectResult(result);
                    // return turboRedirect;
                    
                    var turboResponse = PartialView("_TurboCreate", new NameModel()
                    {
                        Firstname = name.First,
                        Lastname = name.Last
                    });
                    
                    turboResponse.ContentType = "text/vnd.turbo-stream.html; charset=utf-8";
                    return turboResponse;
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