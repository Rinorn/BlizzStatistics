using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    class CharacterClass
    {

        public class Rootobject
        {
            public Class1[] classes { get; set; }
        }

        public class Class1
        {
            public int id { get; set; }
            public int mask { get; set; }
            public string powerType { get; set; }
            public string name { get; set; }
        }

    }
}
