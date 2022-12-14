using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace ConsoleApp1
{
    internal class Program
    {
        static void InvokeDaInvoke<T>(T[] data)
        {
            var type = typeof(T);
            var methods = type.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance);
            foreach (var method in methods)
            {
                foreach (var item in data)
                {
                    method.Invoke(item, new object[1] {333});
                }
            }
        }
        
        static void Main(string[] args)
        {
            var cars = new Car[]
            {
                new Car(1,2),
                new Car(3,4),
                new Car(4,5),
                new Car(5,6),
                new Car(6,7)
            };
            InvokeDaInvoke(cars);
        }
    }
    
}