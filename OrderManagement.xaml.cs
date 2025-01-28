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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using yes.YchebkaDataSetTableAdapters;

namespace yes
{
    public partial class OrderManagement : Window
    {
        OrdersTableAdapter Orders = new OrdersTableAdapter();

        public OrderManagement()
        {
            InitializeComponent();
            Ordrs.ItemsSource = Orders.GetData();
        }

        private void Voiti_Click(object sender, RoutedEventArgs e)
        {
            MainAdmin order = new MainAdmin();
            order.Show();
            this.Close();
        }


        private void Add_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(Order1.Text) ||
                string.IsNullOrWhiteSpace(Order2.Text) ||
                string.IsNullOrWhiteSpace(Order.Text) ||
                string.IsNullOrWhiteSpace(Patient.Text) ||
                string.IsNullOrWhiteSpace(Information.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return; 
            }

            try
            {
                Orders.InsertQuery(Convert.ToString(Order1.Text), Convert.ToDecimal(Order2.Text),
                    Convert.ToInt32(Order.Text), Convert.ToInt32(Patient.Text), Convert.ToInt32(Information.Text));
                Ordrs.ItemsSource = Orders.GetData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при добавлении: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (Ordrs.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите заказ для удаления.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return; 
            }

            try
            {
                object ID_Orders = (Ordrs.SelectedItem as DataRowView).Row[0];
                Orders.DeleteQuery(Convert.ToInt32(ID_Orders));
                Ordrs.ItemsSource = Orders.GetData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при удалении: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {

            if (Ordrs.SelectedItem == null ||
                string.IsNullOrWhiteSpace(Order1.Text) ||
                string.IsNullOrWhiteSpace(Order2.Text) ||
                string.IsNullOrWhiteSpace(Order.Text) ||
                string.IsNullOrWhiteSpace(Patient.Text) ||
                string.IsNullOrWhiteSpace(Information.Text))
            {
                MessageBox.Show("Пожалуйста, выберите заказ и заполните все поля.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return; 
            }
            try
            {
                object ID_Orders = (Ordrs.SelectedItem as DataRowView).Row[0];
                Orders.UpdateQuery(Convert.ToString(Order1.Text), Convert.ToDecimal(Order2.Text),
                    Convert.ToInt32(Order.Text), Convert.ToInt32(Patient.Text), Convert.ToInt32(Information.Text), Convert.ToInt32(ID_Orders));
                Ordrs.ItemsSource = Orders.GetData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при изменении: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
