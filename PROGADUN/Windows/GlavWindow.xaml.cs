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
    /// Логика взаимодействия для GlavWindow.xaml
    /// </summary>
    public partial class GlavWindow : Window
    {
        public int numN = 0;
        public GlavWindow()
        {
            InitializeComponent();
            LoadMatchDataForMultipleMatches();
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

        

        private void TextBlock_MouseLeftButtonUp_3(object sender, MouseButtonEventArgs e)
        {
            ZayavkaWindow zayavka = new ZayavkaWindow();
            zayavka.Show();
        }

        private void TextBlock_MouseLeftButtonUp_2(object sender, MouseButtonEventArgs e)
        {
            MatchWindow matchWindow = new MatchWindow();
            matchWindow.Show();
        }
    }
}
