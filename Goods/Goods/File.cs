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

        public static void RefreshProviderFile()
        {
            using (StreamWriter clear = new StreamWriter(fileProviders, false))
                clear.WriteLine("");
            using (StreamWriter writer = new StreamWriter(fileProviders, false))
            {
                foreach (ProviderID provider in Main.AllProviders)
                {
                    string add_g = provider.ToStringWithId() + Environment.NewLine;
                    writer.Write(add_g);
                }
            }
        }

        public static void RefreshGoodsIDFile()
        {
            using (StreamWriter clear = new StreamWriter(fileGoodsID, false))
                clear.WriteLine("");
            using (StreamWriter writer = new StreamWriter(fileGoodsID, false))
            {
                foreach (GoodsID goods in Main.AllGoodsID)
                {
                    string add_g = goods.ToStringGoodsID() + Environment.NewLine;
                    writer.Write(add_g);
                }
            }
        }

        public static void RefreshGoodsDBFile()
        {
            using (StreamWriter clear = new StreamWriter(fileGoodsDB, false))
                clear.WriteLine("");
            using (StreamWriter writer = new StreamWriter(fileGoodsDB, false))
            {
                foreach (ClassGoods goods in Main.AllGoodsDB)
                {
                    string add_g = goods.ToStringGoodsID() + Environment.NewLine;
                    writer.Write(add_g);
                }
            }
        }

        public static void WriteAllFiles()
        {

        }
    }
}
