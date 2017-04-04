using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Libreria;

namespace Libreria
{
    public class Class1:MarshalByRefObject
    {
        public Class1() { }

        public int Suma(int a , int b)
        {
            return a + b;
        }

    }
}
