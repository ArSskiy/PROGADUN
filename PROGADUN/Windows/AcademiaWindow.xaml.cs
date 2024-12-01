using PROGADUN.Pages;
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
using System.Windows.Shapes;

namespace PROGADUN.Windows
{
    /// <summary>
    /// Логика взаимодействия для AcademiaWindow.xaml
    /// </summary>
    public partial class AcademiaWindow : Window
    {
        public AcademiaWindow()
        {
            InitializeComponent();
            Shema.Items.Add("4-3-3 Атакующая");
            Shema.Items.Add("4-3-3 Защитная");
            PoleFrame.Navigate(new _433Zahit());



        }

        private void TextBlock_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            GlavWindow glavWindow = new GlavWindow();
            glavWindow.Show();
            this.Close();
            
        }

        private void TextBlock_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            SostavWindow sostavWindow = new SostavWindow();
            sostavWindow.Show();
            this.Close();
        }
    }
}
