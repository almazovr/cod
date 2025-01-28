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
    public partial class analyzes
        : Window
    {
        AnalysisTableAdapter Analysis = new AnalysisTableAdapter();
        public analyzes()
        {
            InitializeComponent();
            anali.ItemsSource = Analysis.GetData();

        }

        private void Voiti_Click(object sender, RoutedEventArgs e)
        {
            MainLaborant analize = new MainLaborant();
            analize.Show();
            this.Close();
        }
    }
}
