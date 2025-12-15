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
                        Console.WriteLine($"Collision detectée entre le joueur et {colision} !");
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
                            Console.WriteLine($"Collision detectée entre le joueur {Client.Nom} et la commande !");
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
                        Console.WriteLine($"PNJ {Client.Nom} est servi, il ne vérifie pas les collisions avec les autres PNJ.");
                        Client.Vitesse = 2;
                    }
                    else
                    {
                        Console.WriteLine($"detectée des Avancer entre le PNJ {x.Name}  et PNJ {Client.Nom} !");
                        Rect PlayerHitbox = new Rect(Canvas.GetLeft(Client.Curenent_Image), Canvas.GetTop(Client.Curenent_Image), Client.Curenent_Image.Width, Client.Curenent_Image.Height);
                        Rect PlateformeCommade = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);

                        if (PlayerHitbox.IntersectsWith(PlateformeCommade))
                        {
                            Console.WriteLine($"Collision detectée entre le PNJ {x.Name}  et PNJ {Client.Nom} !");
                            Client.Vitesse = 0;
                            Avancer = false;

                        }
                        else
                        {
                            Console.WriteLine("Aucune collision entre les PNJ.");
                            if (Avancer)
                                Client.Vitesse = 2;
                            

                        }

                    }

                }   
            }
            
            return Avancer;

        }

        public void VeriferColision(Canvas grile)
        {

        }

    }
}
