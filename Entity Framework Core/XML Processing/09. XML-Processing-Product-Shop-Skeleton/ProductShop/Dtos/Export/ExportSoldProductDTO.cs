using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    [XmlType("User")]
    public class ExportSoldProductDTO
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; }

        [XmlElement("lastName")]
        public string LastName { get; set; }

        [XmlArray("soldProducts")]
        public ProductDTO[] SoldProducts { get; set; }

        //      <User>
        //  <firstName>Almire</firstName>
        //  <lastName>Ainslee</lastName>
        //  <soldProducts>
        //    <Product>
        //      <name>olio activ mouthwash</name>
        //      <price>206.06</price>
        //    </Product>
        //  </soldProducts>
        //</User>

    }
    [XmlType("Product")]
    public class ProductDTO
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("price")]
        public decimal Price { get; set; }
    }
}
