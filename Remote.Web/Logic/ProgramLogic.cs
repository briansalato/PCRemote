using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Remote.Web.Data;
using Remote.Web.ViewModels;
using Remote.Web.Filter;
using Remote.Web.DTO;
using Remote.Web.Exceptions;
using Remote.Web.Models;
using Remote.Web.Logic.Interfaces;

namespace Remote.Web.Logic
{
    public class ProgramLogic : IProgramLogic
    {
        #region -Public Methods
        public Program Get(int id) 
        {
            var filter = new ProgramFilter()
            {
                Id = id
            };
            return GetPrograms(filter).FirstOrDefault();
        }

        public List<Program> GetAll()
        {
            var filter = new ProgramFilter();
            return GetPrograms(filter);
        }

        public Program Create(Program program)
        {
            if (program.Id != 0)
            {
                throw new ValidationException("Item Id must not be set to add it to the database");
            }

            using (var db = DataFactory.GetRemoteEntities())
            {
                program = db.Programs.Add(program);
                db.SaveChanges();
            }

            return program;
        }
        #endregion

        #region -Private Methods
        private List<Program> GetPrograms(ProgramFilter filter)
        {
            using (var db = DataFactory.GetRemoteEntities())
            {
                var query = db.Programs.AsQueryable();

                if (filter.Id.HasValue)
                {
                    query = query.Where(program => program.Id == filter.Id.Value);
                }

                return query.ToList();
            }
        }
        #endregion
    }
}