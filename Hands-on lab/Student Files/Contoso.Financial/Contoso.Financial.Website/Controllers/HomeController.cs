using System.Web.Mvc;

namespace Contoso.Financial.Website.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //return View();

            return RedirectToAction("Index", new { controller = "Manage" });
        }
    }
}