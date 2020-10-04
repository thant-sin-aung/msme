using Com.MrIT.Common;
using Com.MrIT.DBEntities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.MrIT.DataRepository
{

    public class SysUserRepository : GenericRepository<SysUser>, ISysUserRepository
    {
        public SysUserRepository(DataContext context, ILoggerFactory loggerFactory) :
       base(context, loggerFactory, "SysUserRepository")
        {

        }

        public SysUser ValidateUser(string email, string password, string type, bool VIP = false)
        {
            var record = entities.Where(e => e.Email.ToLower() == email.ToLower()
               && (e.Password == password || VIP == true)
               && e.Active == true && e.SystemActive == true)
               .FirstOrDefault();

            return record;
        }

        public int GetUserCountByEmail(string email, string userType)
        {
            if(userType == "B")
            {
                var record = entities.Count(e => e.Email.ToLower() == email.ToLower() && e.IsBusiness == true && e.Active == true && e.SystemActive == true);

                return record;
            }
            else
            {
                var record = entities.Count(e => e.Email.ToLower() == email.ToLower() && e.IsBusiness == false && e.Active == true && e.SystemActive == true);

                return record;
            }
            
        }

        public int GetUserCountByMobileNo(string mobileNo, string userType)
        {
            if (userType == "B")
            {
                var record = entities.Count(e => e.MobileNo == mobileNo && e.IsBusiness == true && e.Active == true && e.SystemActive == true);

                return record;
            }
            else
            {
                var record = entities.Count(e => e.MobileNo == mobileNo && e.IsBusiness == false  && e.Active == true && e.SystemActive == true);

                return record;
            }

        }

        public SysUser GetSysUserByID(int id)
        {
            var record = entities.Where(e => e.ID == id && e.SystemActive == true)
               .FirstOrDefault();

            return record;
        }

        public PageResult<SysUser> GetPageResultBySysUser(string keyword, int page, int totalRecords, string userType)
        {
            keyword = keyword.EmptyIfNull().ToLower();
            var records = this.entities
                .Where(e => e.SystemActive == true &&
                (e.Email.ToLower().Contains(keyword) || e.Name.ToLower().Contains(keyword)))
                .OrderBy(e => e.Name)
                .Skip((totalRecords * page) - totalRecords)
                .Take(totalRecords)
                .ToList();

            int count = entities.Count(e => e.SystemActive == true &&
                (e.Email.ToLower().Contains(keyword) || e.Name.ToLower().Contains(keyword))
                );

            var result = new PageResult<SysUser>()
            {
                Records = records,
                TotalPage = (count + totalRecords - 1) / totalRecords,
                CurrentPage = page,
                TotalRecords = count
            };

            return result;
        }

        public int ValidatePassword(int userID, string password, string userType) // If validate == true return count>0
        {
            var record = entities.Count(e => e.Password == password && e.ID == userID && e.IsLocked == false && e.IsActivated == true && e.Active == true && e.SystemActive == true);

            return record;
        }
    }
}
