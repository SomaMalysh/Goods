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
using System.Windows.Shapes;

namespace Goods
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class AddEditWindow : Window
    {
        public string editingID = "-1";
        public AddEditWindow()
        {
            InitializeComponent();
        }

        private void Provider_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (ProviderID p in Main.AllProviders)
                if ((sender as ComboBox).SelectedItem.ToString() == p.name)
                {
                    this.ProviderPhone.Text = p.phone;
                    break;
                }
        }

        private void AddEditButton_Click(object sender, RoutedEventArgs e)
        {

            AddEditButton.IsEnabled = false;
            //(Owner as MainWindow).FillCategoryCombobox();
            //File.WriteAllFiles();
            this.DialogResult = true;
            this.Close();
        }
    }
}
