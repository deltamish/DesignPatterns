using AbstractFactoryPattern.Interfaces;
using System;
using System.Linq;
using System.Reflection;

namespace AbstractFactoryPattern
{
    //goal is to create and return a converter calss depeding on the Tool ia mexporitng to Unity,Unreal,Blender
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write type of Converter you need Unity,Unreal,Blender");
            string converter = Console.ReadLine();
            IConverterFactory converterFactory= null;
            try
            {
                var type = from cl in Assembly.GetExecutingAssembly().GetTypes()
                                   where cl.IsClass && cl.Namespace == "AbstractFactoryPattern"
                                   where cl.FullName.Equals($"AbstractFactoryPattern.Factories.{converter}ConverterFactory")
                                   select cl;
                converterFactory =  (IConverterFactory)Activator.CreateInstance(type.First());//Unity Container . get
            }
            catch (Exception e)
            {
                converterFactory = null;
            }

            if (converterFactory == null) {
                Console.WriteLine($"{converter} not defined");
            }
            else
            {
                Console.WriteLine($"{}");
            }

            Console.Read();

        }
    }
}
