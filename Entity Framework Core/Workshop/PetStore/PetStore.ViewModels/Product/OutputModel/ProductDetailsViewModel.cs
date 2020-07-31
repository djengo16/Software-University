using System;
using System.Collections.Generic;
using System.Text;

namespace PetStore.ViewModels.Product.OutputModel
{
    public class ProductDetailsViewModel
    {
        public string Name { get; set; }

        public decimal Price { get; set; }
        public string ProductType { get; set; }
    }
}
