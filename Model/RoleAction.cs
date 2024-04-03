using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class RoleAction
    {
        [Key]
        public int RoleActionId { get; set; }
        [ForeignKey("Role")]
        public int RoleId { get; set; }
        [ForeignKey("Action")]
        public int ActionId { get; set; }
        public virtual Role Role { get; set; }
        public virtual Action Action { get; set; }
    }
}
