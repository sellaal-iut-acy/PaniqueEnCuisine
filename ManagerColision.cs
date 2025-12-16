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
        public bool VerifierColision(Canvas grille,Image img_Client,PNJ Client)
        {
            bool Avancer = true;
            foreach (var x in grille.Children.OfType<Rectangle>())
            {
                if((string)x.Tag == "commande")
                {
                    if (Client.Servi)
                    {
                        Client.Vitesse = 2;
                    }
                    else 
                    {
                        Rect PlayerHitbox = new Rect(Canvas.GetLeft(img_Client), Canvas.GetTop(img_Client), img_Client.Width, img_Client.Height);
                        Rect PlateformeCommade = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);


                        if (PlayerHitbox.IntersectsWith(PlateformeCommade))
                        {
                            
                            Client.Vitesse = 0;
                            Canvas.SetTop(img_Client, Canvas.GetTop(x) - img_Client.Height);
                            Avancer = false;    
                        }
                        else
                        {
                            Client.Vitesse = 2;
                        }
                    }
                    
                }
                
            }
            return Avancer;

        }
        public bool VerifierColision_PNJ_To_PNJ(Canvas grille,PNJ Client)
        {
            bool Avancer = true;
            foreach (var x in grille.Children.OfType<Image>())
            {
                if ((string)x.Tag == "PNJ")
                {
                    if (Client.Servi || Client.Rien_devant1)
                    {
                        
                        Client.Vitesse = 2;
                    }
                    else
                    {
                        
                        Rect PlayerHitbox = new Rect(Canvas.GetLeft(Client.Curenent_Image), Canvas.GetTop(Client.Curenent_Image), Client.Curenent_Image.Width, Client.Curenent_Image.Height);
                        Rect PlateformeCommade = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);

                        if (PlayerHitbox.IntersectsWith(PlateformeCommade))
                        {
                            
                            Client.Vitesse = 0;
                            Avancer = false;

                        }
                        else
                        {
                            
                            if (Avancer)
                                Client.Vitesse = 2;
                            

                        }

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

    }
}
