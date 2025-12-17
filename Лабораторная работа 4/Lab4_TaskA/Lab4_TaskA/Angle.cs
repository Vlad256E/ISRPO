using System;

namespace Lab4_TaskA
{
    class Angle
    {
        private int degrees;
        private float minutes;
        private char direction;

        // Конструктор по умолчанию (без параметров)
        // Задание требует инициализировать значениями: 0, 0, 'S' 
        public Angle()
        {
            degrees = 0;
            minutes = 0;
            direction = 'S';
        }

        // Конструктор с тремя аргументами 
        public Angle(int d, float m, char dir)
        {
            degrees = d;
            minutes = m;
            direction = dir;
        }

        // Метод для ввода координат с клавиатуры 
        public void InputAngle()
        {
            Console.WriteLine("Введите градусы:");
            degrees = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите минуты:");
            minutes = float.Parse(Console.ReadLine());

            Console.WriteLine("Введите направление (N, S, E, W):");
            direction = Console.ReadKey().KeyChar; // Читаем один символ
            Console.WriteLine(); // Переход на новую строку
        }

        // Метод для вывода значения на экран 
        public void ShowAngle()
        {
            Console.WriteLine($"Координата: {degrees}° {minutes}' {direction}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Сценарий 1: Вызов конструктора с параметрами 
            Console.WriteLine("Тест 1: Объект с параметрами");
            Angle angle1 = new Angle(45, 12.5f, 'N');
            angle1.ShowAngle();

            // Сценарий 2: Вызов конструктора без параметров и ручной ввод 
            Console.WriteLine("\nТест 2: Объект по умолчанию и ввод");
            Angle angle2 = new Angle();
            angle2.InputAngle(); // Запрашиваем значения 
            angle2.ShowAngle(); // Отображаем введенное 

            Console.ReadKey();
        }
    }
}