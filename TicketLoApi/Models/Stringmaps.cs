using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketLoApi.Models
{
    public class Stringmaps
    {
        public Guid StringmapId { get; set; }
        public string Objectname { get; set; }
        public string AttributeName { get; set; }
        public int AttributeValue { get; set; }
        public string Value { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
    }
}
