using System.ComponentModel;

namespace Model.ViewModel
{
	public class OrderDetailDTO
	{
		public int Product_Id { get; set; }
		public int Oder_ID { get; set; }
		[DisplayName("Giá")]
		public double Price { get; set; }
		[DisplayName("số lượng")]
		public double Quantity { get; set; }
		[DisplayName("Tên sản phẩm")]
		public string NameProduct { get; set; }
		[DisplayName("Hình ảnh")]
		public string Images { get; set; }

	}
}
