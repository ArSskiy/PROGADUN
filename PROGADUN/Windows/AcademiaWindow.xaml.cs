using PROGADUN.ClassPr;
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
            Shema.SelectedValuePath = "ShemaID";
            Shema.DisplayMemberPath = "Name";
            Shema.ItemsSource = ClassConnect.Ent.ShemaIgr.ToList();
            LoadMatchDataForMultipleMatches();
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

        private void TextBlock_MouseLeftButtonUp_2(object sender, MouseButtonEventArgs e)
        {
            ZayavkaWindow zayavka = new ZayavkaWindow();
            zayavka.Show();
        }

        private void Shema_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Shema.SelectedValue != null)
            {
                int selectedId = (int)Shema.SelectedValue;

                switch (selectedId)
                {
                    case 1:
                        PoleFrame.Navigate(new AttackShemaPage()); // Страница для схемы 433Attack
                        break;
                    case 2:
                        PoleFrame.Navigate(new _433Zahit()); // Страница для схемы 433Defence
                        break;
                    default:
                        MessageBox.Show("Страница не найдена");
                        break;
                }
            }
        }

        private void TextBlock_MouseLeftButtonUp_3(object sender, MouseButtonEventArgs e)
        {
            MatchWindow matchWindow = new MatchWindow();
            matchWindow.Show();
        }
    }
}
