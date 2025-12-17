using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ElevatorApp
{
    public partial class MainWindow : Window
    {
        // Создаем переменную для нашего лифта
        Elevator myElevator;

        public MainWindow()
        {
            InitializeComponent();
        }

        // 1. Кнопка "Создать лифт"
        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            // Пробуем получить число из текстового поля 
            if (int.TryParse(TbFloors.Text, out int floors) && floors > 1)
            {
                // Инициализируем объект класса
                myElevator = new Elevator();
                myElevator.TotalFloors = floors;

                // Включаем панель управления и блокируем ввод этажей
                ControlPanel.IsEnabled = true;
                TbFloors.IsEnabled = false;
                BtnCreate.IsEnabled = false;

                UpdateUI(); // Обновляем экран
            }
            else
            {
                MessageBox.Show("Введите корректное число этажей (больше 1).");
            }
        }

        // 2. Кнопки движения (ВВЕРХ / ВНИЗ)
        private void BtnMove_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            string direction = btn.Tag.ToString(); // Получаем тег кнопки (UP или DOWN)

            if (direction == "UP")
            {
                myElevator.MoveUp();
            }
            else if (direction == "DOWN")
            {
                myElevator.MoveDown();
            }

            UpdateUI();
        }

        // 3. Кнопки дверей (ОТКРЫТЬ / ЗАКРЫТЬ)
        private void BtnDoor_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            string action = btn.Tag.ToString();

            if (action == "OPEN")
            {
                myElevator.OpenDoor();
            }
            else if (action == "CLOSE")
            {
                myElevator.CloseDoor();
            }

            UpdateUI();
        }

        // Метод обновления интерфейса после любого действия
        private void UpdateUI()
        {
            // Обновляем цифру этажа
            TxtFloor.Text = myElevator.CurrentFloor.ToString();

            // Обновляем сообщение
            TxtMessage.Text = myElevator.Message;

            // Визуализация дверей (Красный - закрыты, Зеленый - открыты)
            if (myElevator.IsDoorOpen)
            {
                TxtDoorStatus.Text = "[ ДВЕРИ ОТКРЫТЫ ]";
                TxtDoorStatus.Foreground = Brushes.Green;
            }
            else
            {
                TxtDoorStatus.Text = "[ ДВЕРИ ЗАКРЫТЫ ]";
                TxtDoorStatus.Foreground = Brushes.Red;
            }
        }
    }
}