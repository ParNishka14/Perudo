using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perudo
{
    public class Cube
    {
       public static Random rnd = new Random();
        public int n = rnd.Next(1, 7);
      
        public void regenerateNumber() {
            n = rnd.Next(1, 7);
        }
    }
}
