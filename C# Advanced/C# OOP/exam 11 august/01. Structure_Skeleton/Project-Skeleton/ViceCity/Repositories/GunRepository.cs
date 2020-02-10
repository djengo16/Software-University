using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Repositories.Contracts;

namespace ViceCity.Repositories
{
    public class GunRepository : IRepository<IGun>
    {
        private Dictionary<string, IGun> gunsByName;

        public IReadOnlyCollection<IGun> Models  =>
            this.gunsByName.Values.ToList().AsReadOnly();

        public GunRepository()
        {
            this.gunsByName = new Dictionary<string, IGun>();
        }

        public void Add(IGun model)
        {
            if (!gunsByName.ContainsKey(model.Name))
            {
                this.gunsByName.Add(model.Name, model);
            }
        }

        public IGun Find(string name)
        {
            IGun gun = null;
            return  gun = gunsByName.Values.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IGun model)
        {
            return gunsByName.Remove(model.Name);
        }
    }
}
