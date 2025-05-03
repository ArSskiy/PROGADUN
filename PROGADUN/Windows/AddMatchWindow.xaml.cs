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
    /// Логика взаимодействия для AddMatchWindow.xaml
    /// </summary>
    public partial class AddMatchWindow : Window
    {
        public AddMatchWindow()
        {
            InitializeComponent();
            ArenaCmb.SelectedValuePath = "ArenaID";
            ArenaCmb.DisplayMemberPath = "Name";
            ArenaCmb.ItemsSource = ClassConnect.Ent.Arena.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string mes = "";
            if (string.IsNullOrWhiteSpace(NameTb.Text))
            {
                mes += "Введите название\n";
            }
            if (string.IsNullOrWhiteSpace(GuestTb.Text))
            {
                mes += "Введите гостей\n";
            }
            if (mes != "")
            {
                MessageBox.Show(mes);
                mes = "";
                return;
            }
            Match match = new Match()
            {
                Name = NameTb.Text,
                Guest = GuestTb.Text,
                Arena = ArenaCmb.SelectedItem as Arena,
                DateEvent = DateDP.DisplayDate

            };
            ClassConnect.Ent.Match.Add(match);
            ClassConnect.Ent.SaveChanges();
            MessageBox.Show("Заявка отправлена");

            NameTb.Text = "";
            ArenaCmb.Text = "";

            this.Close();
        }
    }
}
