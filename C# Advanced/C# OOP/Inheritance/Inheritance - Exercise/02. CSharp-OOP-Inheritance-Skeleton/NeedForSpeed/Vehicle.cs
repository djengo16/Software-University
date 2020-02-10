namespace NeedForSpeed
{
    public class Vehicle
    {
        public const double DefaultFuelConsumption = 1.25;

        public Vehicle(int horsePower, double fuel)
        {
            HorsePower = horsePower;
            Fuel = fuel;
        }

        public virtual double FuelConsumption =>
            DefaultFuelConsumption;

        public int HorsePower { get; set; }
        public double Fuel { get; set; }

        public virtual void Drive(double km)
        {
            bool checkFuel = this.Fuel - km * FuelConsumption >= 0;

            if (checkFuel)
            {
                this.Fuel -= km * FuelConsumption;
            }
        }
    }
}
