using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Remote.Web.Models;

namespace Remote.Web.Controllers
{
    public class RemoteController : Controller
    {
        public ActionResult GetByProgramId(int programId)
        {
            var remoteLogic = LogicFactory.GetRemoteLogic();
            var remote = remoteLogic.GetByProgramId(programId);
            return View(remote.ViewName, remote);
        }
    }
}
