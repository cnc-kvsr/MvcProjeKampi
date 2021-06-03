using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class DraftManager : IDraftService
    {
        IDraftDal _draftDal;

        public DraftManager(IDraftDal draftDal)
        {
            _draftDal = draftDal;
        }

        public void DraftAdd(Draft draft)
        {
            throw new NotImplementedException();
        }

        public void DraftDelete(Draft draft)
        {
            throw new NotImplementedException();
        }

        public void DraftUpdate(Draft draft)
        {
            throw new NotImplementedException();
        }

        public Draft GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Draft> GetListDraftbox()
        {
            return _draftDal.List(x => x.SenderMail == "admin@gmail.com");
        }
    }
}
