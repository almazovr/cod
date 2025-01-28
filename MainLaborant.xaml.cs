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
    public partial class MainLaborant
        : Window
    {
        public MainLaborant()
        {
            InitializeComponent();
        }

        private void Voiti_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void Orders_Click(object sender, RoutedEventArgs e)
        {
            analyzes analiz = new analyzes();
            analiz.Show();
            this.Close();
        }

        private void Users_Click(object sender, RoutedEventArgs e)
        {
            PatientAnaliz analizPaz = new PatientAnaliz();
            analizPaz.Show();
            this.Close();
        }
    }
    
}
