using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Remote.Web.DTO
{
    public class Remote : IdModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string ViewName { get; set; }

        public virtual IList<Program> Programs { get; set; }
    }
}