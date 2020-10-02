using Com.MrIT.Common;
using Com.MrIT.Common.Configuration;
using Com.MrIT.DataRepository;
using Com.MrIT.DBEntities;
using Com.MrIT.ViewModels;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Com.MrIT.Services
{
    public class CommonService : BaseService, ICommonService
    {
        private readonly AppSettings _appSettings;
        public CommonService(IOptions<AppSettings> appSettings)
        {
            this._appSettings = appSettings.Value;
        }

       
    }
}
