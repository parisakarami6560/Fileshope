using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Filshopfil.Models;

namespace ContactUs.Controllers
{
    [Area("CONTACTUS")]
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
        [Route("Messages")]
        public IActionResult Messages()
        {
            return View(DataBase.DataBase.Messages);
        }


        [HttpPost]
        public IActionResult SendMessage(Message message)
        {
            DataBase.DataBase.Messages.Add(message);
            return Redirect("/home/Messages");
        }
    }
}
