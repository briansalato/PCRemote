using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics.CodeAnalysis;
using Remote.Web.Data.Interfaces;

namespace Remote.Web.Data
{
    [ExcludeFromCodeCoverage]
    public static class DataFactory
    {
        private static IRemoteEntities _remoteEntities;
        public static IRemoteEntities GetRemoteEntities()
        {
            if (_remoteEntities != null)
            {
                return _remoteEntities;
            }

            return new RemoteEntities();
        }

        public static void Set(IRemoteEntities remoteEntities = null)
        {
            _remoteEntities = remoteEntities;
        }
    }
}