using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace PaniqueEnCuisine
{
    internal class File
    {
        private List<AnnimationPNJ> _FileClient= new();
        private List<AnnimationPNJ> _ClientsPasser = new();
        private DispatcherTimer _timer;

        private bool _PorteFermer = true;
        private bool _PremierPasser = false;

        private const double _Vitesse = 2;
        private const double _EspaceEntreCleint = 30;
        private const int _NombreMaxClient = 8;
        private Canvas _canvas;
        private Rectangle _RectStop;


        // Liste des frames d'animation
        private readonly List<BitmapImage> _FrameDeplacement = new()
        {
            new BitmapImage(new System.Uri("Images/Person1.png", System.UriKind.Relative)),
            new BitmapImage(new System.Uri("Images/Person2.png", System.UriKind.Relative)),
            new BitmapImage(new System.Uri("Images/Person3.png", System.UriKind.Relative))
        };

        public File( ref DispatcherTimer timer, ref Canvas canvas,ref Rectangle RectStop)
        {
            this._timer = timer;
            this.Canvas = canvas;
            this.Rect = RectStop;
        }

        public Canvas Canvas
        {
            get
            {
                return this._canvas;
            }

            set
            {
                this._canvas = value;
            }
        }

        public Rectangle Rect
        {
            get
            {
                return this._RectStop;
            }

            set
            {
                this._RectStop = value;
            }
        }

        public static double Vitesse
        {
            get
            {
                return _Vitesse;
            }
        }

        internal List<AnnimationPNJ> FilClient
        {
            get
            {
                return this._FileClient;
            }

            set
            {
                this._FileClient = value;
            }
        }

        internal List<AnnimationPNJ> ClientsPasser
        {
            get
            {
                return this._ClientsPasser;
            }

            set
            {
                this._ClientsPasser = value;
            }
        }

        public static int NombreMaxClient
        {
            get
            {
                return _NombreMaxClient;
            }
        }

        public bool PorteFermer
        {
            get
            {
                return this._PorteFermer;
            }

            set
            {
                this._PorteFermer = value;
            }
        }

        public bool PremierPasser
        {
            get
            {
                return this._PremierPasser;
            }

            set
            {
                this._PremierPasser = value;
            }
        }

        public static double EspaceEntreCleint
        {
            get
            {
                return _EspaceEntreCleint;
            }
        }

        public static double EspaceEntreCleint1
        {
            get
            {
                return _EspaceEntreCleint;
            }
        }

        public Rectangle RectStop
        {
            get
            {
                return this._RectStop;
            }

            set
            {
                this._RectStop = value;
            }
        }

        public List<BitmapImage> FrameDeplacement
        {
            get
            {
                return this._FrameDeplacement;
            }
        }

        private void CreePremierClient()
        {
            for (int i = 0; i < NombreMaxClient; i++)
            {
                AddNewPerson(-i * EspaceEntreCleint);
            }
        }

        private void AddNewPerson(double offsetY = 0)
        {
            Image img = new Image
            {
                Width = 20,
                Height = 20,
                Source = FrameDeplacement[0],
                Name = "Client"
            };
            
            
            Canvas.SetLeft(img, 100);
            Canvas.SetTop(img, 300 + offsetY);
            _FileClient.Add(new AnnimationPNJ(img,0));
            this.Canvas.Children.Add(img);
            Console.WriteLine($"le personnage est ajouter {img.Name} _X :{Canvas.GetLeft(img)}, _Y:{Canvas.GetTop(img)}");
        }
        private void set_rectangel(Rectangle rect,Canvas Canvas)
        {
            Rect.Fill = Brushes.Red;
            Canvas.SetLeft(Rect, 0);
            Canvas.SetTop(Rect, 0);
            Canvas.Children.Add(Rect);
        }

        private void StartMovement()
        {
            _timer.Tick += DeplacementClients;
        }

        public void CreeFileClients(Rectangle RectStop)
        {
            this.CreePremierClient();
            this.StartMovement();
            set_rectangel(RectStop,Canvas);
        }

        private void AnimationClient(AnnimationPNJ Client)
        {
            // Change la frame à chaque tick pour créer l'animation
            Client.NumerosFrame = (Client.NumerosFrame + 1) % FrameDeplacement.Count;
            Client.ImgFrame.Source = FrameDeplacement[Client.NumerosFrame];
        }

        private void DeplacementClients(object sender, System.EventArgs e)
        {
            double stopY = System.Windows.Controls.Canvas.GetTop(this.Rect);

            // ---- FILE D’ATTENTE ----
            for (int i = 0; i < _FileClient.Count; i++)
            {
                AnnimationPNJ FileActuelClient = _FileClient[i];
                double y = Canvas.GetTop(FileActuelClient.ImgFrame);

                AnimationClient(FileActuelClient);

                if (i == 0)
                {
                    if (_PorteFermer && y + FileActuelClient.ImgFrame.Height + Vitesse >= stopY)
                        continue;

                    Canvas.SetTop(FileActuelClient.ImgFrame, y + Vitesse);

                    if (!_PorteFermer && !_PremierPasser &&
                        y < stopY && y + _Vitesse >= stopY)
                    {
                        _PremierPasser = true;
                        _PorteFermer = true;
                        this.RectStop.Fill = Brushes.Red;

                        _FileClient.RemoveAt(0);
                        ClientsPasser.Add(FileActuelClient);

                        AddNewPerson(-EspaceEntreCleint);
                    }
                }
                else
                {
                    AnnimationPNJ front = _FileClient[i - 1];
                    double frontY = Canvas.GetTop(front.ImgFrame);

                    if (frontY - y > EspaceEntreCleint)
                        Canvas.SetTop(FileActuelClient.ImgFrame, y + Vitesse);
                }
                
            }

            // ---- PERSONNES APRÈS LE STOP ----
            for (int i = ClientsPasser.Count - 1; i >= 0; i--)
            {
                AnnimationPNJ ClientsPassees = ClientsPasser[i];
                double y = Canvas.GetTop(ClientsPassees.ImgFrame);

                AnimationClient(ClientsPassees);
                Canvas.SetTop(ClientsPassees.ImgFrame, y + Vitesse);

                if (y > this.Canvas.ActualHeight)
                {
                   this.Canvas.Children.Remove(ClientsPassees.ImgFrame);
                    this.ClientsPasser.RemoveAt(i);
                }
            }
        }

        private void StopRect_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (PorteFermer && FilClient.Count > 0)
            {
                PorteFermer = false;
                PremierPasser = false;
                this.Rect.Fill = Brushes.Green;
            }
        }
    }
}
