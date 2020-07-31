﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PetStore.ServiceModels.Products.OutputModels
{
    public class ProductDetailsServiceModel
    {
        
        public string Name { get; set; }
       
        public decimal Price { get; set; }
        public string ProductType { get; set; }
    }
}
