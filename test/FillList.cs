using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    public class FillList
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public FillList(string Name, string Surname){
            this.Name = Name;
            this.Surname = Surname;
        }

        public FillList() { }
    }
}
