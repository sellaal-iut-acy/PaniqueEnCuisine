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
        private int nb_page = 1;
        private int old_page = 0;
        private int max_page ;

        public Inventaire(List<Nouriture> liste_nourriture,int current_page)
        {
            this.Liste_nourriture = liste_nourriture;
            this.Current_page = current_page;
            this.old_page = this.current_page;
            set_page_max();
            
        }
        public void set_page_max()
        {
            Console.WriteLine("mis a jour de page max");
            if (this.Liste_nourriture.Count % 18 != 0)
                this.Max_page += 1 + this.Liste_nourriture.Count / 18;
            else
                this.Max_page += this.Liste_nourriture.Count / 18;
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

            int nb_objet_par_linge = 0;
            int nb_objet_totale = 0;

            for (int c = (page-1)*6; c < 6 * (page - 1) + 6 && c <= inventaire.Liste_nourriture.Count - 1; c++)
            {   
                nb_objet_par_linge = 0;
                while (nb_objet_par_linge < 6 )
                {
                    //Console.WriteLine($"le nombre d'objet est {nb_objet_totale}");
                    if (nb_objet_totale >= 18)
                    {
                        //Console.WriteLine("passer");
                        break;
                    }
                        
                    
                    if (nb_objet_totale > inventaire.Liste_nourriture.Count - 1 )
                    {
                        break;
                    }
                    Image image = new Image();
                    image.Source = inventaire.Liste_nourriture[nb_objet_totale].Image.Source;
                    Canvas.SetTop(image, 260 + (c * 63));
                    Canvas.SetLeft(image, 213 + (nb_objet_par_linge * 63));
                    grille.Children.Add(image);
                    Console.WriteLine($"Position de l'objet : Top {Canvas.GetTop(inventaire.Liste_nourriture[nb_objet_totale].Image)} Left {Canvas.GetLeft(inventaire.Liste_nourriture[c].Image)}");
                    nb_objet_par_linge++;
                    nb_objet_totale++;
                    this.max_page++;
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
        public void page_suivante(Canvas canvas, Inventaire Liste_nourriture)
        {
            if (Liste_nourriture.current_page < Liste_nourriture.max_page)
            {
                this.current_page++;
                afficher_objet_inventaire(Liste_nourriture, canvas, this.current_page);
            }
            
        }
        public void  page_precedent(Canvas canvas, Inventaire Liste_nourriture)
        {
            if (!(Liste_nourriture.current_page == 0))
            {
                this.current_page--;
                afficher_objet_inventaire(Liste_nourriture, canvas, this.current_page);
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

        public int Nb_page
        {
            get
            {
                return this.nb_page;
            }

            set
            {
                this.nb_page = value;
            }
        }

        public int Old_page
        {
            get
            {
                return this.old_page;
            }

            set
            {
                this.old_page = value;
            }
        }

        public int Max_page
        {
            get
            {
                return this.max_page;
            }

            set
            {
                this.max_page = value;
            }
        }

        public int Max_page1
        {
            get
            {
                return this.max_page;
            }

            set
            {
                this.max_page = value;
            }
        }
    }
}
