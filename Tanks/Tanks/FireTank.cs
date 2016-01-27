using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tanks
{
    class FireTank
    {
        FireTankImg ftImg = new FireTankImg();
        Image currentImg;
        Image[] img;
        int x, y;
        int k;

        public Image CurrentImg
        {
            get
            {
                return currentImg;
            }

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
        public FireTank(int x, int y)
        {
            this.x = x;
            this.y = y;
            img = ftImg.Img;
            PutCurrentImage();
        }
        public void Fire()
        {
            PutCurrentImage();
        }
        protected void PutCurrentImage()
        {
            currentImg = img[k];
            k++;
            if (k == 7)
                k = 0;

        }
    }
}
