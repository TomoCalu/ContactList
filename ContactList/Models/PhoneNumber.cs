using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactList.Models
{
    public class PhoneNumber
    {
        public int ID { get; set; }
        public string Number { get; set; }
        public int ContactId { get; set; }
        public virtual Contact Contact { get; set; }
    }
}