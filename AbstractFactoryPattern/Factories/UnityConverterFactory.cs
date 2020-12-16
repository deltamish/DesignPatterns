using System;
using System.Collections.Generic;
using System.Text;
using AbstractFactoryPattern.Interfaces;
using AbstractFactoryPattern.Axisconverters;
using AbstractFactoryPattern.NodeConverters;

namespace AbstractFactoryPattern.Factories
{
    public class UnityConverterFactory : IConverterFactory
    {
        public IAxisConverter CreateAxisConverter()
        {
            return new UnityAxisConverter();
        }

        public INodeConverter CreateNodesConverter()
        {
            return new UnityNodeConverter();
        }

        public void CreateStateConverter()
        {
            throw new NotImplementedException();
        }
    }
}
