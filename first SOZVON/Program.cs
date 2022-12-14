using System.Net;
using System.Reflection;
using System.Xml.Linq;

namespace ConsoleApp1
{
    internal class Program
    {
        public static string Replace(string template, object options)
        {
            var result = template;
            var properties = options.GetType().GetProperties();

            foreach (var property in properties)
            {
                var value = property.GetValue(options);
                var name = property.Name;

                result = result.Replace($"{{{name}}}", value?.ToString());
            }

            return result;
        } 
        
        static void Main(string[] args)
        {
            var template = "Authorization:{Authorization}\nSubscription:{Subscription}\nProjectIdentifier:{ProjectIdentifier}\nProjectId:{ProjectId}";
            var options = new Options
            {
                Authorization = "123",
                ProjectId = 44,
                ProjectIdentifier = Guid.NewGuid().ToString(),
                Subscription = Guid.NewGuid().ToString()
            };
            Console.WriteLine(Replace(template, options));
            
        }
    }
}