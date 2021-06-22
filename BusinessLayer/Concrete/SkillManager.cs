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
    public class SkillManager : ISkillService
    {
        ISkillDal _skillDal;

        public SkillManager(ISkillDal skillDal)
        {
            _skillDal = skillDal;
        }

        public void AddSkill(Skill skill)
        {
            _skillDal.Insert(skill);
        }

        public void DeleteSkill(Skill skill)
        {
            _skillDal.Delete(skill);
        }

        public Skill GetByID(int id)
        {
            return _skillDal.Get(x => x.SkillID == id);
        }

        public List<Skill> GetList()
        {
            return _skillDal.List();
        }

        public List<Skill> GetListByWriterID(int id)
        {
            return _skillDal.List(x => x.WriterID == id);
        }

        public void UpdateSkill(Skill skill)
        {
            _skillDal.Update(skill);
        }
    }
}
