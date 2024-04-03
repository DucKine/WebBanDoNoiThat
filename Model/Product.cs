using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Model
{
    public class Product
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Vui Lòng Nhập Tên Sản Phẩm")]
        [DisplayName("Tên sản phẩm")]
		public string Name { get; set; }
        [Required]
        public string Slug { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        [DisplayName("Nội dung")]
		public string Content { get; set; }
        [Required]
        [DataType(DataType.ImageUrl)]
        [DisplayName("Hình ảnh")]
		public string Images { get; set; }
        [Required (ErrorMessage ="Vui Lòng Nhập giá sản phẩm")]
        [Range(0,double.MaxValue,ErrorMessage ="giá không được âm")]
        [DisplayName("Giá gốc")]
		public double Price { get; set; }
		[DisplayName("Giá khuyến mãi")]
		public double? Sale_Price { get; set; }
        public int Category_ID { get; set; }
        [DisplayName("Hình ảnh con")]
		public string MoreImages { get; set; }
		[DisplayName("Ngày tạo")]
		public DateTime? Created { get; set; }
        [DisplayName("Ngày sửa")]
		public DateTime? ModifileDate { get; set; }
		[DisplayName("Trạng thái")]
		public bool Status { get; set; }
		[DisplayName("Sản phẩm hot")]
		public bool TopHot { get; set; }

        [ForeignKey("Category_ID")]
        public virtual Category Categorys { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    

    }
}
