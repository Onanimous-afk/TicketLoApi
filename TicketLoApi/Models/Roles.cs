using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketLoApi.Models
{
    public class Roles
    {
        public Guid RoleId { get; set; }
        public string RoleName { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
    }
}
