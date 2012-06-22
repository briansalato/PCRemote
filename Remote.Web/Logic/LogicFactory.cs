using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Remote.Web.Filter;
using System.Diagnostics.CodeAnalysis;

namespace Remote.Web.Models
{
    [ExcludeFromCodeCoverage]
    public static class LogicFactory
    {
        private static IProgramLogic _programLogic;
        public static IProgramLogic GetProgramLogic()
        {
            if (_programLogic != null)
            {
                return _programLogic;
            }

            return new ProgramLogic();
        }

        public static void Set(IProgramLogic programLogic = null)
        {
            _programLogic = programLogic;
        }
    }
}