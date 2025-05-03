using PROGADUN.Windows;
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

namespace PROGADUN.Pages
{
    /// <summary>
    /// Логика взаимодействия для Napad1.xaml
    /// </summary>
    public partial class Napad1 : Page
    {
        public Napad1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AnketaWindow anketaWindow = new AnketaWindow();
            anketaWindow.Show();
        }
    }
}
