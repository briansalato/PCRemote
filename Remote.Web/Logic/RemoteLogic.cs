using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Remote.Web.Models;
using Remote.Web.Filter;
using Remote.Web.DTO;
using Remote.Web.Data;
using Remote.Web.Logic.Interfaces;

namespace Remote.Web.Logic
{
    public class RemoteLogic : IRemoteLogic
    {
        public DTO.Remote GetByProgramId(int programId)
        {
            var filter = new RemoteFilter()
            {
                ProgramId = programId
            };
            return GetRemotes(filter).FirstOrDefault();
        }

        #region -Private Methods
        private List<DTO.Remote> GetRemotes(RemoteFilter filter)
        {
            using (var db = DataFactory.GetRemoteEntities())
            {
                var query = db.Remotes.AsQueryable();

                if (filter.Id.HasValue)
                {
                    query = query.Where(remote => remote.Id == filter.Id.Value);
                }

                if (filter.ProgramId.HasValue)
                {
                    query = query.Where(remote => 
                                        remote.Programs.Any(program => program.Id == filter.ProgramId.Value));
                }

                return query.ToList();
            }
        }
        #endregion
    }
}