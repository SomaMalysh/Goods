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

        public static string GetProviderPhoneByID(string id)
        {
            foreach (ProviderID g in AllProviders)
                if (g.id == id)
                    return g.phone;
            return "";
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

        public static List<string> GetUnicCategories()
        {
            List<string> l = new List<string>();
            
            foreach (ClassGoods g in AllGoodsDB)
                if (l.IndexOf(g._category) == -1)
                    l.Add(g._category);
            l.Sort();
            return l;
        }

        public static List<string> GetUnicGoods(string cat = "")
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

        public static void FillAddEditCategories(AddEditWindow f, string selected = "")
        {
            f.Category.Items.Clear();
            foreach (ClassGoods g in AllGoodsDB)
                if (f.Category.Items.IndexOf(g._category) == -1)
                    f.Category.Items.Add(g._category);
            if (selected != "")
                f.Category.SelectedIndex = f.Category.Items.IndexOf(selected);
        }

        public static void FillAddEditValidDate(AddEditWindow f, string selected = "")
        {
            f.Valid.Items.Clear();
            foreach (ClassGoods g in AllGoodsDB)
                if (f.Valid.Items.IndexOf(g._valid_date) == -1)
                    f.Valid.Items.Add(g._valid_date);
            if (selected != "")
                f.Valid.SelectedIndex = f.Valid.Items.IndexOf(selected);
        }

        public static void FillAddEditProvider(AddEditWindow f, string selected = "")
        {
            f.Provider.Items.Clear();
            foreach (ProviderID g in AllProviders)
                if (f.Provider.Items.IndexOf(g.name) == -1)
                    f.Provider.Items.Add(g.name);
            if (selected != "")
                f.Provider.SelectedIndex = f.Provider.Items.IndexOf(selected);
        }

        public static void FillAddEditStorage(AddEditWindow f, string selected = "")
        {
            f.Storage.Items.Clear();
            foreach (ClassGoods g in AllGoodsDB)
                if (f.Storage.Items.IndexOf(g._storage) == -1)
                    f.Storage.Items.Add(g._storage);
            if (selected != "")
                f.Storage.SelectedIndex = f.Storage.Items.IndexOf(selected);
        }

        public static string AddNewProviderToDB(string new_p_name, string new_p_num)
        {
            ProviderID new_p = new ProviderID();
            int amount = AllProviders.Count;
            new_p.id = (amount + 1).ToString();
            new_p.name = new_p_name;
            new_p.phone = new_p_num;
            AllProviders.Add(new_p);
            return new_p.id;
        }

        public static string AddNewGoodsIDToDB(string new_g_name, string new_g_category, string new_g_valid_date, string new_g_short_description, string new_g_note)
        {
            GoodsID new_g = new GoodsID();
            int amount = AllGoodsID.Count;
            new_g.id = (amount + 1).ToString();
            new_g.name = new_g_name;
            new_g.category = new_g_category;
            new_g.valid_date = new_g_valid_date;
            new_g.short_description = new_g_short_description;
            new_g.note = new_g_note;
            AllGoodsID.Add(new_g);
            return new_g.id;
        }

        public static string AddNewGoodsToDB(ClassGoods n_goods)
        {
            ClassGoods goods_to_add = new ClassGoods();
            string p_id = "";
            string g_id = "";
            bool flag_p = false;
            bool flag_g = false;

            foreach (ProviderID p in AllProviders)
                if (p.name == n_goods._provider && p.phone == n_goods._provider_phone)
                {
                    flag_p = true;
                    p_id = p.id;
                    break;
                }
            if (flag_p == false)
                p_id = AddNewProviderToDB(n_goods._provider, n_goods._provider_phone);

            foreach (GoodsID g in AllGoodsID)
                if (g.name == n_goods._name && g.category == n_goods._category && g.valid_date == n_goods._valid_date && g.short_description == n_goods._short_description && g.note == n_goods._note)
                {
                    flag_g = true;
                    g_id = g.id;
                    break;
                }
            if (flag_g == false)
                g_id = AddNewGoodsIDToDB(n_goods._name, n_goods._category, n_goods._valid_date, n_goods._short_description, n_goods._note);

            int amount = AllGoodsDB.Count;

            goods_to_add._id = (amount+1).ToString();
            goods_to_add.goodsID = g_id;
            goods_to_add._creation_date = n_goods._category;
            goods_to_add._count = n_goods._count;
            goods_to_add._price = n_goods._price;
            goods_to_add.providerID = p_id;
            goods_to_add._date_in = n_goods._date_in;
            goods_to_add._storage = n_goods._storage;

            AllGoodsDB.Add(goods_to_add);

            return goods_to_add._id;
        }

        public static void EditGoods(ClassGoods n_goods)
        {
            
        }
    }
}
