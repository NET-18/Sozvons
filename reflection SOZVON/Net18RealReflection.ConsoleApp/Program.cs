namespace Net18RealReflection.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person()
            {
                Name = "jopolize",
                Chislo = 12,
                Ili = false
            };
            //Converter.Initialize("name:pip;age:20;gey?:true", person);

            Console.WriteLine(Converter.GetString(person));
            
        }
    }
}