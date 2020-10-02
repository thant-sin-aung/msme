using Com.MrIT.Common;
using Com.MrIT.DBEntities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Com.MrIT.DataRepository
{

    public class SubAgencyPermissionRepository : GenericRepository<SubAgencyPermission>, ISubAgencyPermissionRepository
    {
        public SubAgencyPermissionRepository(DataContext context, ILoggerFactory loggerFactory) :
       base(context, loggerFactory, "SubAgencyPermissionRepository")
        {

        }
    }
}
