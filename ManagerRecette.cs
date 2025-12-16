using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaniqueEnCuisine
{
    internal class ManagerRecette
    {
        private List<Recette> ListeRecete = new List<Recette>();

        public ManagerRecette()
        {
            
        }

        private void AjoutRecette(Recette newRecette)
        {
            ListeRecete.Add(newRecette);
        }

        internal List<Recette> ListeRecete1
        {
            get
            {
                return this.ListeRecete;
            }

            set
            {
                this.ListeRecete = value;
            }
        }
    }
}
