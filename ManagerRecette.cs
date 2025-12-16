using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaniqueEnCuisine
{
    internal class ManagerRecette
    {
        private List<Recette> _ListeRecetes = new List<Recette>();

        public ManagerRecette()
        {
            
        }

        private void AjoutRecette(Recette newRecette)
        {
            ListeRecetes.Add(newRecette);
        }

        internal List<Recette> ListeRecetes
        {
            get
            {
                return this._ListeRecetes;
            }

            set
            {
                this._ListeRecetes = value;
            }
        }
    }
}
