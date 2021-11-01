using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzThreading
{
    class Temperature
    {
        public float Temp;
        private Random rand = new Random();


        public void GenerateRandomTemperature()
        {
            Temp = rand.Next(-20, 120);
        }
    }
}
