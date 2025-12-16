using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace PaniqueEnCuisine
{
    internal class Annimation_PNJ
    {

        private Image img = new Image();
        private int FrameIndex = 0;
        public Annimation_PNJ(Image img, int frameIndex)
        {
            Img = img;
            FrameIndex1 = frameIndex;
        }

        public Image Img
        {
            get
            {
                return this.img;
            }

            set
            {
                this.img = value;
            }
        }

        public int FrameIndex1
        {
            get
            {
                return this.FrameIndex;
            }

            set
            {
                this.FrameIndex = value;
            }
        }
    }
}
