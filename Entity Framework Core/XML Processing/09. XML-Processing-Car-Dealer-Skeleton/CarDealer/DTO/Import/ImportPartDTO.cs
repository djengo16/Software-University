using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.DTO.Importt
{
    [XmlType("Part")]
    public class ImportPartDTO
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("price")]
        public decimal Price { get; set; }

        [XmlElement("quantity")]
        public int Quantity { get; set; }

        [XmlElement("supplierId")]
        public int SupplierId { get; set; }
    }

    //    <Part>
    //    <name>Front clip</name>
    //    <price>100</price>
    //    <quantity>10</quantity>
    //    <supplierId>11</supplierId>
    //</Part>
}
