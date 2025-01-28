using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
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
    public partial class SupervisorManagement
        : Window
    {
        PositionsTableAdapter Positions = new PositionsTableAdapter();

        public SupervisorManagement()
        {
            InitializeComponent();
            spisok.ItemsSource = Positions.GetData();

        }

        private void Voiti_Click(object sender, RoutedEventArgs e)
        {
            MainSupervisor main = new MainSupervisor();
            main.Show();
            this.Close();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Positions.InsertQuery(Convert.ToString(Name.Text));
            spisok.ItemsSource = Positions.GetData();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            object ID_Positions = (spisok.SelectedItem as DataRowView).Row[0];
            Positions.DeleteQuery(Convert.ToInt32(ID_Positions));
            spisok.ItemsSource = Positions.GetData();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            object ID_Positions = (spisok.SelectedItem as DataRowView).Row[0];
            Positions.UpdateQuery(Convert.ToString(Name.Text), Convert.ToInt32(ID_Positions));
            spisok.ItemsSource = Positions.GetData();
        }
    }
}
