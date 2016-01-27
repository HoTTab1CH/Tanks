using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tanks
{
    class TankImg
    {
        Image[] up = new Image[]
            {
            Properties.Resources.Tank0_1,
            Properties.Resources.Tank0_1,
            Properties.Resources.Tank0_1,
            Properties.Resources.Tank0_1
            };

        Image[] down = new Image[]
            {
            Properties.Resources.Tank01,
            Properties.Resources.Tank01,
            Properties.Resources.Tank01,
            Properties.Resources.Tank01
            };
        Image[] right = new Image[]
            {
            Properties.Resources.Tank10,
            Properties.Resources.Tank10,
            Properties.Resources.Tank10,
            Properties.Resources.Tank10
            };

        Image[] left = new Image[]
            {
            Properties.Resources.Tank_10,
            Properties.Resources.Tank_10,
            Properties.Resources.Tank_10,
            Properties.Resources.Tank_10
            };

        public Image[] Up
        {
            get
            {
                return up;
            }

        }

        public Image[] Down
        {
            get
            {
                return down;
            }

        }

        public Image[] Right
        {
            get
            {
                return right;
            }

        }

        public Image[] Left
        {
            get
            {
                return left;
            }

        }


    }
}
