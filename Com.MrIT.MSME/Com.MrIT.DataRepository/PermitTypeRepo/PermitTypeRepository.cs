using Com.MrIT.Common;
using Com.MrIT.DBEntities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Com.MrIT.DataRepository
{

    public class PermitTypeRepository : GenericRepository<PermitType>, IPermitTypeRepository
    {
        public PermitTypeRepository(DataContext context, ILoggerFactory loggerFactory) :
       base(context, loggerFactory, "PermitTypeRepository")
        {

        }
    }
}
