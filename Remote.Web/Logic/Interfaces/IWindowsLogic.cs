using System;
using Remote.Web.DTO;
using System.Collections.Generic;

namespace Remote.Web.Logic.Interfaces
{
    public interface IWindowsLogic
    {
        bool ExecuteCommand(string command);
    }
}
