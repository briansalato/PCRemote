using System;
using Remote.Web.DTO;
using System.Data.Entity;
namespace Remote.Web.Data.Interfaces
{
    public interface IRemoteEntities : IDisposable
    {
        IDbSet<Program> Programs { get; set; }

        int SaveChanges();
    }
}
