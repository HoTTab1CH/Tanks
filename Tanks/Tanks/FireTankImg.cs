using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tanks
{
    class FireTankImg
    {
        Image[] img = new Image[]
            {
            Properties.Resources.TankFire0,
            Properties.Resources.TankFire1,
            Properties.Resources.TankFire2,
            Properties.Resources.TankFire3,
            Properties.Resources.TankFire4,
            Properties.Resources.TankFire5,
            Properties.Resources.TankFire6,
            };

        public Image[] Img
        {
            get
            {
                return img;
            }

        }
    }
}
