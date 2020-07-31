﻿using PetStore.Models.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace PetStore.ServiceModels.Products.InputModels
{
    public class AddProductInputServiceModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }
        public ProductType ProductType { get; set; }
    }
}