using EntityLayer.Concrete;
using EntityLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IWriterService
    {
        List<Writer> GetList();
        void WriterAdd(Writer writer);
        void WriterDelete(Writer writer);
        void WriterUpdate(Writer writer);
        Writer GetByID(int id);
        Writer GetByWriterMail(string mail);
        bool Login(WriterForLoginDto writer);
        bool Register(WriterForRegisterDto writer, string password);

    }
}
