using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goods
{
    class Main
    {
        public static List<GoodsID> AllGoodsID;
        public static List<ProviderID> AllProviders;
        public static List<ClassGoods> AllGoodsDB;

        public static string[] line2Ar(string line)
        {
            string[] ar = line.Split(';');
            for (int i = 0; i < ar.Length; i++)
                ar[i] = ar[i].Trim();
            return ar;
        }

        public static GoodsID GetGoodIDbyID(string id)
        {
            foreach (GoodsID g in AllGoodsID)
                if (g.id == id)
                    return g;
            return new GoodsID();
        }

        public static ProviderID GetProviderIDbyID(string id)
        {
            foreach (ProviderID p in AllProviders)
                if (p.id == id)
                    return p;
            return new ProviderID();
        }

        public static void explainGoodsDB()
        {
            GoodsID g;
            ProviderID p;
            for (int i = 0; i < AllGoodsDB.Count(); i++)
            {
                g = GetGoodIDbyID(AllGoodsDB[i].goodsID);
                AllGoodsDB[i]._name = g.name;
                AllGoodsDB[i]._category = g.category;
                AllGoodsDB[i]._valid_date = g.valid_date;
                AllGoodsDB[i]._short_description = g.short_description;
                AllGoodsDB[i]._note = g.note;
                p = GetProviderIDbyID(AllGoodsDB[i].providerID);
                AllGoodsDB[i]._provider = p.name;
                AllGoodsDB[i]._provider_phone = p.phone;
            }
        }

        public static List<string> GetCategoryNames()
        {
            List<string> l = new List<string>();
            
            foreach (ClassGoods g in AllGoodsDB)
                if (l.IndexOf(g._category) == -1)
                    l.Add(g._category);
            l.Sort();
            return l;
        }

        public static List<string> GetGoodNames(string cat = "")
        {
            List<string> l = new List<string>();
            foreach (ClassGoods g in AllGoodsDB)
                if (g._category == cat | cat == "")
                    if (l.IndexOf(g._name) == -1)
                        l.Add(g._name);
                
            l.Sort();
            return l;
        }

        public static List<ClassGoods> GetAllGoods(string cat = "", string goo = "")
        {
            List<ClassGoods> l = new List<ClassGoods>();
            foreach (ClassGoods g in AllGoodsDB)
                if ((cat == "" | cat == g._category) & (goo == "" | goo == g._name))
                    l.Add(g);
            return l;
        }
    }
}
