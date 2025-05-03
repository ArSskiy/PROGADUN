using PROGADUN.ClassPr;
using PROGADUN.Model;
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
    /// Логика взаимодействия для AnketaWindow.xaml
    /// </summary>
    public partial class AnketaWindow : Window
    {
        public AnketaWindow()
        {
            InitializeComponent();
            RoleCmb.SelectedValuePath = "RoleID";
            RoleCmb.DisplayMemberPath = "Name";
            RoleCmb.ItemsSource = ClassConnect.Ent.Role.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string mes = "";
            if (string.IsNullOrWhiteSpace(NameTb.Text))
            {
                mes += "Введите имя\n";
            }
            if (string.IsNullOrWhiteSpace(AgeTb.Text))
            {
                mes += "Введите возраст\n";
            }
            if (mes != "")
            {
                MessageBox.Show(mes);
                mes = "";
                return;
            }
            MemberShip member = new MemberShip()
            {
                Name = NameTb.Text,
                Age= Convert.ToInt32(AgeTb.Text),
                Role = RoleCmb.SelectedItem as Role,
                DateOfBrth= DateDP.DisplayDate

            };
            ClassConnect.Ent.MemberShip.Add(member);
            ClassConnect.Ent.SaveChanges();
            MessageBox.Show("Заявка отправлена");

            NameTb.Text = "";
            RoleCmb.Text = "";
            
            this.Close();
        }
    }
}
