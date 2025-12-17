using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace PaniqueEnCuisine
{
    internal class ManagerColision
    {
        public ManagerColision() { }

        public bool VerifierColision(Canvas Canvas,Joueur Joueur, Image ImageJoueur,string ObjetColision)
        {
            bool Avancer = true;
            foreach (var x in Canvas.Children.OfType<Rectangle>())
            {
                if ((string)x.Tag == ObjetColision)
                {
                    Rect PlayerHitbox = new Rect(Canvas.GetLeft(ImageJoueur), Canvas.GetTop(ImageJoueur), ImageJoueur.Width, ImageJoueur.Height);
                    Rect PlateformeCommade = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);

                    if (PlayerHitbox.IntersectsWith(PlateformeCommade))
                    {
                        //SConsole.WriteLine($"Collision detectée entre le JoueurImage et {ObjetColision} !");
                        Joueur.Vitesse = 0;
                        Canvas.SetTop(ImageJoueur, Canvas.GetTop(x) - Joueur.Hauteur);
                        Canvas.SetLeft(ImageJoueur, Canvas.GetLeft(x) - Joueur.Largeur);
                        Avancer= false;
                    }
                    else
                    { 
                        Joueur.Vitesse = 2;
                    }

                }
            }
            return Avancer;
        }
        

        

        public bool VeriferColision_PLAYER_FrIgo(Canvas Canvas,Image ImageJoueur,Joueur Joueur)
        {
            //Console.WriteLine("début des colsision");
            bool colision = false;
            foreach (var x in Canvas.Children.OfType<Image>())
            {
                //Console.WriteLine("entre dans la boucle des vérification");
                if ((string)x.Tag == "Frigo" )
                {
                    //Console.WriteLine($"detectée des Avancer entre  {_X.Name}  et  {ImageJoueur.Name} !");
                    Rect PlayerHitbox = new Rect(Canvas.GetLeft(ImageJoueur), Canvas.GetTop(ImageJoueur), ImageJoueur.Width, ImageJoueur.Height);
                    Rect PlateformeCommade = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);

                    //Console.WriteLine($"position palyeur  left{Canvas.GetLeft(ImageJoueur)},{Canvas.GetTop(ImageJoueur)}");
                    //Console.WriteLine($"position palyeur  left {Canvas.GetLeft(_X)},top  {Canvas.GetTop(_X)}");

                    if (PlateformeCommade.IntersectsWith(PlayerHitbox))
                    {
                        //Console.WriteLine($"Collision detectée entre le  {_X.Name}  et  {JoueurImage.Nom} !");
                        Joueur.Vitesse = 0;
                        colision = true;

                    }
                    else
                    {
                        //Console.WriteLine("Aucune collision entre ImageJoueur et les _OutilsCuisine de cuisine.");
                        Joueur.Vitesse = 2;


                    }
                }
            }
            return colision;
        }

        public bool VeriferColision_PLAYER_Four(Canvas Canvas, Image ImageJoueur, Joueur Joueur)
        {
            //Console.WriteLine("début des colsision");
            bool colision = false;
            foreach (var x in Canvas.Children.OfType<Image>())
            {
                //Console.WriteLine("entre dans la boucle des vérification");
                if ((string)x.Tag == "Four")
                {
                    //Console.WriteLine($"detectée des Avancer entre  {_X.Name}  et  {ImageJoueur.Name} !");
                    Rect PlayerHitbox = new Rect(Canvas.GetLeft(ImageJoueur), Canvas.GetTop(ImageJoueur), ImageJoueur.Width, ImageJoueur.Height);
                    Rect PlateformeCommade = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);

                    //Console.WriteLine($"position palyeur  left{Canvas.GetLeft(ImageJoueur)},{Canvas.GetTop(ImageJoueur)}");
                    //Console.WriteLine($"position palyeur  left {Canvas.GetLeft(_X)},top  {Canvas.GetTop(_X)}");

                    if (PlateformeCommade.IntersectsWith(PlayerHitbox))
                    {
                        //Console.WriteLine($"Collision detectée entre le  {_X.Name}  et  {JoueurImage.Nom} !");
                        Joueur.Vitesse = 0;
                        colision = true;

                    }
                    else
                    {
                        //Console.WriteLine("Aucune collision entre ImageJoueur et les _OutilsCuisine de cuisine.");
                        Joueur.Vitesse = 2;


                    }
                }
            }
            return colision;
        }


        public bool VeriferColision_PLAYER_table(Canvas Canvas, Image ImageJoueur, Joueur Joueur)
        {
            //Console.WriteLine("début des colsision");
            bool colision = false;
            foreach (var x in Canvas.Children.OfType<Image>())
            {
                //Console.WriteLine("entre dans la boucle des vérification");
                if ((string)x.Tag == "TableDeCraft")
                {
                    //Console.WriteLine($"detectée des Avancer entre  {x.Name}  et  {ImageJoueur.Name} !");
                    Rect PlayerHitbox = new Rect(Canvas.GetLeft(ImageJoueur), Canvas.GetTop(ImageJoueur), ImageJoueur.Width, ImageJoueur.Height);
                    Rect PlateformeCommade = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);

                    //Console.WriteLine($"position palyeur  left{Canvas.GetLeft(ImageJoueur)},{Canvas.GetTop(ImageJoueur)}");
                    //Console.WriteLine($"position palyeur  left {Canvas.GetLeft(x)},top  {Canvas.GetTop(x)}");

                    if (PlateformeCommade.IntersectsWith(PlayerHitbox))
                    {
                        //Console.WriteLine($"Collision detectée entre le  {x.Name}  et  {Joueur.Nom} !");
                        Joueur.Vitesse = 0;
                        colision = true;

                    }
                    else
                    {
                        //Console.WriteLine("Aucune collision entre ImageJoueur et les _OutilsCuisine de cuisine.");
                        Joueur.Vitesse = 2;


                    }
                }
            }
            return colision;
        }
        public bool VeriferColision_PLAYER_Caisse(Canvas Canvas, Image JoueurImage, Joueur Joueur)
        {
            bool colision = false;

            foreach (var x in Canvas.Children.OfType<Image>())
            {
                if ((string)x.Tag == "Caisse")
                {
                    Rect PlayerHitbox = new Rect(
                        Canvas.GetLeft(JoueurImage),
                        Canvas.GetTop(JoueurImage),
                        Joueur.Largeur,
                        Joueur.Hauteur
                    );

                    Rect CaisseHitbox = new Rect(
                        Canvas.GetLeft(x),
                        Canvas.GetTop(x),
                        x.Width,
                        x.Height
                    );

                    if (CaisseHitbox.IntersectsWith(PlayerHitbox))
                    {
                        Joueur.Vitesse = 0;
                        colision = true;
                    }
                    else
                    {
                        Joueur.Vitesse = 2;
                    }
                }
            }

            return colision;
        }
    }
}
