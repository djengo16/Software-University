using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Models.Products.Components
{
    public abstract class Component : Product, IComponent
    {
        protected Component(int id, string manufacturer, string model, decimal price, double overallPerformance,int generation)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            this.Generation = generation;
        }

        public int Generation { get; }

        public override string ToString()
        {
            return $"Overall Performance: {this.OverallPerformance:F2}." +
                $" Price: {this.Price:F2} - {this.GetType().Name}:" +
                $" {this.Manufacturer} {this.Model} (Id: {this.Id}) Generation: {this.Generation}";
        }
    }
}
