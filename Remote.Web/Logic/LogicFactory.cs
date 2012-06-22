using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Remote.Web.Filter;
using System.Diagnostics.CodeAnalysis;

namespace Remote.Web.Models
{
    [ExcludeFromCodeCoverage]
    public static class ModelFactory
    {
        private static IUserLogic _userLogic;
        public static IUserLogic GetUserLogic()
        {
            if (_userLogic != null)
            {
                return _userLogic;
            }

            return new UserLogic();
        }

        public static void Set(IUserLogic userLogic = null)
        {
            _userLogic = userLogic;
        }
    }
}