using System;
using Remote.Web.ViewModels;
using Remote.Web.DTO;
namespace Remote.Web.Models
{
    public interface IUserLogic
    {
        RemoteUser GetUser(int userId);
    }
}
