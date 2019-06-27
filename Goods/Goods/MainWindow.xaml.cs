using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Goods
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public struct SelectedGoods
    {
        string cat, goods;
        int gridItem;

        public SelectedGoods(string cat, string goods, int gridItem)
        {
            this.cat = cat;
            this.goods = goods;
            this.gridItem = gridItem;
        }

        public void Restore()
        {
            MainWindow w = Application.Current.MainWindow as MainWindow;
            try
            {
                w.vcbCat.SelectedIndex = w.vcbCat.Items.IndexOf(this.cat);
            }
            catch
            {

            }
            try
            {
                w.vcbItem.SelectedIndex = w.vcbItem.Items.IndexOf(this.goods);
            }
            catch
            {

            }
            try
            {
                w.vgGoods.SelectedIndex = this.gridItem;
            }
            catch
            {

            }
        }
    }

    public struct reportItems
    {
        public int col;
        public string val;

        public reportItems(int col, string val)
        {
            this.col = col;
            this.val = val;
        }
    }

    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            Main.AllGoodsID = new List<GoodsID>();
            Main.AllProviders = new List<ProviderID>();
            Main.AllGoodsDB = new List<ClassGoods>();
            Main.reportFilter = new List<reportItems>();

            File.ReadAllFiles();
            Main.explainGoodsDB();

            FillCategoryCombobox();
        }

        public void FillCategoryCombobox()
        {
            vcbCat.Items.Clear();
            foreach (string s in Main.GetUnicCategories())
                vcbCat.Items.Add(s);
            vcbCat.Items.Insert(0, "Всі");
            try
            {
                vcbCat.SelectedIndex = 0;
            }
            catch
            {

            }
        }

        private void VcbCat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            vcbItem.Items.Clear();
            string sel = vcbCat.SelectedValue == null ? "" : vcbCat.SelectedValue.ToString();
            foreach (string s in Main.GetUnicGoods(sel))
                vcbItem.Items.Add(s);
            vcbItem.Items.Insert(0, "Всі");
            try
            {
                vcbItem.SelectedIndex = 0;
            }
            catch
            {

            }
        }

        private void VcbItem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            vgGoods.Items.Clear();
            foreach (ClassGoods g in Main.GetAllGoods(vcbCat.SelectedIndex == 0 | vcbCat.SelectedValue == null ? "" : vcbCat.SelectedValue.ToString(), vcbItem.SelectedIndex == 0 | vcbItem.SelectedValue == null ? "" : vcbItem.SelectedValue.ToString()))
                vgGoods.Items.Add(g);
            try
            {
                vgGoods.SelectedIndex = 0;
            }
            catch
            {

            }
            Application.Current.MainWindow.UpdateLayout();
            doFilterGrid();
        }

        private void New_Click(object sender, RoutedEventArgs e)
        {
            AddEditWindow w = new AddEditWindow();
            w.Owner = Application.Current.MainWindow;
            w.WindowStartupLocation = WindowStartupLocation.CenterOwner;   
            Main.FillAddEditCategories(w);
            Main.FillAddEditValidDate(w);  
            Main.FillAddEditProvider(w); 
            Main.FillAddEditStorage(w);
            w.Title = "Додати товар";
            w.AddEditButton.Content = "Додати";
            w.ShowDialog();

            ClassGoods g = new ClassGoods();
            g._name = w.GName.Text;
            g._category = w.Category.Text;
            g._valid_date = w.Valid.Text;
            g._creation_date = w.MadeDate.Text;
            g._count = w.Count.Text;
            g._price = w.Price.Text;
            g._provider = w.Provider.Text;
            g._provider_phone = w.ProviderPhone.Text;
            g._date_in = w.InDate.Text;
            g._storage = w.Storage.Text;
            g._short_description = w.Desc.Text;
            g._note = w.Note.Text;

            Main.AddNewGoodsToDB(g);
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            ClassGoods g = (ClassGoods)vgGoods.SelectedItem;
            AddEditWindow w = new AddEditWindow();
            w.editingID = g._id;
            w.Owner = Application.Current.MainWindow;
            w.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            w.GName.Text = g._name;
            Main.FillAddEditCategories(w, g._category);
            Main.FillAddEditValidDate(w, g._valid_date);
            w.MadeDate.Text = g._creation_date;
            w.Count.Text = g._count;
            w.Price.Text = g._price;
            Main.FillAddEditProvider(w, g._provider);
            w.ProviderPhone.Text = g._provider_phone;
            w.InDate.Text = g._date_in;
            Main.FillAddEditStorage(w, g._storage);
            w.Desc.Text = g._short_description;
            w.Note.Text = g._note;
            w.Title = "Редагувати товар";
            w.AddEditButton.Content = "Зберегти";
            SelectedGoods s = new SelectedGoods(vcbCat.SelectedValue.ToString(), vcbItem.SelectedValue.ToString(), vgGoods.SelectedIndex);
            w.ShowDialog();

            g._name = w.GName.Text;
            g._category = w.Category.Text;
            g._valid_date = w.Valid.Text;
            g._creation_date = w.MadeDate.Text;
            g._count = w.Count.Text;
            g._price = w.Price.Text;
            g._provider = w.Provider.Text;
            g._provider_phone = w.ProviderPhone.Text;
            g._date_in = w.InDate.Text;
            g._storage = w.Storage.Text;
            g._short_description = w.Desc.Text;
            g._note = w.Note.Text;

            Main.EditGoods(g);

            s.Restore();
            vgGoods.Focus();
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            ClassGoods g = (ClassGoods)vgGoods.SelectedItem;
            //g._id; або g, тобто items.indexOf()
            //Main.AllGoodsDB
        }

        private void populateReportItems()
        {
            reportText.Text = "";
            TextBlock t, t0;
            Hyperlink h;
            for (int i = 0; i < Main.reportFilter.Count; i++)
            {
                t0 = new TextBlock();
                t0.Text = "(";
                t = new TextBlock();
                t.Text = ") "+ vgGoods.Columns[Main.reportFilter[i].col].Header + " = " + Main.reportFilter[i].val + (i == Main.reportFilter.Count-1 ? "" : ", ");
                h = new Hyperlink();
                h.Inlines.Add("Видалити");
                h.Tag = i;
                h.Click += removeReportItem_Click;
                reportText.Inlines.Add(t0);
                reportText.Inlines.Add(h);
                reportText.Inlines.Add(t);
            }
        }

        private void removeReportItem_Click(object sender, RoutedEventArgs e)
        {
            Hyperlink h = sender as Hyperlink;
            Main.reportFilter.RemoveAt((int)h.Tag);
            populateReportItems();
            VcbItem_SelectionChanged(vcbItem, null);
            //doFilterGrid();
        }

        private void smi_Click(object sender, RoutedEventArgs e)
        {
            MenuItem m = sender as MenuItem;
            Main.reportFilter.Add(new reportItems((int)m.Tag, m.Header.ToString()));
            populateReportItems();
            VcbItem_SelectionChanged(vcbItem, null);
            //doFilterGrid();
        }

        private void addUnicColToMenuItem(int col, MenuItem mi)
        {
            List<string> l = new List<string>();
            TextBlock x;
            for (int i = 0; i < vgGoods.Items.Count; i++) {
                x = vgGoods.Columns[col].GetCellContent(vgGoods.Items[i]) as TextBlock;
                if (l.IndexOf(x.Text) == -1)
                {
                    l.Add(x.Text);
                }
            }
            l.Sort();
            MenuItem smi;
            foreach (string s2 in l)
            {
                smi = new MenuItem();
                smi.Header = s2;
                smi.Tag = col;
                smi.Click += smi_Click;
                mi.Items.Add(smi);
            }
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            ContextMenu cm = new ContextMenu();
            MenuItem mi;
            bool b;
            for (int i = 3; i < vgGoods.Columns.Count; i++)
            {
                b = false;
                for (int i2 = 0; i2 < Main.reportFilter.Count; i2++)
                    if (Main.reportFilter[i2].col == i)
                        b = true;
                if (!b)
                    {
                        mi = new MenuItem();
                        mi.Header = vgGoods.Columns[i].Header;
                        addUnicColToMenuItem(i, mi);
                        cm.Items.Add(mi);
                    }
            }

            cm.PlacementTarget = addRuleText;
            cm.IsOpen = true;
        }

        private void doFilterGrid()
        {

            if (Main.reportFilter.Count == 0)
                return;
            int i = vgGoods.Items.Count;
            int b;
            TextBlock x;
            while (i > 0)
            {
                b = 0;
                for (int i2 = 0; i2 < Main.reportFilter.Count; i2++)
                {
                    x = vgGoods.Columns[Main.reportFilter[i2].col].GetCellContent(vgGoods.Items[i-1]) as TextBlock;
                    if (x.Text == Main.reportFilter[i2].val)
                        b++;
                }
                if (b != Main.reportFilter.Count)
                {
                    vgGoods.Items.RemoveAt(i-1);
                } 
                i--; 
            }
        }
    }
}
