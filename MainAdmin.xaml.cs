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
using yes.YchebkaDataSetTableAdapters;

namespace yes
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainAdmin
        : Window
    {
        public MainAdmin()
        {
            InitializeComponent();
        }

        private void Voiti_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void Users_Click(object sender, RoutedEventArgs e)
        {
            UserManagement admin = new UserManagement();
            admin.Show();
            this.Close();
        }

        private void Orders_Click(object sender, RoutedEventArgs e)
        {
            OrderManagement order = new OrderManagement();
            order.Show();
            this.Close();
        }
    }
}
