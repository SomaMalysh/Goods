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

            tabCtrl.SelectedIndex = 2;

            vcbCat.Items.Add("Category1");
            vcbCat.Items.Add("Category2");
            vcbCat.Items.Add("Category3");
            vcbCat.Items.Add("Category4");



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
            vcbItem.Items.Add(vcbCat.SelectedValue + " - Goods1");
            vcbItem.Items.Add(vcbCat.SelectedValue + " - Goods2");
            vcbItem.Items.Add(vcbCat.SelectedValue + " - Goods3");
            vcbItem.Items.Add(vcbCat.SelectedValue + " - Goods4");
            vcbItem.SelectedIndex = 0;
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
