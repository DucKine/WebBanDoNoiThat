using Model;
using Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
public	interface IOrderDetailService
	{
		IList<OrderDetailDTO> GetAll(int id);
		int Update(OrderDetail t);
		int Inserts(Order order, List<OrderDetail> orderDetail);
	}
}
