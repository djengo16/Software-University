namespace CounterStrike
{
    using CounterStrike.Core;
    using CounterStrike.Core.Contracts;
    using CounterStrike.Models.Guns;
    using CounterStrike.Models.Players;
    using CounterStrike.Models.Players.Contracts;
    using CounterStrike.Repositories;
    using CounterStrike.Repositories.Contracts;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();

            //IRepository<IPlayer> repo = new PlayerRepository();

            //repo.Add(new Terrorist("check", 20, 10, new Pistol("pistol", 2)));

            //IPlayer terr = repo.FindByName("check");

            //terr.TakeDamage(200);
        }
    }
}
