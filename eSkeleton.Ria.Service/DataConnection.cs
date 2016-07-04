using LightSwitchApplication.Implementation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.EntityClient;
using System.Linq;
using System.ServiceModel.DomainServices.Server;
using System.Web.Configuration;

namespace eSkeleton.Ria.Service
{

    public class ApplicationDataConnection : IDisposable
    {

        private ApplicationData _applicationDataContext;

        public ApplicationDataConnection()
        {

            string connString = System.Web.Configuration.WebConfigurationManager
                                .ConnectionStrings["_IntrinsicData"].ConnectionString;
            EntityConnectionStringBuilder builder = new EntityConnectionStringBuilder();
            builder.Metadata =
                "res://*/ApplicationData.csdl|res://*/ApplicationData.ssdl|res://*/ApplicationData.msl";
            builder.Provider =
                "System.Data.SqlClient";
            builder.ProviderConnectionString = connString;

            _applicationDataContext = new ApplicationData(builder.ConnectionString);
            _applicationDataContext.Connection.Open();

        }

        public ApplicationData ApplicationDataContext { get { return _applicationDataContext; } }

        public void Dispose()
        {
            _applicationDataContext.Connection.Close();
            _applicationDataContext.Dispose();
        }

    }

}
