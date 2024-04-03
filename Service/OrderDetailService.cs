using DAL;
using Model;
using Model.ViewModel;
using Repository;
using Service.Interface;
using System.Collections.Generic;

namespace Service
{
	public class OrderDetailService : IOrderDetailService
	{
		private OrderDetailRepository repository;
		public OrderDetailService()
		{
			repository = new OrderDetailRepository(new DBEntityContext());
		}
		public IList<OrderDetailDTO> GetAll(int id)
		{
			return repository.GetAll(id);
		}

		

		public int Inserts(Order order, List<OrderDetail> orderDetails)
		{
			return repository.Inserts(order, orderDetails);
		}

		public int Update(OrderDetail t)
		{
			return repository.Update(t);
		}
	}
}
