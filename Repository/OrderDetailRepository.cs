using DAL;
using Model;
using Model.ViewModel;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
	public class OrderDetailRepository :  IOrderDetailRepository,IRepository<OrderDetail>
	{
		private DBEntityContext context;
		public OrderDetailRepository(DBEntityContext context)
		{
			this.context = context;
		}

		public int Delete(int id)
		{
			throw new NotImplementedException();
		}

		public IList<OrderDetailDTO> GetAll(int id)
		{
			var result = (from c in context.OrderDetails
						  join p in context.Products on c.Product_Id equals p.Id
						  where c.Oder_ID == id
						  select new OrderDetailDTO
						  {
							  Images = p.Images,
							  NameProduct = p.Name,
							  Oder_ID = c.Oder_ID,
							  Price = c.Price,
							  Quantity = c.Quantity,
							  Product_Id = p.Id,
						  }).ToList();
		
			return result;
		}

		public IEnumerable<OrderDetail> GetAll()
		{
			throw new NotImplementedException();
		}

		public OrderDetail GetById(int id)
		{
			throw new NotImplementedException();
		}

		public OrderDetail GetByUserName(string UserName)
		{
			throw new NotImplementedException();
		}

		public Contact GetContact()
		{
			throw new NotImplementedException();
		}

		public int Insert(OrderDetail t)
		{
			context.OrderDetails.Add(t);
			return context.SaveChanges();
		}

		public int Inserts(Order order, OrderDetail orderDetail)
		{
			throw new NotImplementedException();
		}

		public int Inserts(Order order, List<OrderDetail> orderDetails)
		{
			using (var transaction = context.Database.BeginTransaction())
			{
				try
				{
					order.Created = DateTime.Now;
					context.Orders.Add(order);
					context.SaveChanges();
					var firstOrder = context.Orders.OrderByDescending(x => x.Created).FirstOrDefault();
					foreach (var item in orderDetails)
					{
						item.Oder_ID = firstOrder.ID;
						context.OrderDetails.Add(item);
						context.SaveChanges();
					}


					transaction.Commit();
				}
				catch (Exception ex)
				{
				
					transaction.Rollback();
					return 0;
					throw ex;
				
				}
			}
			return 1;
		}



		public bool Login(string username, string password)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<OrderDetail> Search(string searchString, int Page, int Pagesize)
		{
			throw new NotImplementedException();
		}

		public int Update(OrderDetail t)
		{
			context.Entry(t).State = System.Data.Entity.EntityState.Modified;
			return context.SaveChanges();
		}
	}
}
