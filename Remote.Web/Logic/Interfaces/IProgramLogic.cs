﻿using System;
using Remote.Web.ViewModels;
using Remote.Web.DTO;
using System.Collections.Generic;

namespace Remote.Web.Logic.Interfaces
{
    public interface IProgramLogic
    {
        Program Get(int id);
        List<Program> GetAll();
        Program Create(Program program);
    }
}
