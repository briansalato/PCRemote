using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Remote.Web.Models;
using Remote.Web.ViewModels;

namespace Remote.Web.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Dashboard()
        {
            var programLogic = LogicFactory.GetProgramLogic();
            var programs = programLogic.GetAll();
            var viewModel = new DashboardViewModel()
            {
                Programs = programs
            };
            return View(viewModel);
        }
    }
}
