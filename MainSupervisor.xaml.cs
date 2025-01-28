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

namespace yes
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainSupervisor
        : Window
    {
        public MainSupervisor()
        {
            InitializeComponent();
        }

        private void Voiti_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();

        }

        private void Parol_Click(object sender, RoutedEventArgs e)
        {
            SupervisorManagement superv = new SupervisorManagement();
            superv.Show();
            this.Close();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            Reports repor = new Reports();
            repor.Show();
            this.Close();
        }

        private void Login_Копировать_Click(object sender, RoutedEventArgs e)
        {
            EmployeesManagement user = new EmployeesManagement();
            user.Show();
            this.Close();
        }
    }
}
