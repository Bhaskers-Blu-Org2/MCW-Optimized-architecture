using System.Threading.Tasks;
using System.Web.Mvc;

namespace Contoso.Financial.Website.Controllers
{
    [Authorize]
    public class ManageController : Controller
    {
        //
        // GET: /Manage/Index
        public async Task<ActionResult> Index()
        {
            return View();
        }
    }
}