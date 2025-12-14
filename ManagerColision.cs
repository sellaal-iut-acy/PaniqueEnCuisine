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

        public void VerifierColision(Canvas grille,Joueur Player , Image image,string colision)
        {
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
                    }
                    else
                    { 
                        Player.Vitesse = 2;
                    }

                }

            }
        }
        public void VerifierColision(Canvas grille,Image img_Client,PNJ Client)
        {
            foreach (var x in grille.Children.OfType<Rectangle>())
            {
                if((string)x.Tag == "commande")
                {
                    Rect PlayerHitbox = new Rect(Canvas.GetLeft(img_Client),Canvas.GetTop(img_Client), img_Client.Width,img_Client.Height);
                    Rect PlateformeCommade = new Rect(Canvas.GetLeft(x),Canvas.GetTop(x),x.Width,x.Height);
                    
                    if(PlayerHitbox.IntersectsWith(PlateformeCommade))
                    {
                        Console.WriteLine("Collision detectée entre le joueur et la commande !");
                        Client.Vitesse = 0;
                        Canvas.SetTop(img_Client, Canvas.GetTop(x) - img_Client.Height);
                    }
                    else
                    {
                        Client.Vitesse = 2;
                    }

                }

            }

        }
        public void VerifierColision_PNJ_To_PNJ(Canvas grille, Image img_Client, PNJ Client)
        {
            foreach (var x in grille.Children.OfType<Image>())
            {
                if ((string)x.Tag == "PNJ")
                {
                    Rect PlayerHitbox = new Rect(Canvas.GetLeft(img_Client), Canvas.GetTop(img_Client), img_Client.Width, img_Client.Height);
                    Rect PlateformeCommade = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);

                    if (PlayerHitbox.IntersectsWith(PlateformeCommade))
                    {
                        Console.WriteLine("Collision detectée entre le PNJ et PNJ !");
                        Client.Vitesse = 0;
                    }
                    else
                    {
                        Client.Vitesse = 2;
                    }

                }

            }

        }

        public void VeriferColision(Canvas grile)
        {

        }

    }
}
