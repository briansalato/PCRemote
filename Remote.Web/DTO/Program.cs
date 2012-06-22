using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Remote.Web.DTO
{
    public class Program : IdModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Command { get; set; }
    }
}