using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.DTO.Import
{
    [XmlType("Car")]
    public class ImportCarDTO
    {
        [XmlElement("make")]
        public string Make { get; set; }

        [XmlElement("model")]
        public string Model { get; set; }

        [XmlElement("TraveledDistance")]
        public int TraveledDistance { get; set; }

        [XmlArray("parts")]
        public PartsIds[] Parts { get; set; }
    }

    [XmlType("partId")]
    public class PartsIds
    {
        [XmlAttribute("id")]
        public int PartId { get; set; }
    }

  //  <Car>
  //  <make>Opel</make>
  //  <model>Omega</model>
  //  <TraveledDistance>176664996</TraveledDistance>
  //  <parts>
  //    <partId id = "38" />
  //    < partId id="102"/>
  //    <partId id = "23" />
  //  </ parts >
  //</ Car >
}
