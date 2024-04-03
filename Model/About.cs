using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class About
    {   
        public int ID { get; set; }
        [DisplayName("Tên ")]
        [Required(ErrorMessage = "Trường này không được để trống")]
		public string Name { get; set; }
		[Required(ErrorMessage = "Trường này không được để trống")]
		public string Slug { get; set; }
        [DisplayName("Chi tiết")]
        [Required(ErrorMessage = "Trường này không được để trống")]
		public string Detail { get; set; }
		[DisplayName("Ngày tạo")]
		public DateTime? CreatedDate { get; set; }
		[DisplayName("Ngày sửa")]
		public DateTime? ModifileDate { get; set; }
		[DisplayName("Hình ảnh")]
		public string Image { get; set; }
		[DisplayName("Trạng thái")]
		public bool Status { get; set; }
    }
}
