using PROGADUN.ClassPr;
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
    /// Логика взаимодействия для ZayavkaWindow.xaml
    /// </summary>
    public partial class ZayavkaWindow : Window
    {
        public ZayavkaWindow()
        {
            InitializeComponent();
        }

        private void DatGr_Loaded(object sender, RoutedEventArgs e)
        {
            DatGr.ItemsSource = ClassConnect.Ent.MemberShip.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ClassConnect.Ent.SaveChanges();
            MessageBox.Show("Изменения сохранены.");
        }
    }
}
