using PersonnelApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelApp.Entities
{
    public class Role:IEntity
    {
        public int Id { get; set; }
        public string Definition { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
