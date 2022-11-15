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
    public class VendorWorkOrderController : Controller
    {
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
            return View("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}