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
    public partial class SupervisorManagement : Window
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
            if (string.IsNullOrWhiteSpace(Name.Text))
            {
                MessageBox.Show("Пожалуйста, введите название должности.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return; 
            }
            try
            {
                Positions.InsertQuery(Convert.ToString(Name.Text));
                spisok.ItemsSource = Positions.GetData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при добавлении должности: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (spisok.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите должность для удаления.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return; 
            }
            try
            {
                object ID_Positions = (spisok.SelectedItem as DataRowView).Row[0];
                Positions.DeleteQuery(Convert.ToInt32(ID_Positions));
                spisok.ItemsSource = Positions.GetData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при удалении должности: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (spisok.SelectedItem == null || string.IsNullOrWhiteSpace(Name.Text))
            {
                MessageBox.Show("Пожалуйста, выберите должность и введите новое название.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return; 
            }

            try
            {
                object ID_Positions = (spisok.SelectedItem as DataRowView).Row[0];
                Positions.UpdateQuery(Convert.ToString(Name.Text), Convert.ToInt32(ID_Positions));
                spisok.ItemsSource = Positions.GetData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при изменении должности: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
