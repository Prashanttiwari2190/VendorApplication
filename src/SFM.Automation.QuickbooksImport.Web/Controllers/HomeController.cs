using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SFM.Automation.QuickbooksImport.Application.Commands.VendorLogin;
using SFM.Automation.QuickbooksImport.Web.Models;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace SFM.Automation.QuickbooksImport.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMediator mediator;

        public HomeController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
            });
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> SignInAsync(IFormCollection frmc)
        {
            // Extracting the value from FormCollection
            string name = frmc["userName"];
            string pwd = frmc["password"];

            string vendorName = await mediator.Send(new VendorLoginCommand(name, pwd), CancellationToken.None);

            ViewData["ValidationMessage"] = "Get all bills from quickbooks successfully !!";

            return RedirectToAction("Index", "VendorWorkOrder");
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}