using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Goods
{
    enum FileLineIdx {
        idxId = 0,
        idxName,
        idxCategory,
        idxCreationDate,
        idxValidDate,
        idxCount,
        idxPrice,
        idxProvider,
        idxProviderPhone,
        idxDateIn,
        idxStorage,
        idxShortDescription,
        idxNote
    };

    class File
    {
        //private string file;
        private static string fileGoodsID = "Goods_id.txt";
        private static string fileGoodsDB = "Goods_db.txt";
        private static string fileProviders = "Providers_id.txt";

        public static void ReadAllFiles()
        {
            if (!System.IO.File.Exists(fileGoodsID) || !System.IO.File.Exists(fileGoodsDB) || !System.IO.File.Exists(fileProviders))
                throw new Exception("One of files does not exists!");
            Main.AllGoodsID.Clear();
            Main.AllProviders.Clear();
            Main.AllGoodsDB.Clear();
            string line;
            using (StreamReader reader = new StreamReader(fileGoodsID))
                while ((line = reader.ReadLine()) != null)
                    Main.AllGoodsID.Add(new GoodsID(line));
            using (StreamReader reader = new StreamReader(fileProviders))
                while ((line = reader.ReadLine()) != null)
                    Main.AllProviders.Add(new ProviderID(line));
            using (StreamReader reader = new StreamReader(fileGoodsDB))
                while ((line = reader.ReadLine()) != null)
                    Main.AllGoodsDB.Add(new ClassGoods(line));
        }

        public static void WriteAllFiles()
        {

        }

        //public string GetLineIndex(string line, FileLineIdx idx)
        //{
        //    string[] ar = line.Split(';');
        //    try
        //    {
        //        return ar[(int)idx].Trim();
        //    }
        //    catch
        //    {
        //        return "";
        //    }
        //}
        
        //public List<ClassGoods> GetAllGoods(string cat = "", string goo = "")
        //{
        //    if (!System.IO.File.Exists(file))
        //        throw new Exception("File not exists!");
        //    List<ClassGoods> g_list = new List<ClassGoods>();
        //    string line;
        //    using (StreamReader reader = new StreamReader(file))
        //    {
        //        while((line = reader.ReadLine()) != null)
        //            if ((cat == "" | cat == GetLineIndex(line, FileLineIdx.idxCategory)) & (goo == "" | goo == GetLineIndex(line, FileLineIdx.idxName)))
        //            {
        //                ClassGoods goods = new ClassGoods();
        //                goods._id = GetLineIndex(line, FileLineIdx.idxId);
        //                goods._name = GetLineIndex(line, FileLineIdx.idxName);
        //                goods._category = GetLineIndex(line, FileLineIdx.idxCategory);
        //                goods._creation_date = GetLineIndex(line, FileLineIdx.idxCreationDate);
        //                goods._valid_date = GetLineIndex(line, FileLineIdx.idxValidDate);
        //                goods._count = GetLineIndex(line, FileLineIdx.idxCount);
        //                goods._price = GetLineIndex(line, FileLineIdx.idxPrice);
        //                goods._provider = GetLineIndex(line, FileLineIdx.idxProvider);
        //                goods._provider_phone = GetLineIndex(line, FileLineIdx.idxProviderPhone);
        //                goods._date_in = GetLineIndex(line, FileLineIdx.idxDateIn);
        //                goods._storage = GetLineIndex(line, FileLineIdx.idxStorage);
        //                goods._short_description = GetLineIndex(line, FileLineIdx.idxShortDescription);
        //                goods._note = GetLineIndex(line, FileLineIdx.idxNote);
        //                g_list.Add(goods);
        //            }
        //    }

        //    return g_list;
        //}


        //public void AddNewGoodsToStorage(ClassGoods goods)
        //{
        //    if (!System.IO.File.Exists(file))
        //        throw new Exception("File not exists!");
        //    string line;
        //    int max_index = 0;
        //    using (StreamReader reader = new StreamReader(file))
        //    {
        //        while ((line = reader.ReadLine()) != null)
        //        {
        //            int g_id;
        //            g_id = Convert.ToInt32(GetLineIndex(line, FileLineIdx.idxId));
        //            if (g_id > max_index)
        //                max_index = g_id;
        //        }
        //        string add_g = (max_index+1).ToString() + "; " + goods.ToStringWithoutId() + Environment.NewLine;
        //        System.IO.File.AppendAllText(file, add_g);
        //    }
        //}

        //public void RemoveGoods(int id_for_remove)
        //{
        //    List<ClassGoods> g_list = new List<ClassGoods>();
        //    g_list = GetAllGoods();
        //    int index = -1;
        //    foreach (ClassGoods g in g_list)
        //    {
        //        if (Convert.ToInt32(g._id) == id_for_remove)
        //        {
        //            index = g_list.IndexOf(g);
        //            break;
        //        }
        //    }
        //    g_list.RemoveAt(index);

        //    if (!System.IO.File.Exists(file))
        //        throw new Exception("File not exists!");
        //    using (StreamWriter clear = new StreamWriter(file, false))
        //        clear.WriteLine("");
        //    using (StreamWriter writer = new StreamWriter(file, false))
        //    {
        //        foreach (ClassGoods g in g_list)
        //        {
        //            string add_g = g.ToStringWithId() + Environment.NewLine;
        //            writer.Write(add_g);
        //        }
        //    }
        //}
    }
}
