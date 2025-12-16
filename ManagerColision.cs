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

        public bool VerifierColision(Canvas grille,Joueur Player , Image image,string colision)
        {
            bool Avancer = true;
            foreach (var x in grille.Children.OfType<Rectangle>())
            {
                if ((string)x.Tag == colision)
                {
                    Rect PlayerHitbox = new Rect(Canvas.GetLeft(image), Canvas.GetTop(image), image.Width, image.Height);
                    Rect PlateformeCommade = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);

                    if (PlayerHitbox.IntersectsWith(PlateformeCommade))
                    {
                        //SConsole.WriteLine($"Collision detectée entre le joueur et {colision} !");
                        Player.Vitesse = 0;
                        Canvas.SetTop(image, Canvas.GetTop(x) - Player.Height);
                        Canvas.SetLeft(image, Canvas.GetLeft(x) - Player.Width);
                        Avancer= false;
                    }
                    else
                    { 
                        Player.Vitesse = 2;
                    }

                }
            }
            return Avancer;
        }
        

        

        public bool VeriferColision_PLAYER_FrIgo(Canvas grille,Image playeur,Joueur joueur)
        {
            //Console.WriteLine("début des colsision");
            bool colision = false;
            foreach (var x in grille.Children.OfType<Image>())
            {
                //Console.WriteLine("entre dans la boucle des vérification");
                if ((string)x.Tag == "Frigo" )
                {
                    //Console.WriteLine($"detectée des Avancer entre  {x.Name}  et  {playeur.Name} !");
                    Rect PlayerHitbox = new Rect(Canvas.GetLeft(playeur), Canvas.GetTop(playeur), playeur.Width, playeur.Height);
                    Rect PlateformeCommade = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);

                    //Console.WriteLine($"position palyeur  left{Canvas.GetLeft(playeur)},{Canvas.GetTop(playeur)}");
                    //Console.WriteLine($"position palyeur  left {Canvas.GetLeft(x)},top  {Canvas.GetTop(x)}");

                    if (PlateformeCommade.IntersectsWith(PlayerHitbox))
                    {
                        //Console.WriteLine($"Collision detectée entre le  {x.Name}  et  {joueur.Nom} !");
                        joueur.Vitesse = 0;
                        colision = true;

                    }
                    else
                    {
                        //Console.WriteLine("Aucune collision entre playeur et les outils de cuisine.");
                        joueur.Vitesse = 2;


                    }
                }
            }
            return colision;
        }

        public bool VeriferColision_PLAYER_Four(Canvas grille, Image playeur, Joueur joueur)
        {
            //Console.WriteLine("début des colsision");
            bool colision = false;
            foreach (var x in grille.Children.OfType<Image>())
            {
                //Console.WriteLine("entre dans la boucle des vérification");
                if ((string)x.Tag == "Four")
                {
                    //Console.WriteLine($"detectée des Avancer entre  {x.Name}  et  {playeur.Name} !");
                    Rect PlayerHitbox = new Rect(Canvas.GetLeft(playeur), Canvas.GetTop(playeur), playeur.Width, playeur.Height);
                    Rect PlateformeCommade = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);

                    //Console.WriteLine($"position palyeur  left{Canvas.GetLeft(playeur)},{Canvas.GetTop(playeur)}");
                    //Console.WriteLine($"position palyeur  left {Canvas.GetLeft(x)},top  {Canvas.GetTop(x)}");

                    if (PlateformeCommade.IntersectsWith(PlayerHitbox))
                    {
                        //Console.WriteLine($"Collision detectée entre le  {x.Name}  et  {joueur.Nom} !");
                        joueur.Vitesse = 0;
                        colision = true;

                    }
                    else
                    {
                        //Console.WriteLine("Aucune collision entre playeur et les outils de cuisine.");
                        joueur.Vitesse = 2;


                    }
                }
            }
            return colision;
        }


        public bool VeriferColision_PLAYER_table(Canvas grille, Image playeur, Joueur joueur)
        {
            Console.WriteLine("début des colsision");
            bool colision = false;
            foreach (var x in grille.Children.OfType<Image>())
            {
                Console.WriteLine("entre dans la boucle des vérification");
                if ((string)x.Tag == "TableDeCraft")
                {
                    Console.WriteLine($"detectée des Avancer entre  {x.Name}  et  {playeur.Name} !");
                    Rect PlayerHitbox = new Rect(Canvas.GetLeft(playeur), Canvas.GetTop(playeur), playeur.Width, playeur.Height);
                    Rect PlateformeCommade = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);

                    Console.WriteLine($"position palyeur  left{Canvas.GetLeft(playeur)},{Canvas.GetTop(playeur)}");
                    Console.WriteLine($"position palyeur  left {Canvas.GetLeft(x)},top  {Canvas.GetTop(x)}");

                    if (PlateformeCommade.IntersectsWith(PlayerHitbox))
                    {
                        Console.WriteLine($"Collision detectée entre le  {x.Name}  et  {joueur.Nom} !");
                        joueur.Vitesse = 0;
                        colision = true;

                    }
                    else
                    {
                        Console.WriteLine("Aucune collision entre playeur et les outils de cuisine.");
                        joueur.Vitesse = 2;


                    }
                }
            }
            return colision;
        }
        public bool VeriferColision_PLAYER_Caisse(Canvas grille, Image playeur, Joueur joueur)
        {
            bool colision = false;

            foreach (var x in grille.Children.OfType<Image>())
            {
                if ((string)x.Tag == "Caisse")
                {
                    Rect PlayerHitbox = new Rect(
                        Canvas.GetLeft(playeur),
                        Canvas.GetTop(playeur),
                        playeur.Width,
                        playeur.Height
                    );

                    Rect CaisseHitbox = new Rect(
                        Canvas.GetLeft(x),
                        Canvas.GetTop(x),
                        x.Width,
                        x.Height
                    );

                    if (CaisseHitbox.IntersectsWith(PlayerHitbox))
                    {
                        joueur.Vitesse = 0;
                        colision = true;
                    }
                    else
                    {
                        joueur.Vitesse = 2;
                    }
                }
            }

            return colision;
        }


    }
}
