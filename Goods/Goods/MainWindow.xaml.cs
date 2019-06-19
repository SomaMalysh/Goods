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
using Microsoft.VisualBasic;

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

            #if DEBUG
            tabCtrl.SelectedIndex = 2;
            #endif

            File f = new File("Goods.txt");
            foreach (string s in f.GetCategories())
                vcbCat.Items.Add(s);

            try
            {
                vcbCat.SelectedIndex = 0;
                VcbCat_SelectionChanged(vcbCat, null);
            }
            catch
            {

            }
        }

        private void New_Category_Click(object sender, RoutedEventArgs e)
        {
            String s = Microsoft.VisualBasic.Interaction.InputBox("Введіть нову категорію");
            if (s.Trim() == "")
                return;
        }

        private void VcbCat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            vcbItem.Items.Clear();
            File f = new File("Goods.txt");
            foreach (string s in f.GetGoods(vcbCat.SelectedValue.ToString()))
                vcbItem.Items.Add(s);
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
            //var data = new { ID = "0", Name = "Name 1" };
            vgGoods.Items.Add(new { ID = "0", Name = "Name 1" });
            //data = new Goods { ID = "1", Name = "Name 2" };
            vgGoods.Items.Add(new { ID = "1", Name = "Name 2" });
        }
    }
}
