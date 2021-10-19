using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HotwireApplication.ViewComponents
{
    public class NotificationViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string message)
        {
            return View("Default", message);
        }   
    }
}