using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace PaniqueEnCuisine
{
    internal class MapManager
    {
        private static readonly bool up;
        private static readonly bool down;
        private static readonly bool left;
        private static readonly bool right;
        private static readonly bool run;

        private double x ;
        private double y ;
        private static readonly double defaultspeed = 4;
        private static readonly double runspeed = 10;
        private double actualspeed; 

        public MapManager()
        {
            this.x = x;
            this.y = y;
            this.defaultspeed = defaultspeed;
            this.runspeed = runspeed;
            
        }

        private void MoveBall(object? sender, EventArgs e)
        {
            if (up) y -= actualspeed;
            if (down) y += actualspeed;
            if (left) x -= actualspeed;
            if (right) x += actualspeed;
            if (run) actualspeed = runspeed;
            if (!run) actualspeed = defaultspeed;

            Canvas.SetLeft(Ball, x);
            Canvas.SetTop(Ball, y);
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Z: up = true; break;
                case Key.S: down = true; break;
                case Key.Q: left = true; break;
                case Key.D: right = true; break;
                case Key.LeftShift: run = true; break;
            }
        }
        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Z: up = false; break;
                case Key.S: down = false; break;
                case Key.Q: left = false; break;
                case Key.D: right = false; break;
                case Key.LeftShift: run = false; break;

            }
        }
    }
}
