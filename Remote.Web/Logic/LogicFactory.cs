using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Remote.Web.Filter;
using System.Diagnostics.CodeAnalysis;
using Remote.Web.Logic;
using Remote.Web.Logic.Interfaces;

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

        private static IRemoteLogic _remoteLogic;
        public static IRemoteLogic GetRemoteLogic()
        {
            if (_remoteLogic != null)
            {
                return _remoteLogic;
            }

            return new RemoteLogic();
        }

        private static IWindowsLogic _windowsLogic;
        public static IWindowsLogic GetWindowsLogic()
        {
            if (_windowsLogic != null)
            {
                return _windowsLogic;
            }

            return new WindowsLogic();
        }

        public static void Set(IProgramLogic programLogic = null
                               , IRemoteLogic remoteLogic = null
                               , IWindowsLogic windowsLogic = null)
        {
            _programLogic = programLogic;
            _remoteLogic = remoteLogic;
            _windowsLogic = windowsLogic;
        }
    }
}