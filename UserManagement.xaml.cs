using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
    public partial class UserManagement
        : Window
    {
        PatientsTableAdapter Patients = new PatientsTableAdapter();
    
        public UserManagement()
        {
            InitializeComponent();
            Usere.ItemsSource = Patients.GetData();

        }

        private void Voiti_Click(object sender, RoutedEventArgs e)
        {
            MainAdmin adm = new MainAdmin();
            adm.Show();
            this.Close();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Patients.InsertQuery(Convert.ToString(FIO.Text), (Phone.Text), (Data.Text));
            Usere.ItemsSource = Patients.GetData();

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            object ID_Patient = (Usere.SelectedItem as DataRowView).Row[0];
            Patients.DeleteQuery(Convert.ToInt32(ID_Patient));
            Usere.ItemsSource = Patients.GetData();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            object ID_Patient = (Usere.SelectedItem as DataRowView).Row[0];
            Patients.UpdateQuery(Convert.ToString(FIO.Text), (Phone.Text), (Data.Text), Convert.ToInt32(ID_Patient));
            Usere.ItemsSource = Patients.GetData();
        }
    }
}
