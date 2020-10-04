using Com.MrIT.Common;
using Com.MrIT.DBEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Com.MrIT.DataRepository
{
    public interface ISysUserRepository : IGenericRepository<SysUser>
    {
        SysUser ValidateUser(string email, string password, string type, bool VIP = false);

        int GetUserCountByEmail(string email, string userType);

        int GetUserCountByMobileNo(string email, string userType);

        PageResult<SysUser> GetPageResultBySysUser(string keyword, int page, int totalRecords, string userType);

        SysUser GetSysUserByID(int id);

        int ValidatePassword(int userID, string password, string userType);
    }
}
