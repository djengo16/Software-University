using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace VaporStore.DataProcessor.Dto.Import
{
    [XmlType("Purchase")]
    public class ImportPurchaseDTO
    {
        [XmlAttribute("title")]
        [Required]
        public string Title { get; set; }

        [Required]
        [XmlElement("Type")]
        public string Type { get; set; }

        [Required]
        [XmlElement("Key")]
        [RegularExpression(@"^([A-Z0-9]{4}-[A-Z0-9]{4}-[A-Z0-9]{4})$")]
        public string Key { get; set; }

        [Required]
        [RegularExpression(@"^(\d{4} \d{4} \d{4} \d{4})$")]
        public string Card { get; set; }

        [Required]
        public string Date { get; set; }
    }
//    •	Type – enumeration of type PurchaseType, with possible values(“Retail”, “Digital”) (required) 
//•	ProductKey – text, which consists of 3 pairs of 4 uppercase Latin letters and digits, separated by dashes(ex. “ABCD-EFGH-1J3L”) (required)
//•	Date – Date(required)
//•	CardId – integer, foreign key(required)
//•	Card – the purchase’s card(required)

  //  <Purchases>
  //<Purchase title = "Dungeon Warfare 2" >
  //  < Type > Digital </ Type >
  //  < Key > ZTZ3 - 0D2S-G4TJ</Key>
  //  <Card>1833 5024 0553 6211</Card>
  //  <Date>07/12/2016 05:49</Date>
  //</Purchase>

}
