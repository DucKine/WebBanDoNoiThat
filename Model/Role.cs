using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        [DisplayName("Tên Role")]
		[Required(ErrorMessage = "Trường này không được để trống")]
		public string RoleName { get; set; }
		[DisplayName("Mô tả")]
		public string Description { get; set; }
        public virtual ICollection<RoleAction> RoleActions { get; set; }
       
    }
}
