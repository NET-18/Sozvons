using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Car
    {
        public int wheels;
        public int doors;
                
        private void Move()
        {

        }
        public void Drive(int a)
        {
            Console.WriteLine("Wheels,{0} {1}",wheels, a);
        }
        public void Flex(int a)
        {
            Console.WriteLine("Doors,{0} {1}", doors, a);
        }
        public Car(int wheels, int doors)
        {
            this.wheels = wheels;
            this.doors = doors;
        }
    }
}
