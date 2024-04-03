using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Projected
    {
        [Key]
        public int ID { get; set; }
        [DisplayName("Tên Dự Án")]
        public string Name { get; set; }
        public string Slug { get; set; }
        [DisplayName("Hình Ảnh")]
        [DataType(DataType.ImageUrl)]
        public string Images { get; set; }
        [DisplayName("Nội Dung")]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
        [DisplayName("ảnh Liên Quan")]
        [DataType(DataType.ImageUrl)]
        public string MoreImages { get; set; }
        [DisplayName("Tên Khách Hàng")]
        public string Customer { get; set; }
        [DisplayName("Địa Chỉ")]
        public string Address { get; set; }
        [DisplayName("Ngày hoàn thành")]
        public DateTime? finish { get; set; }
        public bool? Status { get; set; }
    }
}
