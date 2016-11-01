using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CulinaryGuide
{
    public class SimpleTableClass
    {
        public int id;
        public string name;

        public SimpleTableClass()
        {

        }
        public SimpleTableClass(int _id,string _name)
        {
            id = _id;
            name = _name;
        }
    }
}
