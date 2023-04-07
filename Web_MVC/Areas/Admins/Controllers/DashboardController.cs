using Microsoft.AspNetCore.Mvc;
using Web_MVC.Abstract;

namespace Web_MVC.Areas.Admins.Controllers
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
