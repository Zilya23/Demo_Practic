using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для GlavPage.xaml 
    /// </summary>
    public partial class GlavPage : Page
    {
        public static DateTime workStart = new DateTime(2021, 8, 11, 8, 0, 0);
        public static ObservableCollection<Worker> workers { get; set; }

        public static IEnumerable<Worker> vk { get; set; }
        public GlavPage()
        {
            InitializeComponent();
            workers = new ObservableCollection<Worker>(Class1.connection.Worker.ToList());
            vk = workers.Where(a => a.Metka == false).ToList();
            this.DataContext = this;

        }

        private void work_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var n = (sender as ListView).SelectedItem as Worker;
            DateTime enterTime = DateTime.Now;
            TimeSpan Woti = enterTime - workStart;
            TimeSpan first = TimeSpan.FromMinutes(10);
            TimeSpan second = TimeSpan.FromMinutes(30);
            if (Woti >= first && Woti < second)
            {
                n.Shtraf += 500;
                n.Metka = true;
                Class1.connection.SaveChanges();
                MessageBox.Show("Штраф 500р записан");
            }
            else if (Woti == second)
            {
                n.Shtraf += 1000;
                n.Metka = true;
                Class1.connection.SaveChanges();
                MessageBox.Show("Штраф 1000р записан");
            }
            else if (Woti > second)
            {
                n.Shtraf += 2000;
                n.Metka = true;
                Class1.connection.SaveChanges();
                MessageBox.Show("Штраф 2000р записан");
            }
            NavigationService.Navigate(new GlavPage());
        }

    }
}