using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Repositories
{
    public class DecorationRepository : IRepository<IDecoration>
    {
        private List<IDecoration> decRep;
        public DecorationRepository()
        {
            this.decRep = new List<IDecoration>();
        }

        public IReadOnlyCollection<IDecoration> Models => this.decRep.AsReadOnly();

        public void Add(IDecoration model)
        {
            this.decRep.Add(model);
        }

        public IDecoration FindByType(string type)
        {
            return this.decRep.FirstOrDefault(x => x.GetType().Name == type);
        }

        public bool Remove(IDecoration model)
        {
            return this.decRep.Remove(model);
        }
    }
}
