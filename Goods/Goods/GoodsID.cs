using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goods
{
    class GoodsID
    {
        public string id;
        public string name;
        public string category;
        public string valid_date;
        public string short_description;
        public string note;

        public GoodsID()
        {

        }

        public GoodsID(string fileLine)
        {
            string[] ar = Main.line2Ar(fileLine);
            id = ar[0];
            name = ar[1];
            category = ar[2];
            valid_date = ar[3];
            short_description = ar[4];
            note = ar.Length == 6 ? ar[5] : "-";
        }

        public string ToStringGoodsID()
        {
            return id + "; " + name + "; " + category + "; " + valid_date + "; " + short_description + "; " + note + " ";
        }
    }
}
