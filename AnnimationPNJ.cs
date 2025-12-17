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
    internal class AnnimationPNJ
    {

        private Image _ImgFrame = new Image();
        private int _NumersoFrame = 0;
        public AnnimationPNJ(Image ImageFrame, int Numeros_Frame)
        {
            ImgFrame = ImageFrame;
            NumerosFrame = Numeros_Frame;
        }
        public int NumerosFrame
        {
            get
            {
                return this._NumersoFrame;
            }

            set
            {
                this._NumersoFrame = value;
            }
        }

        public Image ImgFrame
        {
            get
            {
                return this._ImgFrame;
            }

            set
            {
                this._ImgFrame = value;
            }
        }
    }
}
