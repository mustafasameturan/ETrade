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
    public class ColorManager : IColorService
    {
        private IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public void Add(Color t)
        {
            _colorDal.Add(t);
        }

        public void Delete(Color t)
        {
            _colorDal.Delete(t);
        }

        public Color GetById(int id)
        {
            return _colorDal.GetById(id);
        }

        public List<Color> GetList()
        {
            return _colorDal.GetAll();
        }

        public void Update(Color t)
        {
            _colorDal.Update(t);
        }
    }
}
