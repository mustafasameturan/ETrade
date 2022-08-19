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
    public class OrderManager : IOrderService
    {
        private IOrderDal _orderDal;

        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        public void Add(Order t)
        {
            t.OrderDate = DateTime.Now;
            _orderDal.Add(t);
        }

        public void Delete(Order t)
        {
            _orderDal.Delete(t);
        }

        public Order GetById(int id)
        {
            return _orderDal.GetById(id);
        }

        public List<Order> GetList()
        {
            return _orderDal.GetAll();
        }

        public void Update(Order t)
        {
            _orderDal.Update(t);
        }
    }
}
