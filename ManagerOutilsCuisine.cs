using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PaniqueEnCuisine
{ 
    internal class ManagerOutilsCuisine
    {
        private List<OutilsCusine> _OutilsCuisine = new List<OutilsCusine>();

        public ManagerOutilsCuisine(List<OutilsCusine> outils)
        {
            this.OutilsCuisine = outils;
        }

        internal List<OutilsCusine> OutilsCuisine
        {
            get
            {
                return this._OutilsCuisine;
            }

            set
            {
                this._OutilsCuisine = value;
            }
        }

        public void AjouterOutil(OutilsCusine outil)
        {
            this.OutilsCuisine.Add(outil);
        }
        public void RetirerOutil(OutilsCusine outil)
        {
            this.OutilsCuisine.Remove(outil);
        }

        public void AfficherOutilsCuisine(System.Windows.Controls.Canvas grille)
        {
            foreach (OutilsCusine outil in this.OutilsCuisine)
            {
                outil.AfficherOutil(grille);
            }
        }

        public void Veriffe_Colision_Palyer_Outils(Canvas grille , Image playeur,Joueur joueur)
        {
            ManagerColision jeux = new ManagerColision();
            jeux.VeriferColision_PLAYER_FrIgo(grille, playeur,joueur);
        }

       
    }
}
