using System;
using System.Collections.Generic;
using System.Text;
using AbstractFactoryPattern.Interfaces;
using AbstractFactoryPattern.Axisconverters;
using AbstractFactoryPattern.NodeConverters;

namespace AbstractFactoryPattern.Factories
{
    public class UnrealConverterFactory : IConverterFactory
    {
        public IAxisConverter CreateAxisConverter()
        {
            return new UnrealAxisConverter();
        }

        public INodeConverter CreateNodesConverter()
        {
            return new UnrealNodeConverter();
        }

        public void CreateStateConverter()
        {
            throw new NotImplementedException();
        }
    }
}
