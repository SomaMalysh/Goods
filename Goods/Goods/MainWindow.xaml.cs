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

            foreach (string s in Main.GetCategoryNames())
                vcbCat.Items.Add(s);
            vcbCat.Items.Insert(0, "Всі");
            try
            {
                vcbCat.SelectedIndex = 0;
                //VcbCat_SelectionChanged(vcbCat, null);
            }
            catch
            {

            }
        }

        //private void New_Category_Click(object sender, RoutedEventArgs e)
        //{
        //    String s = Microsoft.VisualBasic.Interaction.InputBox("Введіть нову категорію");
        //    if (s.Trim() == "")
        //        return;
        //}

        private void VcbCat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            vcbItem.Items.Clear();
            foreach (string s in Main.GetGoodNames(vcbCat.SelectedValue.ToString()))
                vcbItem.Items.Add(s);
            vcbItem.Items.Insert(0, "Всі");
            try
            {
                vcbItem.SelectedIndex = 0;
                //VcbItem_SelectionChanged(vcbItem, null);
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
                //VcbItem_SelectionChanged(vcbItem, null);
            }
            catch
            {

            }
        }

        private void New_Click(object sender, RoutedEventArgs e)
        {
            AddEditWindow w = new AddEditWindow();
            w.ShowDialog();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            ClassGoods g = (ClassGoods)vgGoods.SelectedItem;
            AddEditWindow w = new AddEditWindow();
            w.GName.Text = g._name;
            w.Title = "Редагувати товар";
            w.AddEditButton.Content = "Зберегти";
            w.ShowDialog();
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
