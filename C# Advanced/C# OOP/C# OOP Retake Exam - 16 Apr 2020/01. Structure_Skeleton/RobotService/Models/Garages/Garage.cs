using RobotService.Models.Garages.Contracts;
using RobotService.Models.Robots;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotService.Models.Garages
{
    public class Garage : IGarage
    {
        private readonly Dictionary<string,IRobot> robots;

        public Garage()
        {
            this.robots = new Dictionary<string, IRobot>();
        }

        public IReadOnlyDictionary<string, IRobot> Robots => robots;

        private const int Capacity  = 10;

        public void Manufacture(IRobot robot)
        {
            //If there isn't enough capacity in the garage throw an InvalidOperationException with the message "Not enough capacity"
            //If a robot with this name already exists in the garage, throw an ArgumentException with the message "Robot {robot name} already exist"
            //In any other case, add the current robot to the garage.

            if(this.Robots.Count == Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }

            if(this.Robots.Any(x => x.Value.Name == robot.Name))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.ExistingRobot, robot.Name));
            }

            robots.Add(robot.Name, robot);
                
        }

        public void Sell(string robotName, string ownerName)
        {
            //If a robot with that name exists, change its owner, its bought status and remove the robot from the garage.
            

            if (!this.Robots.Any(x => x.Value.Name == robotName))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InexistingRobot,robotName));
            }

            IRobot robot = Robots.Values.FirstOrDefault(x => x.Name == robotName);

            this.robots.Remove(robotName);

            robot.Owner = ownerName;
            robot.IsBought = true;
        }
    }
}
