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
    /// Логика взаимодействия для RemovePassword.xaml
    /// </summary>
    public partial class RemovePassword : Window
    {
        public RemovePassword()
        {
            InitializeComponent();
            LoadMatchDataForMultipleMatches();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTB.Text;
            string newPassword = NewPasswordPB.Password;
            string repeatNewPassword = RepeatPasswordPB.Password;

            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(newPassword) || string.IsNullOrWhiteSpace(repeatNewPassword))
            {
                MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (newPassword==repeatNewPassword)
            {
                // Поиск пользователя по логину
                var user = ClassConnect.Ent.User.FirstOrDefault(u => u.Login == login);

                if (user == null)
                {
                    MessageBox.Show("Пользователь не найден!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Обновление пароля
                user.Password = newPassword;
                try
                {
                    ClassConnect.Ent.SaveChanges();
                    MessageBox.Show("Пароль успешно изменён!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при сохранении данных: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Новый пароль не совпадает с повторным!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
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
