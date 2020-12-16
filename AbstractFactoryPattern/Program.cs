using AbstractFactoryPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AbstractFactoryPattern
{
    //goal is to create and return a converter calss depeding on the Tool ia mexporitng to Unity,Unreal,Blender
    class Program
    {
        static string CheckPassFail(bool param)
        {
            if (param)
            {
                return "Pass";
            }
            else
            {
                return "Fail";
            }
        }
        static void Main(string[] args)
        {
          
            HashSet<Type> types = new HashSet<Type>(); // lets store all Types for this particualr factory type
            Console.WriteLine("Write type of Converter you need Unity,Unreal,Blender");
            string converter = Console.ReadLine();
           
            converter= converter.ToLowerInvariant();
            var firstLetter = converter[0].ToString().ToUpperInvariant();
            converter = converter.Substring(1);
            converter = converter.Insert(0, firstLetter);
            IConverterFactory converterFactory= null;
            try
            {
                var allclasses = from cl in Assembly.GetExecutingAssembly().GetTypes()
                                 where cl.IsClass && cl.Namespace.Contains("AbstractFactoryPattern")
                                 select cl;
                var otherClassTypes = from cl in allclasses
                                      where cl.FullName.ToUpperInvariant().Contains(converter.ToUpperInvariant())
                                      select cl;

                var factorytype = from cl in allclasses
                                   where cl.FullName.Equals($"AbstractFactoryPattern.Factories.{converter}ConverterFactory")
                                   select cl;
                types = new HashSet<Type>( otherClassTypes);
                converterFactory =  (IConverterFactory)Activator.CreateInstance(factorytype.First());//Unity Container . get
            }
            catch (Exception e)
            {
                converterFactory = null;
            }

            if (converterFactory == null) {
                Console.WriteLine($"{converter} Factory not defined");
            }
            else
            {
                Console.WriteLine($"Constructing {converter}Factory");
                var axisconverter = converterFactory.CreateAxisConverter();
                var nodeConverter = converterFactory.CreateNodesConverter();
                Console.WriteLine($"AxisConverter check: {CheckPassFail(types.Contains(axisconverter.GetType()))}");
                Console.WriteLine($"NodeConverter check: {CheckPassFail(types.Contains(nodeConverter.GetType()))}");
            }

            Console.Read();

        }
    }
}
