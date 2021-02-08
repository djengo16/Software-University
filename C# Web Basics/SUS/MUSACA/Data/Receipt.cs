using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Text;

namespace MUSACA.Data
{
    public class Receipt
    {
        public Receipt()
        {
            this.Id = new Guid().ToString();
            this.Orders = new HashSet<Order>();
        }
        //        •	Has an Id – a GUID String.
        public string Id { get; set; }
        //•	Has a Issued On – a DateTime object.
        public DateTime IssuedOn { get; set; }
        //•	Has a Orders – a collection of Order objects.
        public ICollection<Order> Orders { get; set; }
        //•	Has a Cashier – a User object.
        public User Cashier { get; set; }

    }
}
