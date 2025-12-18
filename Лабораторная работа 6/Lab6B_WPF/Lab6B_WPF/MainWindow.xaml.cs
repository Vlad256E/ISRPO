using System.Windows;
using System.Windows.Controls; // Для Button и WrapPanel
using System.Windows.Controls.Primitives;
using System.Windows.Media;    // Для цветов (Brushes)

namespace Lab6B_WPF
{
    public partial class MainWindow : Window
    {
        Deck deck; // Наша колода

        public MainWindow()
        {
            InitializeComponent();
            deck = new Deck(); // Создаем колоду 
            DrawDeck();        // Рисуем её при запуске
        }

        // Кнопка перемешивания
        private void ShuffleBtn_Click(object sender, RoutedEventArgs e)
        {
            deck.Shuffle(); // Мешаем данные 
            DrawDeck();     // Перерисовываем интерфейс
        }

        // Метод отрисовки карт кодом 
        private void DrawDeck()
        {
            // 1. Очищаем панель от старых кнопок
            TablePanel.Children.Clear();

            // 2. Цикл по всем 52 картам
            for (int i = 0; i < 52; i++)
            {
                Card card = deck.GetCard(i);

                // 3. Программно создаем кнопку для каждой карты
                Button btn = new Button();
                btn.Content = card.ToString(); // Текст на кнопке

                // Настройки внешнего вида (чтобы было похоже на карту)
                btn.Width = 70;
                btn.Height = 100;
                btn.Margin = new Thickness(5);
                btn.FontSize = 14;
                btn.Background = Brushes.White;

                // Красим масти в красный или черный
                string text = card.ToString();
                if (text.Contains("♥") || text.Contains("♦"))
                    btn.Foreground = Brushes.Red;
                else
                    btn.Foreground = Brushes.Black;

                // 4. Добавляем кнопку в контейнер (WrapPanel)
                TablePanel.Children.Add(btn);
            }
        }
    }
}