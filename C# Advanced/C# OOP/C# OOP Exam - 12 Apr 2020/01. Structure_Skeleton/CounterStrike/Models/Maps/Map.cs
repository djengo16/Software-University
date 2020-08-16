using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CounterStrike.Models.Maps
{
    public class Map : IMap
    {
        public string Start(ICollection<IPlayer> players)
        {
            string winMessage = "";


            var terrorists = players
                 .Where(x => x.GetType() == typeof(Terrorist))
                 .ToList();

            var counterTerrorists = players
                .Where(x => x.GetType() == typeof(CounterTerrorist))
                .ToList();

            while (terrorists.Any(t => t.IsAlive) &&
                counterTerrorists.Any(ct => ct.IsAlive))
            {
                foreach (var terrorist in terrorists)
                {
                    if (terrorist.IsAlive)
                    {
                        foreach (var counterTerrorist in counterTerrorists)
                        {
                            counterTerrorist.TakeDamage(terrorist.Gun.Fire());
                        }
                    }
                }


                foreach (var counterTerrorist in counterTerrorists)
                {

                    if (counterTerrorist.IsAlive)
                    {
                        foreach (var terrorist in terrorists)
                        {
                            terrorist.TakeDamage(counterTerrorist.Gun.Fire());
                        }
                    }
                }

                if (!counterTerrorists.Any(ct => ct.IsAlive))
                {
                    winMessage = "Terrorist wins!";
                }

                if (!terrorists.Any(ct => ct.IsAlive))
                {
                    winMessage = "Counter Terrorist wins!";
                }
            }
            return winMessage;

        }
    }
}
