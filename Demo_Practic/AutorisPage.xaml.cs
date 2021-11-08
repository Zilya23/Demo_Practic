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

namespace Demo_Practic
{
    /// <summary>
    /// Логика взаимодействия для AutorisPage.xaml
    /// </summary>
    public partial class AutorisPage : Page
    {
        public AutorisPage()
        {
            InitializeComponent();
        }

        private void BTN_Login_Click(object sender, RoutedEventArgs e)
        {
            string pass = "oxp";
            if (txt_password.Password == pass)
            {
                NavigationService.Navigate(new GlavPage());
            }
            else 
            {
                MessageBox.Show("Неверный пароль");
            }
        }
    }
}
