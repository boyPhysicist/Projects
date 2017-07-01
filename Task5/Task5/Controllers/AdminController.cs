using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace Task5.Controllers
{
    public class AdminController : Controller
    {
        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            return View(UserManager.Users);
        }

        private ApplicationUserManager UserManager => HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            return Redirect("/Account/Register");
        }

        public async Task<ActionResult> Delete(string id)
        {
            var user = UserManager.Users.First(x => x.Id == id);
            await UserManager.DeleteAsync(user);
            return Redirect("/Admin/Index");
        }

    }
}