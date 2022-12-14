using Net18RealReflection.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net18RealReflection.ConsoleApp
{
    internal class Person
    {
        [PropertyName("name")]
        public string Name { get; set; }
        
        [PropertyName("age")]
        public int Chislo { get; set; }

        [PropertyName("gey?")]
        public bool Ili { get; set; }
    }

}
