using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
	public class OrderDetail
	{
		public int ID { get; set; }
		public int Product_Id { get; set; }
		public int Oder_ID { get; set; }
		public float Price { get; set; }
		public double Quantity { get; set; }
		[ForeignKey("Oder_ID")]
		public  Order Order { get; set; }
		[ForeignKey("Product_Id")]
		public Product Product { get; set; }
	}

}
