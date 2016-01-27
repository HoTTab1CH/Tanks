using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Tanks
{
    class Pacman : IRun, ITurn, ITransparent, ICurrentPicture
    {
        public Pacman(int sizeField)
        {
            this.sizeField = sizeField;
            this.x = 180;
            this.y = 360;
            this.Direct_x = 0;
            this.Direct_y = -1;
            NextDirect_x = 0;
            NextDirect_y = -1;

            PutImg();
            PutCurrentImage();
        }

        public int X
        {
            get
            {
                return x;
            }

        }
        public int Y
        {
            get
            {
                return y;
            }

        }
        public int Direct_x
        {
            get
            {
                return direct_x;
            }

            set
            {
                if (value == 0 || value == -1 || value == 1)
                    direct_x = value;
                else
                    direct_x = 0;
            }
        }
        public int Direct_y
        {
            get
            {
                return direct_y;
            }

            set
            {
                if (value == 0 || value == -1 || value == 1)
                    direct_y = value;
                else
                    direct_y = 0;
            }
        }
        public int NextDirect_x
        {
            get
            {
                return nextDirect_x;
            }

            set
            {
                if (value == 0 || value == -1 || value == 1)
                    nextDirect_x = value;
                else
                    nextDirect_x = 0;
            }
        }
        public int NextDirect_y
        {
            get
            {
                return nextDirect_y;
            }

            set
            {
                if (value == 0 || value == -1 || value == 1)
                    nextDirect_y = value;
                else
                    nextDirect_y = 0;
            }
        }
        public Image CurrentImg
        {
            get
            {
                return currentImg;
            }
        }

        public void Run()
        {
            x += Direct_x;
            y += Direct_y;
            if (Math.IEEERemainder(x, 60) == 0 && Math.IEEERemainder(y, 60) == 0)
                Turn();
            PutCurrentImage();
            Transparent();
        }
        public void Turn()
        {
            Direct_x = NextDirect_x;
            Direct_y = NextDirect_y;
            PutImg();
        }
        public void Transparent()
        {
            if (x == -1)
                x = sizeField - 31;
            if (x == sizeField - 29)
                x = 1;

            if (y == -1)
                y = sizeField - 31;
            if (y == sizeField - 29)
                y = 1;
        }

        void PutImg()
        {
            if (direct_x == 1)
                img = pacmanImg.Right;
            if (direct_x == -1)
                img = pacmanImg.Left;
            if (direct_y == 1)
                img = pacmanImg.Down;
            if (direct_y == -1)
                img = pacmanImg.Up;
        }
        private void PutCurrentImage()
        {
            //currentImg = img[k];
            //k++;
            //if (k == 4)
            //    k = 0;

            k++;
            if (k >= 0 && k < 5)
                currentImg = img[0];
            else if (k >= 5 && k <= 10)
                currentImg = img[1];
            else if (k >= 10 && k < 15)
                currentImg = img[2];
            else if (k >= 15 && k < 20)
                currentImg = img[3];
            else
                k = 0;
        }

        int sizeField;
        int x, y, direct_x, direct_y, nextDirect_x, nextDirect_y;
        int k;

        PacmanImg pacmanImg = new PacmanImg();
        Image[] img;
        Image currentImg;
    }
}
