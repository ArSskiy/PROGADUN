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
    /// Логика взаимодействия для SostavWindow.xaml
    /// </summary>
    public partial class SostavWindow : Window
    {
        public int numN = 0;

        public SostavWindow()
        {
            InitializeComponent();
            SostavFrameNAPAD.Navigate(new Napad1());
        }

        private void TextBlock_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            GlavWindow glavWindow = new GlavWindow();
            glavWindow.Show();
            this.Close();
        }

        private void TextBlock_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            AcademiaWindow academiaWindow = new AcademiaWindow();
            academiaWindow.Show();
            this.Close();
        }

        private void Preview_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            numN -= 1;
            if (numN == 0)
            {
                SostavFrameNAPAD.Navigate(new Napad1());
                SostavFramePOLUZASHITA.Navigate(new PoluZashita1());
                Next.Visibility = Visibility.Visible;
                Preview.Visibility = Visibility.Collapsed;
            }
            else if (numN == 1)
            {
                SostavFrameNAPAD.Navigate(new Napad2());
                SostavFramePOLUZASHITA.Navigate(new PoluZashita2());
                Next.Visibility = Visibility.Collapsed;
                Preview.Visibility = Visibility.Visible;
            }
        }

        private void Next_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            numN += 1;
            if (numN == 1)
            {
                SostavFrameNAPAD.Navigate(new Napad2());
                SostavFramePOLUZASHITA.Navigate(new PoluZashita2());
                Next.Visibility = Visibility.Collapsed;
                Preview.Visibility = Visibility.Visible;
            }
        }

        private void TextBlock_MouseLeftButtonUp_2(object sender, MouseButtonEventArgs e)
        {
            numN = 0;
            Next.Visibility = Visibility.Visible;
            Preview.Visibility = Visibility.Collapsed;
            SostavFramePOLUZASHITA.Visibility = Visibility.Collapsed;
            SostavFrameNAPAD.Navigate(new Napad1());
            SostavFrameNAPAD.Visibility = Visibility.Visible;
        }

        private void TextBlock_MouseLeftButtonUp_3(object sender, MouseButtonEventArgs e)
        {
            numN = 0;
            Next.Visibility = Visibility.Visible;
            Preview.Visibility = Visibility.Collapsed;
            SostavFrameNAPAD.Visibility = Visibility.Collapsed;
            SostavFramePOLUZASHITA.Navigate(new PoluZashita1());
            SostavFramePOLUZASHITA.Visibility = Visibility.Visible;
        }
    }
}
