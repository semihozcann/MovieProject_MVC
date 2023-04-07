using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Web_MVC.Abstract;

namespace Web_MVC.Areas.Users.Controllers
{
    public class DashboardController : BaseController
    {

        public DashboardController(IUserAccessor userAccessor) : base(userAccessor)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
