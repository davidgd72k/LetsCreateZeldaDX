using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsCreateZeldaDX.Manager
{
    public static class ManagerFunction
    {
        private static readonly Random Rnd = new Random();

        public static int Random(int min, int max)
        {
            return Rnd.Next(min, max+1);
        }
    }
}
