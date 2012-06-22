using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Remote.Web.DTO
{
    public class RemoteUser : IdModel
    {
        public string Username { get; set; }
        public virtual IList<Program> Programs { get; set; }
    }
}