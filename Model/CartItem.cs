using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class CartItem
    {
        public Product Product { get; set; }
        public double Quantity { get; set; }
    }
}
