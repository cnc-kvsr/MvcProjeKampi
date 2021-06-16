using BusinessLayer.Abstract;
using CoreLayer.Utilities.Security.Hashing;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AdminManager : IAdminService
    {
        IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public void AddAdmin(Admin admin)
        {
            _adminDal.Insert(admin);
        }

        public void DeleteAdmin(Admin admin)
        {
            _adminDal.Delete(admin);
        }

        public Admin GetByAdminName(string name)
        {
            return _adminDal.Get(x => x.AdminUserName == name);
        }

        public Admin GetByID(int id)
        {
            return _adminDal.Get(x => x.AdminID == id);
        }

        public List<Admin> GetList()
        {
            return _adminDal.List();
        }

        public bool Login(AdminForLoginDto admin)
        {
            var adminToCheck = GetByID(admin.LoginID);
            if (adminToCheck==null)
            {
                return false;
            }
            if (!HashingHelper.VerifyPasswordHash(admin.Password,adminToCheck.AdminPasswordHash,adminToCheck.AdminPasswordSalt)&&
                !HashingHelper.VerifyUserNameHash(admin.Email,adminToCheck.AdminUserNameHash,adminToCheck.AdminUserNameSalt))
            {
                return false;
            }
            return true;
        }

        public bool Register(AdminForRegisterDto adminRegister,string password)
        {
            byte[] passwordHash, passwordSalt, mailHash, mailSalt;
            HashingHelper.CreateMailHash(adminRegister.Email,out mailHash,out mailSalt);
            HashingHelper.CreatePasswordHash(adminRegister.Password,out passwordHash,out passwordSalt);

            var admin = new Admin
            {
                AdminRole = adminRegister.AdminRole,
                AdminPasswordHash = passwordHash,
                AdminPasswordSalt = passwordSalt,
                AdminUserNameHash = mailHash,
                AdminUserNameSalt = mailSalt,
                AdminUserName = adminRegister.UserName
            };
            _adminDal.Insert(admin);
            return true;
        }

        public void UpdateAdmin(Admin admin)
        {
            _adminDal.Update(admin);
        }
    }
}
