using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        private IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public void Add(Brand t)
        {
            _brandDal.Add(t);
        }

        public void Delete(Brand t)
        {
            _brandDal.Delete(t);
        }

        public Brand GetById(int id)
        {
            return _brandDal.GetById(id);
        }

        public List<Brand> GetList()
        {
            return _brandDal.GetAll();
        }

        public void Update(Brand t)
        {
            _brandDal.Update(t);
        }
    }
}
