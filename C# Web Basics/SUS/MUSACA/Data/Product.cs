using System;
using System.Collections.Generic;
using System.Text;

namespace MUSACA.Data
{
    public class Product
    {
        public Product()
        {
            this.Id = new Guid().ToString();
        }
        //        •	Has an Id – a GUID String or an Integer.
        public string Id { get; set; }
        //•	Has a Name – a string.
        public string Name { get; set; }
        //•	Has a Price – a decimal.
        public decimal Price { get; set; }
        //•	Has a Barcode – a 12-digit long integer.
        public char Barcode { get; set; }
        //•	Has a Picture – a string.
        public string Picture { get; set; }

    }
}
