using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Tanks
{
    public delegate void StripDel();

    class Model
    {
        public List<Tank> Tanks
        {
            get
            {
                return tanks;
            }
        }
        public List<Apple> Apples
        {
            get
            {
                return apples;
            }
        }
        public Pacman Pacman
        {
            get
            {
                return pacman;
            }

        }
        public Projectile Projectile
        {
            get
            {
                return projectile;
            }

        }
        public List<FireTank> FireTank
        {
            get
            {
                return fireTank;
            }
        }
        public Wall Wall
        {
            get
            {
                return wall;
            }
        }
        public int SpeedGame
        {
            get
            {
                return speedGame;
            }

        }

        public Model(int sizeField, int amountTanks, int amountApples, int speedGame)
        {
            r = new Random();

            this.sizeField = sizeField;
            this.amountTanks = amountTanks;
            this.amountApples = amountApples;
            this.speedGame = speedGame;

            NewGame();

        }

        public void NewGame()
        {
            step = -30;
            collectedApples = 0;
            pacman = new Pacman(sizeField);
            tanks = new List<Tank>();
            fireTank = new List<FireTank>();
            apples = new List<Apple>();
            projectile = new Projectile();

            CreateTanks();
            CreateApples(collectedApples);

            wall = new Wall();
            gameStatus = GameStatus.stoped;
        }
        public void Play()
        {
            while (gameStatus == GameStatus.playing)
            {
                Thread.Sleep(speedGame);

                RunAllObjectsOnField();

                TryDestroyTank();
                IfCollisionOfTanks();
                IfCollisionOfPacman();
                IfCollectApple();

                if (collectedApples > 4)
                {
                    gameStatus = GameStatus.won;
                    if (changeStrip != null)
                        changeStrip();
                }

            }
        }

        void RunAllObjectsOnField()
        {
            projectile.Run();
            pacman.Run();
            ((Hunter)tanks[0]).Run(pacman.X, pacman.Y);
            for (int i = 1; i < tanks.Count; i++)
                tanks[i].Run();

            foreach (FireTank ft in fireTank)
                ft.Fire();
        }
        void IfCollectApple()
        {
            for (int i = 0; i < apples.Count; i++)
                if ((Math.Abs(pacman.X - apples[i].X) < 2 && Math.Abs(pacman.Y - apples[i].Y) < 2))
                {
                    apples[i] = new Apple(step += 30, 420);
                    CreateApples(++collectedApples);
                }
        }
        void IfCollisionOfPacman()
        {
            for (int i = 0; i < tanks.Count; i++)
                if
                    (
                    (Math.Abs(tanks[i].X - pacman.X) <= 25 && (tanks[i].Y == pacman.Y))
                    ||
                    (Math.Abs(tanks[i].Y - pacman.Y) <= 25 && (tanks[i].X == pacman.X))
                    ||
                    (Math.Abs(tanks[i].X - pacman.X) <= 25 && Math.Abs(tanks[i].Y - pacman.Y) <= 25)
                    )
                {
                    gameStatus = GameStatus.lost;
                    if (changeStrip != null)
                        changeStrip();
                }
        }
        void IfCollisionOfTanks()
        {
            for (int i = 0; i < tanks.Count - 1; i++)
                for (int j = i + 1; j < tanks.Count; j++)
                    if
                        (
                        (Math.Abs(tanks[i].X - tanks[j].X) <= 30 && (tanks[i].Y == tanks[j].Y))
                        ||
                        (Math.Abs(tanks[i].Y - tanks[j].Y) <= 30 && (tanks[i].X == tanks[j].X))

                        ||
                        (Math.Abs(tanks[i].X - tanks[j].X) <= 30 && Math.Abs(tanks[i].Y - tanks[j].Y) <= 30)
                        )
                    {
                        if (i == 0)
                            ((Hunter)tanks[i]).TurnAround();
                        else
                            tanks[i].TurnAround();
                        tanks[j].TurnAround();
                    }
        }
        void TryDestroyTank()
        {
            for (int i = 1; i < tanks.Count; i++)
                if (
                   ((projectile.X - tanks[i].X) < 24 && (projectile.Y - tanks[i].Y) < 24) &&
                   (tanks[i].X - projectile.X) < 13 && (tanks[i].Y - projectile.Y) < 13)
                {
                    fireTank.Add(new FireTank(tanks[i].X, tanks[i].Y));
                    tanks.RemoveAt(i);
                    projectile.DefaultSettings();
                }
        }
        void CreateApples(int newApples)
        {
            int x, y;
            while (apples.Count < amountApples + newApples)
            {
                x = r.Next(6) * 60;
                y = r.Next(6) * 60;
                bool flag = true;

                foreach (Apple a in apples)
                    if (a.X == x && a.Y == y)
                    {
                        flag = false;
                        break;
                    }

                if (flag == true)
                    apples.Add(new Apple(x, y));
            }


        }
        void CreateApples()
        {
            CreateApples(0);
        }
        void CreateTanks()
        {


            int x, y;
            while (tanks.Count < amountTanks + 1)
            {
                if (tanks.Count == 0)
                    tanks.Add(new Hunter(sizeField, r.Next(6) * 60, r.Next(6) * 60));

                x = r.Next(6) * 60;
                y = r.Next(6) * 60;
                bool flag = true;

                foreach (Tank t in tanks)
                    if (t.X == x && t.Y == y)
                    {
                        flag = false;
                        break;
                    }

                if (flag == true)
                    tanks.Add(new Tank(sizeField, x, y));

            }

        }

        public event StripDel changeStrip;
        public GameStatus gameStatus;

        int speedGame;
        int sizeField;
        int amountTanks;
        int amountApples;
        int collectedApples;
        int step;

        Random r;
        Projectile projectile;
        Pacman pacman;
        List<Tank> tanks;
        List<FireTank> fireTank;
        List<Apple> apples;
        Wall wall;


    }
}
