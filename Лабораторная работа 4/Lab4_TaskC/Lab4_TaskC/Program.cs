using System;

namespace Lab4_TaskC
{
    struct Orders
    {
        public string itemname; // Наименование
        public int unitCount; // Число единиц
        public double unitCost; // Стоимость одной единицы

        // Функция, которая возвращает суммарную стоимость заказа 
        public double GetTotalCost()
        {
            return unitCount * unitCost;
        }

        // Вспомогательный метод, чтобы красиво вывести чек
        public void PrintCheck()
        {
            Console.WriteLine("\n---------- ЧЕК ----------");
            Console.WriteLine($"Товар:    {itemname}");
            Console.WriteLine($"Кол-во:   {unitCount} шт.");
            Console.WriteLine($"Цена:     {unitCost} руб.");
            Console.WriteLine("-------------------------");
            
            // Вызов метода подсчета стоимости
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"ИТОГО:    {GetTotalCost()} руб.");
            Console.ResetColor();
            Console.WriteLine("-------------------------");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Создаем экземпляр структуры 
            Orders myOrder = new Orders();

            Console.WriteLine("Оформление нового заказа");

            // Ввод данных

            // Вводим название
            Console.Write("Введите наименование товара: ");
            Console.ForegroundColor = ConsoleColor.Red;
            myOrder.itemname = Console.ReadLine();
            Console.ResetColor();

            // Вводим количество
            Console.Write("Введите количество (шт): ");
            Console.ForegroundColor = ConsoleColor.Red;

            // int.Parse превращает текст в целое число
            myOrder.unitCount = int.Parse(Console.ReadLine());
            Console.ResetColor();

            // Вводим цену
            Console.Write("Введите стоимость за единицу: ");
            Console.ForegroundColor = ConsoleColor.Red; // Меняем цвет

            // double.Parse превращает текст в дробное число
            myOrder.unitCost = double.Parse(Console.ReadLine());
            Console.ResetColor();
            
            // Выводим результаты
            myOrder.PrintCheck();

            Console.ReadKey();
        }
    }
}