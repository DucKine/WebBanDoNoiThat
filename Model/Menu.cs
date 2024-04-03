using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Menu
    {
        
            [Key]
            public int ID { get; set; }
            public string Text { get; set; }
            public int DisplayOrder { get; set; }
            public string Link { get; set; }
            public bool Status { get; set; }
           
        
    }
}
