using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CulinaryGuide
{
    public class SubcategoryClass
    {
        public int id;
        public string name;
        public int parent_id;
        public SubcategoryClass()
        {

        }
        public SubcategoryClass(int _id, string _name,int _parent_id)
        {
            id = _id;
            name = _name;
            parent_id = _parent_id;
        }
    }
}
