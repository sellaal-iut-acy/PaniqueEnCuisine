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
        private List<Annimation_PNJ> _queuePeople = new();
        private List<Annimation_PNJ> _passedPeople = new();
        private DispatcherTimer _timer;

        private bool _isGateClosed = true;
        private bool _firstHasPassed = false;

        private const double Speed = 2;
        private const double PersonSpacing = 30;
        private const int InitialQueueCount = 8;
        private Canvas _canvas;
        private Rectangle _rect;


        // Liste des frames d'animation
        private readonly List<BitmapImage> _walkFrames = new()
        {
            new BitmapImage(new System.Uri("Images/Person1.png", System.UriKind.Relative)),
            new BitmapImage(new System.Uri("Images/Person2.png", System.UriKind.Relative)),
            new BitmapImage(new System.Uri("Images/Person3.png", System.UriKind.Relative))
        };

        public File( ref DispatcherTimer timer, ref Canvas canvas,ref Rectangle rect)
        {
            this._timer = timer;
            this.Canvas = canvas;
            this.Rect = rect;
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
                return this._rect;
            }

            set
            {
                this._rect = value;
            }
        }

        private void CreateInitialPeople()
        {
            for (int i = 0; i < InitialQueueCount; i++)
            {
                AddNewPerson(-i * PersonSpacing);
            }
        }

        private void AddNewPerson(double offsetY = 0)
        {
            Image img = new Image
            {
                Width = 20,
                Height = 20,
                Source = _walkFrames[0],
                Name = "Client"
            };
            
            
            Canvas.SetLeft(img, 100);
            Canvas.SetTop(img, 300 + offsetY);
            _queuePeople.Add(new Annimation_PNJ(img,0));
            this.Canvas.Children.Add(img);
            Console.WriteLine($"le personnage est ajouter {img.Name} x :{Canvas.GetLeft(img)}, y:{Canvas.GetTop(img)}");
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
            _timer.Tick += MovePeople;
        }

        public void cree_File(Rectangle rect,Canvas ca)
        {
            this.CreateInitialPeople();
            this.StartMovement();
            set_rectangel(rect,Canvas);
        }

        private void AnimatePerson(Annimation_PNJ person)
        {
            // Change la frame à chaque tick pour créer l'animation
            person.FrameIndex1 = (person.FrameIndex1 + 1) % _walkFrames.Count;
            person.Img.Source = _walkFrames[person.FrameIndex1];
        }

        private void MovePeople(object sender, System.EventArgs e)
        {
            double stopY = System.Windows.Controls.Canvas.GetTop(this.Rect);

            // ---- FILE D’ATTENTE ----
            for (int i = 0; i < _queuePeople.Count; i++)
            {
                Annimation_PNJ current = _queuePeople[i];
                double y = Canvas.GetTop(current.Img);

                AnimatePerson(current);

                if (i == 0)
                {
                    if (_isGateClosed && y + current.Img.Height + Speed >= stopY)
                        continue;

                    Canvas.SetTop(current.Img, y + Speed);

                    if (!_isGateClosed && !_firstHasPassed &&
                        y < stopY && y + Speed >= stopY)
                    {
                        _firstHasPassed = true;
                        _isGateClosed = true;
                        this.Rect.Fill = Brushes.Red;

                        _queuePeople.RemoveAt(0);
                        _passedPeople.Add(current);

                        AddNewPerson(-PersonSpacing);
                    }
                }
                else
                {
                    Annimation_PNJ front = _queuePeople[i - 1];
                    double frontY = Canvas.GetTop(front.Img);

                    if (frontY - y > PersonSpacing)
                        Canvas.SetTop(current.Img, y + Speed);
                }
                
            }

            // ---- PERSONNES APRÈS LE STOP ----
            for (int i = _passedPeople.Count - 1; i >= 0; i--)
            {
                Annimation_PNJ person = _passedPeople[i];
                double y = Canvas.GetTop(person.Img);

                AnimatePerson(person);
                Canvas.SetTop(person.Img, y + Speed);

                if (y > this.Canvas.ActualHeight)
                {
                   this.Canvas.Children.Remove(person.Img);
                    _passedPeople.RemoveAt(i);
                }
            }
        }

        private void StopRect_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (_isGateClosed && _queuePeople.Count > 0)
            {
                _isGateClosed = false;
                _firstHasPassed = false;
                this.Rect.Fill = Brushes.Green;
            }
        }
    }
}
