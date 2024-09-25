using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Perudo
{
    public class Player
    {
        static Random rnd = new Random();
        public Player(){
            rnd = new Random();
        }
        public int id;
        public string name;
        public List<Cube> cubes = new List<Cube>();
       
        public void generetionCubes() { 
            cubes.Clear();
            for(int i = 0; i <= 3; i++) {
                cubes.Add(new Cube());
            }
        }

        public string getCubes() {
            string numbers = cubes[0].n.ToString() + " " + cubes[1].n.ToString() + " " + cubes[2].n.ToString() + " " + cubes[3].n.ToString();
            return numbers;
        }

        public int dropCube() {
            int i = rnd.Next(1, 7);
        return i;
        }

     
    }
}
