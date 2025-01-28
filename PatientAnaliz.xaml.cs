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
    public partial class PatientAnaliz
        : Window
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
            Analysis.InsertQuery(Convert.ToString(data.Text), Convert.ToInt32(Phsampone.Text), Convert.ToInt32(types.Text));
            spisok.ItemsSource = Analysis.GetData();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            object ID_Analyses = (spisok.SelectedItem as DataRowView).Row[0];
            Analysis.DeleteQuery(Convert.ToInt32(ID_Analyses));
            spisok.ItemsSource = Analysis.GetData();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            object ID_Analyses = (spisok.SelectedItem as DataRowView).Row[0];
            Analysis.UpdateQuery(Convert.ToString(data.Text), Convert.ToInt32(Phsampone.Text), Convert.ToInt32(types.Text), Convert.ToInt32(ID_Analyses));
            spisok.ItemsSource = Analysis.GetData();
        }

        private void spisok_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
