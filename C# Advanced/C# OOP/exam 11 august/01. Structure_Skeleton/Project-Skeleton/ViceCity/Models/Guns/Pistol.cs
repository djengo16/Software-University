using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models.Guns
{
    public class Pistol : Gun
    {

        //Has 10 bullets per barrel and 100 total bullets.

        private const int PistolBulletsPerBarrel = 10;
        private const int PistolTotalBullets = 100;
        private const int BulletsPerFire = 1;



        public Pistol(string name) 
            : base(name, PistolBulletsPerBarrel, PistolTotalBullets)
        {
        }

        public override int Fire()
        {
            if (BulletsPerBarrel < BulletsPerFire)
            {
                this.Reload(PistolBulletsPerBarrel);
            }
            int firedBullets = this.DecreaseBullets(BulletsPerFire);
            return firedBullets;
        }
    }
}
