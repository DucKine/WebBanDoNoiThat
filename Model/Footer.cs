using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	public class Footer
	{
		public int ID { get; set; }
		[DisplayName("Nội dung")]
		[Required(ErrorMessage = "Trường này không được để trống")]
		public string Content { get; set; }
		[DisplayName("Trạng thái")]
		public bool Status { get; set; }
	}
}
