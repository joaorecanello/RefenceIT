using eSkeleton.Ria.Service.eSkeletonService;
using eSkeleton.Ria.Service.eSkeletonServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.DomainServices.Server;
using System.Text;
using System.Threading.Tasks;

namespace eSkeleton.Ria
{

    public class eSkeletonService : DomainService
    {

        #region Business Classes

        private eSkeletonBusiness _eSkeletonBusiness = new eSkeletonBusiness();

        #endregion

    }

}
