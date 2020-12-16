using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactoryPattern.Interfaces
{
    public interface IConverterFactory
    {
        IAxisConverter CreateAxisConverter();
        void CreateStateConverter();
        INodeConverter CreateNodesConverter();

    }
}
