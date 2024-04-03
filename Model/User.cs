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
	public class User
	{
		[Key]
		public int UserId { get; set; }
		[ForeignKey("Role")]
		public int RoleId { get; set; }
		[Required(ErrorMessage = "Trường này không được để trống")]
		[RegularExpression(@"^[a-zA-Z0-9]*$", ErrorMessage ="user name không được chứa ký tự đặc biệt")]
        [DisplayName("Tên tài khoản")]
        public string UserName { get; set; }
		[Required(ErrorMessage = "Trường này không được để trống")]
        [DisplayFormat(DataFormatString = "Mật khẩu")]
		[DisplayName("Mật khẩu")]
		public string Password { get; set; }
		[Compare("Password", ErrorMessage = "Mật khẩu không khớp,vui lòng thử lại !")]
		[NotMapped]
        [DisplayName("Xác nhận mật khẩu")]
        public string ConfirmPassword { get; set; }
        [DisplayName("Ngày tạo")]
        public DateTime? CreatedDate { get; set; }
        [DisplayName("Ngày sửa")]
        public DateTime? EditedDate { get; set; }
        [Required(ErrorMessage = "Trường này không được để trống")]
        [DisplayName("Tên người dùng")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Trường này không được để trống")]
		[RegularExpression(@"^([0-9]{10})$",ErrorMessage ="không đúng định dạng phone")]
        [DisplayName("Số điện thoại")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Trường này không được để trống")]
        [RegularExpression(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$", ErrorMessage ="Không đúng định dạng mail")]
		public string Email { get; set; }
        [DisplayName("Địa chỉ")]
        [Required(ErrorMessage = "Trường này không được để trống")]
		public string Address { get; set; }
        [DisplayName("Trạng thái")]
        public bool Status { get; set; }
        public string RessetPasswordCode { get; set; }
		public virtual Role Role { get; set; }
	}
}
