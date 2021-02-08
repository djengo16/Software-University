using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnlineShop.Models.Products.Peripherals;
using System.Diagnostics.CodeAnalysis;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private readonly ICollection<Computer> computers;
        private readonly ICollection<Component> components;
        private readonly ICollection<Peripheral> peripherals;

        public Controller()
        {
            this.computers = new List<Computer>();
            this.components = new List<Component>();
            this.peripherals = new List<Peripheral>();
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            if (computers.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComputerId);
            }

            if (computerType == "DesktopComputer")
            {
                computers.Add(new DesktopComputer(id, manufacturer, model, price));
                return String.Format(SuccessMessages.AddedComputer, id);
            }
            if (computerType == "Laptop")
            {
                computers.Add(new Laptop(id, manufacturer, model, price));
                return String.Format(SuccessMessages.AddedComputer, id);
            }

            throw new ArgumentException(ExceptionMessages.InvalidComputerType);
        }
        public string AddComponent(int computerId, int id, string componentType,
            string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            if (!CheckIfComputerExist(computerId))
            {
                return ExceptionMessages.NotExistingComputerId;
            }

            if (components.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComponent);
            }
            Component component;

            switch (componentType)
            {
                case "CentralProcessingUnit":
                    component = new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case "Motherboard":
                    component = new Motherboard(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case "PowerSupply":
                    component = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case "RandomAccessMemory":
                    component = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case "SolidStateDrive":
                    component = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case "VideoCard":
                    component = new VideoCard(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                default:
                    throw new ArgumentException(ExceptionMessages.InvalidComponentType);
            }
            computers.FirstOrDefault(x => x.Id == computerId).AddComponent(component);
            components.Add(component);

            return String.Format(SuccessMessages.AddedComponent, component.GetType().Name, component.Id, computerId);
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            if (!CheckIfComputerExist(computerId))
            {
                return ExceptionMessages.NotExistingComputerId;
            }
            Component componentToRemove = (Component)computers.FirstOrDefault(x => x.Id == computerId)
                .Components.FirstOrDefault(x => x.GetType().Name == componentType);

            computers.FirstOrDefault(x => x.Id == computerId).RemoveComponent(componentType);

            components.Remove(componentToRemove);

            return String.Format(SuccessMessages.RemovedComponent, componentToRemove.GetType().Name, componentToRemove.Id);
        }

        public string AddPeripheral(int computerId, int id, string peripheralType,
            string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            if (!CheckIfComputerExist(computerId))
            {
                return ExceptionMessages.NotExistingComputerId;
            }
            if(peripherals.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingPeripheralId);
            }

            Peripheral peripheral;

            switch (peripheralType)
            {
                case "Headset":
                    peripheral = new Headset(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
                case "Keyboard":
                    peripheral = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
                case "Monitor":
                    peripheral = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
                case "Mouse":
                    peripheral = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
                default:
                    throw new ArgumentException(ExceptionMessages.InvalidPeripheralType);
            }

            computers.FirstOrDefault(x => x.Id == computerId).AddPeripheral(peripheral);
            peripherals.Add(peripheral);

            return String.Format(SuccessMessages.AddedPeripheral, peripheral.GetType().Name, id, computerId);
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            if (!CheckIfComputerExist(computerId))
            {
                return ExceptionMessages.NotExistingComputerId;
            }
            Peripheral peripheralToRemove = (Peripheral)computers.FirstOrDefault(x => x.Id == computerId)
                .Peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType);

            computers.FirstOrDefault(x => x.Id == computerId).RemovePeripheral(peripheralType);

            peripherals.Remove(peripheralToRemove);

            return String.Format(SuccessMessages.RemovedPeripheral, peripheralToRemove.GetType().Name, peripheralToRemove.Id);
        }
        public string BuyBest(decimal budget)
        {
            var bestComputers = computers.Where(x => x.Price <= budget)
                 .OrderByDescending(x => x.OverallPerformance)
                 .ToList();

            var bestComputerForThisBudget = bestComputers.FirstOrDefault();

            if(bestComputerForThisBudget == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.CanNotBuyComputer, budget));
            }

            return bestComputerForThisBudget.ToString();
        }

        public string BuyComputer(int id)
        {
            
            Computer computerToBuy = computers.FirstOrDefault(x => x.Id == id);

            computers.Remove(computerToBuy);
            if(computerToBuy == null)
            {
                return string.Empty;
            }
            return computerToBuy.ToString();
        }

        public string GetComputerData(int id)
        {
            
            Computer computer = computers.FirstOrDefault(x => x.Id == id);

            if(computer != null)
            {
                return computer.ToString();
            }
            return null;
        }

        private bool CheckIfComputerExist(int computerId)
        {
            return computers.Any(x => x.Id == computerId);
        }


    }
}
