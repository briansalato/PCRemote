using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Remote.Web.Data;
using Remote.Web.DTO;

namespace Remote.Web.ViewModels
{
    public class DashboardViewModel
    {
        public IList<Program> Programs { get; set; }
    }
}