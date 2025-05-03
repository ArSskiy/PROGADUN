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

namespace PROGADUN.Pages
{
    /// <summary>
    /// Логика взаимодействия для AttackShemaPage.xaml
    /// </summary>
    public partial class AttackShemaPage : Page
    {
        private Point _startPoint;
        private UIElement _currentElement;
        public AttackShemaPage()
        {
            InitializeComponent();
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _currentElement = sender as UIElement;
            _startPoint = e.GetPosition(this);
            _currentElement.CaptureMouse();
        }

        private void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (_currentElement != null)
            {
                _currentElement.ReleaseMouseCapture();
                _currentElement = null;
            }
        }

        private void Image_MouseMove(object sender, MouseEventArgs e)
        {
            if (_currentElement != null && _currentElement.IsMouseCaptured)
            {
                Point currentPoint = e.GetPosition(this);
                double offsetX = currentPoint.X - _startPoint.X;
                double offsetY = currentPoint.Y - _startPoint.Y;

                // Проверка или установка TranslateTransform
                if (!(_currentElement.RenderTransform is TranslateTransform transform))
                {
                    transform = new TranslateTransform();
                    _currentElement.RenderTransform = transform;
                }

                transform.X += offsetX;
                transform.Y += offsetY;

                _startPoint = currentPoint;
            }
        }

      
    }
}
