using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public class CarRepository : IRepository<ICar>
    {
        private readonly List<ICar> models;
        public CarRepository()
        {
            this.models = new List<ICar>();
        }
        public void Add(ICar model)
        {

            models.Add(model);
        }

        public IReadOnlyCollection<ICar> GetAll()
        {
            return models;
        }

        public ICar GetByName(string name)
        {
            
            return models.FirstOrDefault(x => x.Model == name);
        }

        public bool Remove(ICar model)
        {
            return models.Remove(model);
        }

        public IReadOnlyCollection<ICar> Models => models;
    }
}
