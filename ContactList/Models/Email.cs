using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactList.Models
{
    public class Email
    {
        public int ID { get; set; }
        public string Adress { get; set; }
        public int ContactId { get; set; }
        public virtual Contact Contact { get; set; }

    }
}