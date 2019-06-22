using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goods
{
    class ProviderID
    {
        public string id;
        public string name;
        public string phone;

        public ProviderID()
        {

        }

        public ProviderID(string fileLine)
        {
            string[] ar = Main.line2Ar(fileLine);
            id = ar[0];
            name = ar[1];
            phone = ar[2];
        }
    }
}
