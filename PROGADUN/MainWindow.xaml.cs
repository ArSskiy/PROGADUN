using PROGADUN.ClassPr;
using PROGADUN.Model;
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

namespace PROGADUN
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadMatchDataForMultipleMatches();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            User newUser = ClassConnect.Ent.User.FirstOrDefault(employee => employee.Login == LoginTB.Text && employee.Password == PasswordPB.Password);
            if (newUser != null)
            {
                MessageBox.Show("вы успешно авторизовались");
                GlavWindow glavWindow = new GlavWindow();
                glavWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Вы ввели неверный логин или пароль. Пожалуйста проверьте еще раз введенные данные.");

            }
            
        }

        private void TextBlock_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            RemovePassword removePassword = new RemovePassword();
            removePassword.Show();
            this.Close();
        }
        private void LoadMatchDataForMultipleMatches()
        {
            // Вытягиваем матч по ID
            var match1 = ClassConnect.Ent.Match
                .FirstOrDefault(m => m.MatchID == 1); // Фильтруем по ID матча

            if (match1 != null)
            {
                // Устанавливаем имя матча
                TextBlockMatchName1.Text = string.IsNullOrWhiteSpace(match1.Name)
                    ? "Наименование не указано"
                    : match1.Name;

                // Устанавливаем дату
                TextBlockMatchDate1.Text = match1.DateEvent.ToString("dd.MM.yyyy");

                // Вытягиваем арену по ID из поля IdArena
                var arena = ClassConnect.Ent.Arena
                    .FirstOrDefault(a => a.ArenaID == match1.IdArena);

                TextBlockLocation1.Text = arena != null && !string.IsNullOrWhiteSpace(arena.Name)
                    ? arena.Name
                    : "Арена не указана";
            }
            else
            {
                MessageBox.Show("Матч с ID = 1 не найден.");
            }
            // Вытягиваем матч по ID
            var match2 = ClassConnect.Ent.Match
                .FirstOrDefault(m => m.MatchID == 3); // Фильтруем по ID матча

            if (match2 != null)
            {
                // Устанавливаем имя матча
                TextBlockMatchName2.Text = string.IsNullOrWhiteSpace(match2.Name)
                    ? "Наименование не указано"
                    : match2.Name;

                // Устанавливаем дату
                TextBlockMatchDate2.Text = match2.Score;

                // Вытягиваем арену по ID из поля IdArena
                var arena = ClassConnect.Ent.Arena
                    .FirstOrDefault(a => a.ArenaID == match2.IdArena);

                TextBlockLocation2.Text = arena != null && !string.IsNullOrWhiteSpace(arena.Name)
                    ? arena.Name
                    : "Арена не указана";
            }
            else
            {
                MessageBox.Show("Матч с ID = 3 не найден.");
            }
        }
    }
}
