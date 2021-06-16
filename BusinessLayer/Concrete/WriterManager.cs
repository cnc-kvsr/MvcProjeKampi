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
    public class WriterManager : IWriterService
    {
        private IWriterDal _writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public Writer GetByID(int id)
        {
            return _writerDal.Get(x => x.WriterID == id);
        }

        public Writer GetByWriterMail(string mail)
        {
            return _writerDal.Get(x => x.WriterMail == mail);
        }

        public List<Writer> GetList()
        {
            return _writerDal.List();
        }

        public bool Login(WriterForLoginDto writer)
        {
            var writerToCheck = GetByID(writer.WriterID);
            if (writerToCheck==null)
            {
                return false;
            }
            if (HashingHelper.VerifyPasswordHash(writer.Password,writerToCheck.WriterPasswordHash,writerToCheck.WriterPasswordSalt))
            {
                return false;
            }
            return true;
        }

        public bool Register(WriterForRegisterDto writerRegister, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);

            var writer = new Writer
            {
                WriterPasswordHash = passwordHash,
                WriterPasswordSalt=passwordSalt,
                WriterImage= writerRegister.WriterImage,
                WriterName = writerRegister.WriterName,
                WriterSurName= writerRegister.WriterSurName,
                WriterMail = writerRegister.WriterMail,
                WriterStatus=true,
                WriterTitle= writerRegister.WriterTitle,
                WriterAbout = writerRegister.WriterAbout
            };
            _writerDal.Insert(writer);
            return true;
        }

        public void WriterAdd(Writer writer)
        {
            _writerDal.Insert(writer);
        }

        public void WriterDelete(Writer writer)
        {
            _writerDal.Delete(writer);
        }

        public void WriterUpdate(Writer writer)
        {
            _writerDal.Update(writer);
        }
    }
}
