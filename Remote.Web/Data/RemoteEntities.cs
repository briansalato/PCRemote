using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Remote.Web.DTO;
using Remote.Web.Data.Interfaces;

namespace Remote.Web.Data
{
    public class RemoteEntities : DbContext, IRemoteEntities
    {
        public IDbSet<Program> Programs { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //}

        public RemoteEntities()
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }
    }
}