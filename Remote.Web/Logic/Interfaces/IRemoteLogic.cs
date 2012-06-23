using System;
using Remote.Web.DTO;
using System.Collections.Generic;

namespace Remote.Web.Logic.Interfaces
{
    public interface IRemoteLogic
    {
        DTO.Remote GetByProgramId(int programId);
    }
}
