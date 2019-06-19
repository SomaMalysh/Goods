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
        private string file;
            
        public File(string file)
        {
            this.file = @file;
        }

        private string GetLineIndex(string line, FileLineIdx idx)
        {
            string[] ar = line.Split(';');
            try
            {
                return ar[(int)idx];
            }
            catch
            {
                return "";
            }
        }

        public List<string> GetCategories()
        {
            if (!System.IO.File.Exists(file))
                throw new Exception("File not exists!");
            string line, cat;
            List<string> l = new List<string>();
            using (StreamReader reader = new StreamReader(file))
                while ((line = reader.ReadLine()) != null)
                {
                    cat = GetLineIndex(line, FileLineIdx.idxCategory);
                    if (l.IndexOf(cat.Trim()) == -1 & cat.Trim() != "")
                        l.Add(cat.Trim());
                }
            l.Sort();
            return l;
        }

        public List<string> GetGoods(string cat)
        {
            if (!System.IO.File.Exists(file))
                throw new Exception("File not exists!");
            string line, goods, fcat;
            List<string> l = new List<string>();
            using (StreamReader reader = new StreamReader(file))
                while ((line = reader.ReadLine()) != null)
                {
                    fcat = GetLineIndex(line, FileLineIdx.idxCategory);
                    goods = GetLineIndex(line, FileLineIdx.idxName);
                    if (fcat.Trim() == cat)
                        if (l.IndexOf(goods.Trim()) == -1 & goods.Trim() != "")
                            l.Add(goods.Trim());
                }
            l.Sort();
            return l;
        }
        
    }
}
