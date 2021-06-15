using BusinessLayer.Abstract;
using CoreLayer.Utilities.Security.Hashing;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AuthManager : IAuthService
    {
        public IAdminService _adminService;

        public AuthManager(IAdminService adminService)
        {
            _adminService = adminService;
        }

        public bool Login(AdminForLoginAndRegister adminForLoginAndRegister)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                var userNameHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(adminForLoginAndRegister.AdminUserName));
                var user = _adminService.GetList();
                foreach (var item in user)
                {
                    if (HashingHelper.VerifyPasswordHash(adminForLoginAndRegister.AdminUserName, adminForLoginAndRegister.AdminPassword, item.AdminUserName, item.AdminPasswordHash, item.AdminPasswordSalt))
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public void Register(string userName, string password)
        {
            byte[] userNameHash, passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userName, password, out userNameHash, out passwordHash, out passwordSalt);
            var admin = new Admin
            {
                AdminUserName = userNameHash,
                AdminPasswordHash = passwordHash,
                AdminPasswordSalt = passwordSalt,
                AdminRole = "A"
            };
            _adminService.AddAdmin(admin);
        }
    }
}
