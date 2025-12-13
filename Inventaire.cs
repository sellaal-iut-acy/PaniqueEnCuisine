using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace PaniqueEnCuisine
{
    public  class Inventaire
    {
        private List<Nouriture> _liste_nourriture = new List<Nouriture>();
        private int current_page = 0;
        private bool ouvert = false;

        public Inventaire(List<Nouriture> liste_nourriture,int current_page)
        {
            this.Liste_nourriture = liste_nourriture;
            this.Current_page = current_page;
        }

        public void Cree_inventaire(Canvas grille, ref Button page_suivante, ref Button page_arriere)
        {
            Rectangle inventaire = new Rectangle();
            inventaire.Width = 460;
            inventaire.Height = 250;
            inventaire.Fill = Brushes.Gray;
            Canvas.SetTop(inventaire, 237);
            Canvas.SetLeft(inventaire, 165);
            grille.Children.Add(inventaire);
            page_suivante.Content = ">";
            page_suivante.Width = 30;
            page_suivante.Height = 50;
            Canvas.SetTop(page_suivante, 386);
            Canvas.SetLeft(page_suivante, 586);
            grille.Children.Add(page_suivante);
            page_arriere.Content = "<";
            page_arriere.Width = 30;
            page_arriere.Height = 50;
            Canvas.SetTop(page_arriere, 386);
            Canvas.SetLeft(page_arriere, 176);
            grille.Children.Add(page_arriere);
        }

        private void Page_suivante_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void afficher_objet_inventaire(Inventaire inventaire,Canvas grille , int page)
        {
            Console.WriteLine($"Affichage de la page {page}");
            Console.WriteLine($"Nombre d'objets dans l'inventaire : {inventaire.Liste_nourriture.Count}");

            int nb_objet = 0;

            for (int c = 0; c < 6 * (page - 1) + 6 && c <= inventaire.Liste_nourriture.Count - 1; c++)
            {

                while (nb_objet < 6)
                {
                    if (nb_objet > inventaire.Liste_nourriture.Count - 1)
                        break;
                    Image image = new Image();
                    image.Source = inventaire.Liste_nourriture[nb_objet].Image.Source;
                    Canvas.SetTop(image, 260 + (c * 63));
                    Canvas.SetLeft(image, 213 + (nb_objet * 63));
                    grille.Children.Add(image);
                    Console.WriteLine($"Position de l'objet : Top {Canvas.GetTop(inventaire.Liste_nourriture[nb_objet].Image)} Left {Canvas.GetLeft(inventaire.Liste_nourriture[c].Image)}");
                    nb_objet++;
                }

            }
        }
        public void cree_slot_inventaire(Canvas grille)
        {
            for (int l = 0; l < 3; l++)
            {
                for (int c = 0; c < 6; c++)
                {
                    Rectangle slot = new Rectangle();
                    slot.Width = 50;
                    slot.Height = 50;
                    Canvas.SetTop(slot, 260 + (l * 63));
                    Canvas.SetLeft(slot, 213 + (c * 63));
                    slot.Fill = Brushes.LightGray;
                    grille.Children.Add(slot);
                }
            }
        }
        public void teste_inventer_player(Joueur playeur)
        {
            Nouriture pizza = new Nouriture("pizza", "plat");
            Nouriture burger = new Nouriture("burger", "plat");

            playeur.ajouter_objet_inventaire(pizza);
            playeur.ajouter_objet_inventaire(burger);
        }
        public void Inventaire_player(Joueur playeur,Canvas grille,ref Button page_suivante, ref Button Page_arriere)
        {
            Cree_inventaire(grille,ref page_suivante, ref Page_arriere );
            cree_slot_inventaire(grille);
            teste_inventer_player(playeur);
            afficher_objet_inventaire(playeur.Inventaire,grille,1);
        }

        public List<Nouriture> Liste_nourriture
        {
            get
            {
                return this._liste_nourriture;
            }

            set
            {
                this._liste_nourriture = value;
            }
        }

        public int Current_page
        {
            get
            {
                return this.current_page;
            }

            set
            {
                this.current_page = value;
            }
        }

        public bool Ouvert
        {
            get
            {
                return this.ouvert;
            }

            set
            {
                this.ouvert = value;
            }
        }
    }
}
