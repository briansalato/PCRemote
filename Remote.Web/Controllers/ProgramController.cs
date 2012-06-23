using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Remote.Web.DTO;
using Remote.Web.Models;
using Remote.Web.Utils;

namespace Remote.Web.Controllers
{
    public class ProgramController : BaseController
    {
        [HttpGet]
        public ActionResult Get(int id)
        {
            var programLogic = LogicFactory.GetProgramLogic();
            var program = programLogic.Get(id);
            if (program == null)
            {
                this.AddError("ProgramNotFound", "The program you requested could not be found");
                return Redirect(Url.Dashboard());
            }

            var windowsLogic = LogicFactory.GetWindowsLogic();
            var success = windowsLogic.ExecuteCommand(program.Command);

            if (!success)
            {
                this.AddError("ErrorRunningCommand", "The program may not have been opened successfully");
            }

            return View(program);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new Program());
        }

        [HttpPost]
        public RedirectResult Create(Program program)
        {
            if (!ModelState.IsValid)
            {
                return Redirect(Url.Program_Create());
            }

            var programLogic = LogicFactory.GetProgramLogic();
            program = programLogic.Create(program);
            
            return Redirect(Url.Dashboard());
        }
    }
}
