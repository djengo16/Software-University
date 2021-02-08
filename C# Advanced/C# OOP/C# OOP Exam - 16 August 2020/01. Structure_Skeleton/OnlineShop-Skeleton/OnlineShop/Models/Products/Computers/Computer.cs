using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace OnlineShop.Models.Products.Computers
{

    public abstract class Computer : Product, IComputer
    {
        private readonly List<IComponent> components;
        private readonly List<IPeripheral> peripherals;
        private readonly double performance;
        private readonly decimal computerPrice;
        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
            performance = overallPerformance;
            computerPrice = price;
            
           // this.OverallPerformance += components.Sum(c => c.OverallPerformance);

         //  this.Price += components.Sum(c => c.Price) + peripherals.Sum(p => p.Price);

        }

        public override double OverallPerformance =>  performance + components.Average(c => c.OverallPerformance);

        public override decimal Price => computerPrice + components.Sum(c => c.Price) + peripherals.Sum(p => p.Price);


        public IReadOnlyCollection<IComponent> Components => components;
        public IReadOnlyCollection<IPeripheral> Peripherals => peripherals;

        public void AddComponent(IComponent component)
        {
            //    If the components collection contains a component with the same component type,
            //        throw an ArgumentException with the message "Component {component type} already exists in {computer type} with Id {id}."
            IComponent componentToSearch = components.FirstOrDefault(x => x.GetType().Name == component.GetType().Name);

            if (componentToSearch != null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.ExistingComponent, component.GetType().Name,
                    this.GetType().Name, this.Id));
            }

            components.Add(component);
        }
        public IComponent RemoveComponent(string componentType)
        {
            //If the components collection is empty or does not have a component of that type,
            //throw an ArgumentException with the message "Component {component type} does not exist in {computer type} with Id {id}."
            //Otherwise remove the component of that type and return it.

            IComponent componentToRemove = components.FirstOrDefault(x => x.GetType().Name == componentType);

            if (componentToRemove == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.NotExistingComponent, componentType, this.GetType().Name,
                    this.Id));
            }
            components.Remove(componentToRemove);

            return componentToRemove;

        }
        public void AddPeripheral(IPeripheral peripheral)
        {
            //If the peripherals collection contains a peripheral with the same peripheral type,
            //throw an ArgumentException with the message "Peripheral {peripheral type} already exists in {computer type} with Id {id}."
            //Otherwise add the peripheral in peripherals collection.

            IPeripheral peripheralToSearch = peripherals.FirstOrDefault(p => p.GetType().Name == peripheral.GetType().Name);

            if (peripheralToSearch != null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.ExistingPeripheral, peripheral.GetType().Name,
                    this.GetType().Name, this.Id));
            }

            this.peripherals.Add(peripheral);

        }
        public IPeripheral RemovePeripheral(string peripheralType)
        {
            IPeripheral peripheralToRemove = peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType);

            if (peripheralToRemove == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.NotExistingPeripheral, peripheralType, this.GetType().Name,
                    this.Id));
            }

            peripherals.Remove(peripheralToRemove);

            return peripheralToRemove;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Overall Performance: {this.OverallPerformance:F2}." +
                $" Price: {this.Price:F2} - {this.GetType().Name}: {this.Manufacturer} {this.Model} (Id: {this.Id})");

            sb.AppendLine($" Components ({this.components.Count}):");

            if (this.components.Count != 0)
            {
                foreach (var component in this.components)
                {
                    sb.AppendLine("  " + component.ToString());
                }
            }

            sb.Append($" Peripherals ({this.peripherals.Count});");
            if (peripherals.Count == 0)
            {
                sb.AppendLine($" Average Overall Performance (0.00):");
            }
            else {
                sb.AppendLine($" Average Overall Performance ({this.peripherals.Average(p => p.OverallPerformance)}:F2):");
            }
            if (this.peripherals.Count != 0)
            {
                foreach (var peripherial in this.peripherals)
                {
                    sb.AppendLine("  " + peripherial.ToString());
                }
            }
            return sb.ToString().TrimEnd();
        }
    }
}
