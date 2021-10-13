using System.Collections.Generic;
using HotwireApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotwireApplication.Controllers
{
    public class TodosController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View(new List<Todo> { new Todo() { Item = "Test"}});
        }
    }
}