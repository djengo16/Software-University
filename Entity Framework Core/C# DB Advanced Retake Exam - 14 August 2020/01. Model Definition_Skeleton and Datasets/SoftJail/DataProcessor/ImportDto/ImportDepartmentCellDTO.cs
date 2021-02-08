using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SoftJail.DataProcessor.ImportDto
{
    public class ImportDepartmentCellDTO
    {
        [Required]
        [MinLength(3),MaxLength(25)]
        public string Name { get; set; }

        public ICollection<ImportCellDTO> Cells { get; set; }
    }
    //"Name": "",
    //"Cells": [
    //  {
    //    "CellNumber": 101,
    //    "HasWindow": true

}
