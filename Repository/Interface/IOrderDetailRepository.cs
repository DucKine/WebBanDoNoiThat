using Model;
using Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
public	interface IOrderDetailRepository
	{
		IList<OrderDetailDTO> GetAll(int id);
		int Update(OrderDetail t);
		int Inserts(Order order, List<OrderDetail> orderDetails);
	}
}
