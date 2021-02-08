using RobotService.Core.Contracts;
using RobotService.Models.Garages;
using RobotService.Models.Garages.Contracts;
using RobotService.Models.Procedures;
using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private readonly IGarage garage;
        private IProcedure chargeProcedure;
        private IProcedure chipProcedure;
        private IProcedure restProcedure;
        private IProcedure polishProcedure;
        private IProcedure techCheckProcedure;
        private IProcedure workProcedure;

        public Controller()
        {
            this.garage = new Garage();
            this.chargeProcedure = new Charge();
            this.chipProcedure = new Chip();
            this.restProcedure = new Rest();
            this.polishProcedure = new Polish();
            this.techCheckProcedure = new TechCheck();
            this.workProcedure = new Work();

        }

        public string Manufacture(string robotType, string name, int energy, int happiness, int procedureTime)
        {

            if (robotType != "HouseholdRobot" && robotType != "PetRobot" && robotType != "WalkerRobot")
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InvalidRobotType, robotType));
            }

            IRobot robot = null;

            if (robotType == "HouseholdRobot")
            {
                robot = new HouseholdRobot(name, energy, happiness, procedureTime);
            }
            if (robotType == "PetRobot")
            {
                robot = new PetRobot(name, energy, happiness, procedureTime);
            }
            if (robotType == "WalkerRobot")
            {
                robot = new WalkerRobot(name, energy, happiness, procedureTime);
            }
            this.garage.Manufacture(robot);

            return $"Robot {name} registered successfully";

        }
        public string Charge(string robotName, int procedureTime)
        {

            IRobot robot = IsExisting(robotName);
            if(robot == null)
            {
                throw new ArgumentException($"Robot {robotName} does not exist") ;
            }
            chargeProcedure.DoService(robot, procedureTime);

            return String.Format(OutputMessages.ChargeProcedure, robotName);
        }

        public string Polish(string robotName, int procedureTime)
        {
            IRobot robot = IsExisting(robotName);
            if (robot == null)
            {
                throw new ArgumentException($"Robot {robotName} does not exist");
            }

            polishProcedure.DoService(robot, procedureTime);

            return String.Format(OutputMessages.PolishProcedure, robotName);
        }
        public string Chip(string robotName, int procedureTime)
        {

            IRobot robot = IsExisting(robotName);
            if (robot == null)
            {
                throw new ArgumentException($"Robot {robotName} does not exist");
            }
            chipProcedure.DoService(robot, procedureTime);

            return String.Format(OutputMessages.ChipProcedure, robotName);
        }
        public string Sell(string robotName, string ownerName)
        {
            ;
            IRobot robot = IsExisting(robotName);
            if (robot == null)
            {
                throw new ArgumentException($"Robot {robotName} does not exist");
            }
            if (robot.IsChipped)
            {
                garage.Sell(robotName, ownerName);
                return string.Format(OutputMessages.SellChippedRobot, ownerName);
            }
            
            garage.Sell(robotName, ownerName);

            return string.Format(OutputMessages.SellNotChippedRobot, ownerName);
        }

        public string History(string procedureType)
        {

            switch (procedureType)
            {
                case "Work":
                    return workProcedure.History();

                case "Charge":
                    return chargeProcedure.History();

                case "Polish":
                    return polishProcedure.History();

                case "Rest":
                    return restProcedure.History();

                case "TechCheck":
                    return techCheckProcedure.History();

                case "Chip":
                    return chipProcedure.History();
            }

            return "";
        }



        public string Rest(string robotName, int procedureTime)
        {
            IRobot robot = IsExisting(robotName);
            if (robot == null)
            {
                throw  new ArgumentException($"Robot {robotName} does not exist");
            }
            restProcedure.DoService(robot, procedureTime);

            return String.Format(OutputMessages.RestProcedure, robotName);
        }


        public string TechCheck(string robotName, int procedureTime)
        {
            IRobot robot = IsExisting(robotName);
            if (robot == null)
            {
                throw new ArgumentException($"Robot {robotName} does not exist");
            }
            techCheckProcedure.DoService(robot, procedureTime);

            return String.Format(OutputMessages.TechCheckProcedure, robotName);
        }

        public string Work(string robotName, int procedureTime)
        {
            
            IRobot robot = IsExisting(robotName);
            if (robot == null)
            {
                throw new ArgumentException($"Robot {robotName} does not exist");
            }

            workProcedure.DoService(robot, procedureTime);

            return $"{robotName} was working for {procedureTime} hours";
        }

        public IRobot IsExisting(string robotName)
        {

            IRobot robot = null;

            if (garage.Robots.ContainsKey(robotName))
            {

                // Console.WriteLine($"Robot {robotName} does not exist");
                return robot = garage.Robots.Values.FirstOrDefault(x => x.Name == robotName);
            }
            return robot;
        }
    }
}
