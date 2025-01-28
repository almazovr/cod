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
    public partial class MainWindow : Window
    {
        EmployeesTableAdapter adapter = new EmployeesTableAdapter();
        public MainWindow()
        {
            InitializeComponent();
        }


        private void Voiti_Click(object sender, RoutedEventArgs e)
        {
            bool loginSuccessful = false;
            var allLogins = adapter.GetData().Rows;
            for (int i = 0; i < allLogins.Count; i++)
            {

                if (allLogins[i][1] != null && allLogins[i][2] != null &&
                     allLogins[i][1].ToString() == Login.Text &&
                    allLogins[i][2].ToString() == Password.Password)
                {
                    loginSuccessful = true;
                    int ID_Positions = (int)allLogins[i][5];
                    switch (ID_Positions)
                    {
                        case 1:
                            MainAdmin role = new MainAdmin();
                            role.Show();
                            this.Close();
                            break;

                        case 2:
                            MainLaborant second = new MainLaborant();
                            second.Show();
                            this.Close();
                            break;

                        case 3:
                            MainSupervisor tree = new MainSupervisor();
                            tree.Show();
                            this.Close();
                            break;
                    }
                    break;

                }

            }

            if (!loginSuccessful)
            {
                MessageBox.Show("Неверный логин или пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                Login.Text = "";
                Password.Password = "";
            }
        }
    }
}

