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

namespace Lab6A_WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Это событие нажатия на кнопку
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string output = "";

                // Смотрим, какой пункт выбран в выпадающем списке (0, 1 или 2)
                if (ComboShape.SelectedIndex == 0) // Прямоугольник
                {
                    double w = double.Parse(Box1.Text);
                    double h = double.Parse(Box2.Text);

                    Rect r = new Rect(w, h);
                    // Формируем красивый текст
                    output = r.GetInfo();
                }
                else if (ComboShape.SelectedIndex == 1) // Квадрат
                {
                    double s = double.Parse(Box1.Text);

                    Square sq = new Square(s);
                    // Формируем красивый текст
                    output = sq.GetInfo();
                }
                else if (ComboShape.SelectedIndex == 2) // Круг
                {
                    double r = double.Parse(Box1.Text);

                    Circle c = new Circle(r);
                    // Формируем красивый текст
                    output = c.GetInfo();
                }

                // Выводим результат в текстовый блок на экране
                TextResult.Text = output;
            }
            catch
            {
                MessageBox.Show("Пожалуйста, введите корректные числа!");
            }
        }

        // Это событие смены выбора в списке. Прячет второе поле ввода.
        private void ComboShape_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Защита от ошибок при загрузке
            if (Box2 == null) return;

            if (ComboShape.SelectedIndex == 0) // Если выбран Прямоугольник
            {
                Box2.Visibility = Visibility.Visible;   // Показать второе поле
                Label2.Visibility = Visibility.Visible; // Показать подпись
            }
            else // Если Квадрат или Круг (им нужно только одно число)
            {
                Box2.Visibility = Visibility.Collapsed; // Скрыть
                Label2.Visibility = Visibility.Collapsed;
            }
        }
    }
}