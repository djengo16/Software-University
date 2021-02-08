using System;
using System.Collections.Generic;
using System.Text;

namespace MUSACA.Data
{
    public class Order
    {
        public Order()
        {
            this.Id = new Guid().ToString();
        }
        //        •	Has an Id – a GUID String or an Integer.
        public string Id { get; set; }
        //•	Has a Status – can be one of the following values ("Active", "Completed").
        public Status Status { get; set; }
        //•	Has a Product – an Product object.
        public Product Product { get; set; }
        //•	Has a Quantity – an integer.
        public int Quantity { get; set; }
        //•	Has a Cashier – a User object.
        public User Cashier { get; set; }

    }
}
