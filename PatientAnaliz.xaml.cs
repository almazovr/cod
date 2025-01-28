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
    public partial class PatientAnaliz : Window
    {
        AnalysisTableAdapter Analysis = new AnalysisTableAdapter();

        public PatientAnaliz()
        {
            InitializeComponent();
            spisok.ItemsSource = Analysis.GetData();
        }

        private void Voiti_Click(object sender, RoutedEventArgs e)
        {
            MainLaborant anali = new MainLaborant();
            anali.Show();
            this.Close();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(data.Text) ||
                string.IsNullOrWhiteSpace(Phsampone.Text) ||
                string.IsNullOrWhiteSpace(types.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return; 
            }

            try
            {
                Analysis.InsertQuery(Convert.ToString(data.Text), Convert.ToInt32(Phsampone.Text), Convert.ToInt32(types.Text));
                spisok.ItemsSource = Analysis.GetData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при добавлении анализа: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (spisok.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите анализ для удаления.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return; 
            }

            try
            {
                object ID_Analyses = (spisok.SelectedItem as DataRowView).Row[0];
                Analysis.DeleteQuery(Convert.ToInt32(ID_Analyses));
                spisok.ItemsSource = Analysis.GetData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при удалении анализа: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            
            if (spisok.SelectedItem == null ||
                string.IsNullOrWhiteSpace(data.Text) ||
                string.IsNullOrWhiteSpace(Phsampone.Text) ||
                string.IsNullOrWhiteSpace(types.Text))
            {
                MessageBox.Show("Пожалуйста, выберите анализ и заполните все поля.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return; 
            }

            try
            {
                object ID_Analyses = (spisok.SelectedItem as DataRowView).Row[0];
                Analysis.UpdateQuery(Convert.ToString(data.Text), Convert.ToInt32(Phsampone.Text), Convert.ToInt32(types.Text), Convert.ToInt32(ID_Analyses));
                spisok.ItemsSource = Analysis.GetData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при изменении анализа: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


    }
}
