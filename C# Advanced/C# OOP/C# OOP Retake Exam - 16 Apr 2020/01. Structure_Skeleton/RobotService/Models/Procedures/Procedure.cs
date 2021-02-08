using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots;
using RobotService.Models.Robots.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models.Procedures
{
    public abstract class Procedure : IProcedure
    {

       

        public Procedure()
        {
            this.Robots = new List<IRobot>();
        }

        public virtual void DoService(IRobot robot, int procedureTime) { }
        protected IList<IRobot> Robots { get; }
        public string History()
        {
            //           "{procedure type}"
            //" Robot type: {robot type} - {robot name} - Happiness: {happiness} - Energy: {energy}"
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.GetType().Name}");
            foreach (var robot in this.Robots)
            {
                sb.AppendLine(robot.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
