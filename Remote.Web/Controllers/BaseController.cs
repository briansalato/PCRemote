using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Remote.Web.Attributes;

namespace Remote.Web.Controllers
{
    [ModelStateTransfer]
    public abstract class BaseController : Controller
    {
    }
}
