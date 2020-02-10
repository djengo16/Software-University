using System;
using System.Collections.Generic;
using System.Text;

namespace RawData
{
    public class Engine
    {
        //{engineSpeed} {enginePower} 


        private int enginePower;
        private int engineSpeed;

        public Engine(int enginePower, int engineSpeed)
        {
            EnginePower = enginePower;
            EngineSpeed = engineSpeed;
        }

        public int EnginePower
        {
            get { return enginePower; }
            set { enginePower = value; }
        }      
        public int EngineSpeed
        {
            get { return engineSpeed; }
            set { engineSpeed = value; }
        }

    }
}
