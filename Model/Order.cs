using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	public class Order
	{
		[Key]
		public int ID { get; set; }
		public int User_ID { get; set; }
		//public string MethodPayMent { get; set; }
		[DisplayName("Tên người nhận")]
		[Required(ErrorMessage = "Trường này không được để trống")]
		public string Name { get; set; }
		[Required(ErrorMessage = "Trường này không được để trống")]
		public string Email { get; set; }
		[Required(ErrorMessage = "Trường này không được để trống")]
		[DisplayName("Số điện thoại")]
		public string Phone { get; set; }
		[Required(ErrorMessage = "Trường này không được để trống")]
		[DisplayName("Địa chỉ")]
		public string Address { get; set; }
		[DisplayName("Ngày tạo")]
		public DateTime? Created { get; set; }
		[DisplayName("Trạng thái")]
		public int Status { get; set; }
		[ForeignKey("User_ID")]
		public virtual User Users { get; set; }
		public ICollection<OrderDetail> OdersDetail { get; set; }
	}
}
