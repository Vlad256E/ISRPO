using System;

namespace Lab6A
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Лабораторная работа 6А. Фигуры.");

            while (true) // Бесконечный цикл, чтобы программа не закрывалась сразу
            {
                Console.WriteLine("\nВыберите тип фигуры (1-Прямоугольник, 2-Квадрат, 3-Круг, 0-Выход):");
                string choice = Console.ReadLine();

                if (choice == "0") break; // Выход из программы

                try
                {
                    if (choice == "1")
                    {
                        Console.Write("Введите ширину: ");
                        double w = double.Parse(Console.ReadLine());
                        Console.Write("Введите высоту: ");
                        double h = double.Parse(Console.ReadLine());

                        // Создаем объект и выводим 
                        Rect r = new Rect(w, h);
                        r.Show();
                    }
                    else if (choice == "2")
                    {
                        Console.Write("Введите сторону квадрата: ");
                        double s = double.Parse(Console.ReadLine());

                        Square sq = new Square(s);
                        sq.Show();
                    }
                    else if (choice == "3")
                    {
                        Console.Write("Введите радиус: ");
                        double r = double.Parse(Console.ReadLine());

                        Circle c = new Circle(r);
                        c.Show();
                    }
                    else
                    {
                        Console.WriteLine("Неверный выбор.");
                    }
                }
                catch
                {
                    Console.WriteLine("Ошибка! Нужно вводить только цифры (и запятую, если число дробное).");
                }
            }
        }
    }
}