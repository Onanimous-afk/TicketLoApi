using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketLoApi.Models
{
    public class systemuserrole
    {
        public Guid systemuserroleid { get; set; }
        public Guid? systemuserid { get; set; }
        public Guid? roleid { get; set; }
        public DateTime createdon { get; set; }
        public string createdby { get; set; }
        public DateTime modifiedon { get; set; }
        public string modifiedby { get; set; }
    }
}
