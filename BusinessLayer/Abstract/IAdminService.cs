using EntityLayer.Concrete;
using EntityLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAdminService
    {
        bool Login(AdminForLoginDto admin);
        bool Register(AdminForRegisterDto admin,string password);
        List<Admin> GetList();
        Admin GetByID(int id);
        Admin GetByAdminName(string name);
        void AddAdmin(Admin admin);
        void DeleteAdmin(Admin admin);
        void UpdateAdmin(Admin admin);
    }
}
