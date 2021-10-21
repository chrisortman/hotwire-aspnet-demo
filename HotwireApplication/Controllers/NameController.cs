using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using HotwireApplication.Hubs;
using HotwireApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Buffers;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;

namespace HotwireApplication.Controllers
{
    public class NameController : Controller
    {

        private readonly TodoContext _context;
        private readonly IHubContext<StreamsHub> _hubContext;

        private bool useFrames = true;
        private bool pretendYouDontKnowAboutTurbo = false;
        
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

            if (useFrames)
            {
                return View(namesModel);
            }
            else
            {
                return View("IndexNoFrame", namesModel);
            }
        }

        [Route("/names/new", Name = "NewName")]
        [HttpGet]
        public ActionResult<NameModel> New()
        {
            return NewView(new NameModel());
        }

        private ViewResult NewView(NameModel nameModel)
        {
            if (useFrames)
            {
                return View("New", nameModel);
            }
            else
            {
                return View("NewNoFrame", nameModel);
            }
        }
        [Route("/names")]
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] NameModel nameModel)
        {
            if (!ModelState.IsValid)
            {
                var result = NewView(nameModel);
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

                var notification = await RenderViewComponent("Notification",new {
                    message = "Name registered successfully!",
                });
                var turboStream = await TurboStream("before", "nameform", () => notification);
                
                _hubContext.Clients.All.SendAsync("TurboBroadcast", turboStream);
                
                var result = RedirectToAction("Index");
                if (TurboRequest)
                {

                    /* When we're not inside a frame we may want to redirect */
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

                if (pretendYouDontKnowAboutTurbo) return false;
                                
                var acceptHeaders = Request.Headers["Accept"]
                                        .SelectMany(x => x.Split(','))
                                        .Select(x => x.TrimEnd(','));
                return acceptHeaders.Contains("text/vnd.turbo-stream.html");
            }
        }

        private async Task<string> TurboStream(string action, string target, Func<String> body)
        {
            
            string html = $@"
<turbo-stream action='{action}' target='{target}'>
    <template>
        {body()}
    </template>            
</turbo-stream>
            ";
            return html.Replace("\n","");
        }
        
        public async Task<string> RenderViewComponent(string viewComponent, object args)
        {
            var sp = HttpContext.RequestServices;
            
            var helper = new DefaultViewComponentHelper(
                sp.GetRequiredService<IViewComponentDescriptorCollectionProvider>(),
                HtmlEncoder.Default,
                sp.GetRequiredService<IViewComponentSelector>(),
                sp.GetRequiredService<IViewComponentInvokerFactory>(),
                sp.GetRequiredService<IViewBufferScope>());
        
            using (var writer = new StringWriter())
            {
                var context = new ViewContext(ControllerContext, NullView.Instance, ViewData, TempData, writer, new HtmlHelperOptions());
                helper.Contextualize(context);
                var result = await helper.InvokeAsync(viewComponent, args);
                result.WriteTo(writer, HtmlEncoder.Default);
                await writer.FlushAsync();
                return writer.ToString();
            }
        }
        
    }
    public class NullView : IView
    {
        public static readonly NullView Instance = new NullView();

        public string Path => string.Empty;

        public Task RenderAsync(ViewContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            return Task.CompletedTask;
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