using System;
using System.Collections.Generic; // Нужно для работы со списками (List)
using System.Linq; // Нужно для поиска в списке (FirstOrDefault)
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace CoffeeMachine
{
    public partial class MainWindow : Window
    {
        // Список напитков (Меню) — выполняем требование использовать классы
        List<Drink> menu = new List<Drink>();

        // Текущий выбранный объект-напиток
        Drink selectedDrink = null;

        int currentBalance = 0;

        public MainWindow()
        {
            InitializeComponent();
            InitializeMenu(); // Заполняем автомат напитками при запуске
        }

        // Метод инициализации меню
        private void InitializeMenu()
        {
            // Создаем объекты класса Drink и добавляем их в список
            menu.Add(new Drink("Американо", 30, "americano.jpg"));
            menu.Add(new Drink("Капучино", 40, "cappuccino.jpg"));
            menu.Add(new Drink("Эспрессо", 25, "espresso.jpg"));
            menu.Add(new Drink("Какао", 35, "cocoa.jpg"));
        }

        // Внесение денег
        private void BtnEnterMoney_Click(object sender, RoutedEventArgs e)
        {
            if (TbMoneyInput.Text == "0" || string.IsNullOrWhiteSpace(TbMoneyInput.Text))
                return;

            if (int.TryParse(TbMoneyInput.Text, out int moneyAdded))
            {
                currentBalance += moneyAdded;
                TxtBalance.Text = $"Внесенная сумма: {currentBalance}";
                TbMoneyInput.Text = "0"; // Сброс поля ввода
            }
            else
            {
                MessageBox.Show("Введите корректное число!");
                TbMoneyInput.Text = "0";
            }
        }

        // Выбор напитка (Исправленная логика через Классы)
        private void Drink_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb == null) return;

            string nameFromButton = rb.Content.ToString();

            // Ищем напиток в списке menu по названию
            selectedDrink = menu.FirstOrDefault(d => d.Name == nameFromButton);

            if (selectedDrink != null)
            {
                // Обновляем цену в интерфейсе, беря её из объекта
                TxtPrice.Text = $"Цена напитка: {selectedDrink.Price}";

                // Обновляем картинку, беря путь из объекта
                try
                {
                    // Картинки лежат в папке Images проекта
                    ImgMain.Source = new BitmapImage(new Uri($"/Images/{selectedDrink.ImagePath}", UriKind.Relative));
                }
                catch
                {
                    ImgMain.Source = null;
                }
            }
        }

        // Управление добавками (логика отображения картинок)
        private void Addon_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            if (cb.Name == "CbSugar") ImgSugar.Visibility = Visibility.Visible;
            if (cb.Name == "CbMilk") ImgMilk.Visibility = Visibility.Visible;
        }

        private void Addon_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            if (cb.Name == "CbSugar") ImgSugar.Visibility = Visibility.Hidden;
            if (cb.Name == "CbMilk") ImgMilk.Visibility = Visibility.Hidden;
        }

        // Нажатие кнопки ОК
        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            // Проверка: выбран ли напиток
            if (selectedDrink == null)
            {
                MessageBox.Show("Пожалуйста, выберите напиток.");
                return;
            }

            // Проверка: хватает ли денег
            if (currentBalance < selectedDrink.Price)
            {
                int needed = selectedDrink.Price - currentBalance;
                MessageBox.Show($"Недостаточно средств. Не хватает {needed} руб.");
                return;
            }

            // Расчёт сдачи
            int change = currentBalance - selectedDrink.Price;
            TxtChange.Text = $"Сдача: {change}";

            // Формирование сообщения о готовности
            string details = selectedDrink.Name;
            if (CbSugar.IsChecked == true) details += " + Сахар";
            if (CbMilk.IsChecked == true) details += " + Молоко";

            MessageBox.Show($"Готово: {details}\nЗаберите сдачу: {change} руб.");

            // Счёт в Label обнуляется
            currentBalance = 0;
            TxtBalance.Text = "Внесенная сумма: 0";

            // Сброс сдачи
            TxtChange.Text = "Сдача:";
        }
    }
}