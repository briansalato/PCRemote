using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Remote.Web.Controllers
{
    public abstract class LoggedInController : Controller
    {
        public int UserId { get; set; }
    }
}