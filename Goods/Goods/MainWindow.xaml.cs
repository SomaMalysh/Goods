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

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Main.AllGoodsID = new List<GoodsID>();
            Main.AllProviders = new List<ProviderID>();
            Main.AllGoodsDB = new List<ClassGoods>();

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
            w.ShowDialog();
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
