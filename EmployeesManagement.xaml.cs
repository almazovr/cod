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
    public partial class EmployeesManagement : Window
    {
        EmployeesTableAdapter Employees = new EmployeesTableAdapter();

        public EmployeesManagement()
        {
            InitializeComponent();
            spisok.ItemsSource = Employees.GetData();
        }

        private void Voiti_Click(object sender, RoutedEventArgs e)
        {
            MainSupervisor main = new MainSupervisor();
            main.Show();
            this.Close();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(login.Text) ||
                string.IsNullOrWhiteSpace(cod.Text) ||
                string.IsNullOrWhiteSpace(fio.Text) ||
                string.IsNullOrWhiteSpace(email.Text) ||
                string.IsNullOrWhiteSpace(id.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return; 
            }
            try
            {
                Employees.InsertQuery(Convert.ToString(login.Text), (cod.Text), (fio.Text), (email.Text), Convert.ToInt32(id.Text));
                spisok.ItemsSource = Employees.GetData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при добавлении сотрудника: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (spisok.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите сотрудника для удаления.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return; 
            }
            try
            {
                object ID_Employee = (spisok.SelectedItem as DataRowView).Row[0];
                Employees.DeleteQuery(Convert.ToInt32(ID_Employee));
                spisok.ItemsSource = Employees.GetData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при удалении сотрудника: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            
            if (spisok.SelectedItem == null ||
                 string.IsNullOrWhiteSpace(login.Text) ||
                 string.IsNullOrWhiteSpace(cod.Text) ||
                 string.IsNullOrWhiteSpace(fio.Text) ||
                 string.IsNullOrWhiteSpace(email.Text) ||
                 string.IsNullOrWhiteSpace(id.Text))
            {
                MessageBox.Show("Пожалуйста, выберите сотрудника и заполните все поля.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;  
            }
            try
            {
                object ID_Employee = (spisok.SelectedItem as DataRowView).Row[0];
                Employees.UpdateQuery(Convert.ToString(login.Text), (cod.Text), (fio.Text), (email.Text), Convert.ToInt32(id.Text), Convert.ToInt32(ID_Employee));
                spisok.ItemsSource = Employees.GetData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при изменении сотрудника: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
