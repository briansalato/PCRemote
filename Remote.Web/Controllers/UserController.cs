using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Remote.Web.Models;
using Remote.Web.ViewModels;

namespace Remote.Web.Controllers
{
    public class UserController : LoggedInController
    {
        public ActionResult Dashboard()
        {
            var userLogic = ModelFactory.GetUserLogic();
            var user = userLogic.GetUser(base.UserId);
            var viewModel = new DashboardViewModel()
            {
                Programs = user.Programs
            };
            return View(viewModel);
        }
    }
}
