using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Remote.Web.Data;
using Remote.Web.ViewModels;
using Remote.Web.Filter;
using Remote.Web.DTO;

namespace Remote.Web.Models
{
    public class UserLogic : IUserLogic
    {
        public RemoteUser GetUser(int userId)
        {
            var filter = new UserFilter()
            {
                Id = userId
            };
            return GetUsers(filter).FirstOrDefault();
        }

        private List<RemoteUser> GetUsers(UserFilter filter)
        {
            using (var db = DataFactory.GetRemoteEntities())
            {
                var userQuery = db.Users.AsQueryable();

                if (filter.Id.HasValue)
                {
                    userQuery = userQuery.Where(user => user.Id == filter.Id.Value);
                }

                return userQuery.ToList();
            }
        }
    }
}