using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pszzle
{
    struct LvlParams
    {
        public int xBarrel;
        public int yBarrel;
        public int xCharacter;
        public int yCharacter;
        public int xExit;
        public int yExit;

        public LvlParams(int xBarrel, int yBarrel, int xCharacter, int yCharacter, int xExit, int yExit)
        {
            this.xBarrel = xBarrel;
            this.yBarrel = yBarrel;
            this.xCharacter = xCharacter;
            this.yCharacter = yCharacter;
            this.xExit = xExit;
            this.yExit = yExit;
        }
    }

    class Field
    {
        public int Width { get; set;}
        public int Height { get; set; }
        public List<int[]> WallsX { get; set; }
        public List<int[]> WallsY { get; set; }
        public List<LvlParams> lvlParams { get; set; }
        public int lvlNum;

        public Field ()
        {
            Width = 30;
            Height = 20;
            WallsX = new List<int[]>();
            WallsY = new List<int[]>();
            lvlParams = new List<LvlParams>();
            lvlNum = 0;

            string filePath = Directory.GetCurrentDirectory() + "\\lvlParams.txt";
            string[] strParams = File.ReadAllLines(filePath);
            for (int i = 0; i < strParams.Length; i+=3)
            {
                WallsX.Add(Array.ConvertAll(strParams[i].Split(' '), int.Parse));
                WallsY.Add(Array.ConvertAll(strParams[i + 1].Split(' '), int.Parse));
                string[] par = strParams[i + 2].Split(' ');
                lvlParams.Add(new LvlParams(int.Parse(par[0]), int.Parse(par[1]), int.Parse(par[2]), int.Parse(par[3]), int.Parse(par[4]), int.Parse(par[5]) ));
            }
        }

        public bool checkWallExist(int x, int y)
        {
            for(int i = 0; i < WallsX[lvlNum].Length; i++)
            {
                if(x == WallsX[lvlNum][i] && y == WallsY[lvlNum][i])
                {
                    return true;
                }
            }
            return false;
        }

        public void Nextlvl()
        {
            lvlNum++;
        }
    }
}
