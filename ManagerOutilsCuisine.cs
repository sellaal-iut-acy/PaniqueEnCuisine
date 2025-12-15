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
        private List<OutilsCusine> outils = new List<OutilsCusine>();

        public ManagerOutilsCuisine(List<OutilsCusine> outils)
        {
            this.Outils = outils;
        }

        public List<OutilsCusine> Outils
        {
            get
            {
                return this.outils;
            }
            set
            {
                this.outils = value;
            }
        }
        public void AjouterOutil(OutilsCusine outil)
        {
            this.outils.Add(outil);
        }
        public void RetirerOutil(OutilsCusine outil)
        {
            this.outils.Remove(outil);
        }

        public void AfficherOutilsCuisine(System.Windows.Controls.Canvas grille)
        {
            foreach (OutilsCusine outil in this.outils)
            {
                outil.afficher_outi(grille);
            }
        }

        public void veriffe_colision_palyer_outils(Canvas grille , Image playeur,Joueur joueur)
        {
            ManagerColision jeux = new ManagerColision();
            jeux.VeriferColision_PLAYER_FrIgo(grille, playeur,joueur);
        }

       
    }
}
