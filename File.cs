using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
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

        // Liste des frames d'animation
        private readonly List<BitmapImage> _walkFrames = new()
        {
            new BitmapImage(new System.Uri("Images/Person1.png", System.UriKind.Relative))
            new BitmapImage(new System.Uri("Images/Person2.png", System.UriKind.Relative)),
            new BitmapImage(new System.Uri("Images/Person3.png", System.UriKind.Relative))
        };
        private void CreateInitialPeople(Canvas Maincanvas)
        {
            for (int i = 0; i < InitialQueueCount; i++)
            {
                AddNewPerson(-i * PersonSpacing,Maincanvas);
            }
        }

        private void AddNewPerson(double offsetY = 0,Canvas MainCanvas)
        {
            Image img = new Image
            {
                Width = 20,
                Height = 20,
                Source = _walkFrames[0]
            };

            MainCanvas.Children.Add(img);
            Canvas.SetLeft(img, 90);
            Canvas.SetTop(img, 20 + offsetY);

            _queuePeople.Add(new Annimation_PNJ { Img = img });
        }

        private void StartMovement()
        {
            _timer = new DispatcherTimer
            {
                Interval = System.TimeSpan.FromMilliseconds(30)
            };
            _timer.Tick += MovePeople;
            _timer.Start();
        }

        private void AnimatePerson(Annimation_PNJ person)
        {
            // Change la frame à chaque tick pour créer l'animation
            person.FrameIndex = (person.FrameIndex + 1) % _walkFrames.Count;
            person.Img.Source = _walkFrames[person.FrameIndex];
        }

        private void MovePeople(object sender, System.EventArgs e)
        {
            double stopY = Canvas.GetTop(StopRect);

            // ---- FILE D’ATTENTE ----
            for (int i = 0; i < _queuePeople.Count; i++)
            {
                AnimatedPerson current = _queuePeople[i];
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
                        StopRect.Fill = Brushes.Red;

                        _queuePeople.RemoveAt(0);
                        _passedPeople.Add(current);

                        AddNewPerson(-PersonSpacing);
                    }
                }
                else
                {
                    AnimatedPerson front = _queuePeople[i - 1];
                    double frontY = Canvas.GetTop(front.Img);

                    if (frontY - y > PersonSpacing)
                        Canvas.SetTop(current.Img, y + Speed);
                }
            }

            // ---- PERSONNES APRÈS LE STOP ----
            for (int i = _passedPeople.Count - 1; i >= 0; i--)
            {
                AnimatedPerson person = _passedPeople[i];
                double y = Canvas.GetTop(person.Img);

                AnimatePerson(person);
                Canvas.SetTop(person.Img, y + Speed);

                if (y > MainCanvas.ActualHeight)
                {
                    MainCanvas.Children.Remove(person.Img);
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
                StopRect.Fill = Brushes.Green;
            }
        }
    }
}
