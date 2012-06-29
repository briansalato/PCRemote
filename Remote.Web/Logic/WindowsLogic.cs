using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Remote.Web.Models;
using Remote.Web.Logic.Interfaces;
using System.Diagnostics;

namespace Remote.Web.Logic
{
    public class WindowsLogic : IWindowsLogic
    {
        public bool ExecuteCommand(string command)
        {
            bool success = false;
            try
            {
                Process.Start(command);
                success = true;
            }
            catch { }
            return success;
        }
    }
}