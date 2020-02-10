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
        private List<IDecoration> decorationRepository;

        public IReadOnlyCollection<IDecoration> Models => this.decorationRepository.AsReadOnly();

        public DecorationRepository()
        {
            decorationRepository = new List<IDecoration>();
        }

        public void Add(IDecoration model)
        {
            this.decorationRepository.Add(model);
        }

        public IDecoration FindByType(string type)
        {
            IDecoration searched = null;
            foreach (var decoration in decorationRepository)
            {
                if(type == "Plant")
                {
                    if(decoration is Plant)
                    {
                        searched = decoration;
                        break;
                    }
                }
                if (type == "Ornament")
                {
                    if (decoration is Ornament)
                    {
                        searched = decoration;
                        break;
                    }
                }
            }

            return searched;
        }

        public bool Remove(IDecoration model)
        {
            return decorationRepository.Remove(model);
        }
    }
}
