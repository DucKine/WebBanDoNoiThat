using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Baogia
    {
		[Key]
		public int ID { get; set; }
		[DisplayName("Họ Tên")]
		public string Name { get; set; }
		[DisplayName("Email")]
		public string Email { get; set; }
		[DisplayName("Số Điện Thoại")]
		public int Phone { get; set; }
		[DisplayName("Nội dung")]
		public string Content { get; set; }
		public DateTime? Created { get; set; }
		[DisplayName("trạng thái")]
		public int Status { get; set; }
	}
}
