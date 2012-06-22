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
        public ActionResult Show(int id)
        {
            var programLogic = LogicFactory.GetProgramLogic();
            var program = programLogic.Get(id);
            if (program == null)
            {

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
            
            return Redirect(Url.Program_Show(program.Id));
        }
    }
}
