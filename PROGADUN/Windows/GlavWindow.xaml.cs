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
    /// Логика взаимодействия для GlavWindow.xaml
    /// </summary>
    public partial class GlavWindow : Window
    {
        public int numN = 0;
        public GlavWindow()
        {
            InitializeComponent();
            NovostiFrame.Navigate(new TrenerPage());
            Preview.Visibility = Visibility.Collapsed;
        }

        private void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            numN += 1;
             if (numN == 1)
            {
                NovostiFrame.Navigate(new GolKeeper());
                Next.Visibility = Visibility.Visible;
                Preview.Visibility = Visibility.Visible;
            }
            else if (numN==2)
            {
                NovostiFrame.Navigate(new President());
                Next.Visibility = Visibility.Collapsed;
                Preview.Visibility = Visibility.Visible;
            }
        }

        private void Preview_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            numN -= 1;
            if (numN == 0)
            {
                NovostiFrame.Navigate(new TrenerPage());
                Next.Visibility = Visibility.Visible;
                Preview.Visibility = Visibility.Collapsed;
            }
            else if (numN==1)
            {
                NovostiFrame.Navigate(new GolKeeper());
                Next.Visibility = Visibility.Visible;
                Preview.Visibility = Visibility.Visible;
            }
        }

        private void TextBlock_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            AcademiaWindow academiaWindow = new AcademiaWindow();
            academiaWindow.Show();
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
