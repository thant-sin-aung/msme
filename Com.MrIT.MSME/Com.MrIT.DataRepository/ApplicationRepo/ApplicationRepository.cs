using Com.MrIT.Common;
using Com.MrIT.DBEntities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Com.MrIT.DataRepository
{

    public class ApplicationRepository : GenericRepository<Application>, IApplicationRepository
    {
        public ApplicationRepository(DataContext context, ILoggerFactory loggerFactory) :
       base(context, loggerFactory, "ApplicationRepository")
        {

        }
    }
}
