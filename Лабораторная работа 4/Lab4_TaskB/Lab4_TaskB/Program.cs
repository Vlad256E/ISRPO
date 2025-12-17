using System;

namespace Lab4_TaskB
{
    // Интерфейсы и классы
    interface ICup
    {
        string CupMaterial { get; set; }
        double Capacity { get; set; }
        void Refill();
        void Wash();
    }

    abstract class HotDrink
    {
        public abstract void Drink();
        public abstract void AddMilk(int amount);
        public abstract void AddSugar(int amount);
    }

    class CupOfCoffee : HotDrink, ICup
    {
        public string BeanType { get; set; }
        public string CupMaterial { get; set; }
        public double Capacity { get; set; }

        public override void Drink()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Получите кофе: {BeanType}");
            Console.ResetColor();
        }

        public override void AddMilk(int amount)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"В кофе добавлено молоко: {amount}");
            Console.ResetColor();
        }

        public override void AddSugar(int amount)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"В кофе добавлен сахар: {amount}");
            Console.ResetColor();
        }

        public void Refill()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Повторить кофе объемом {Capacity} мл");
            Console.ResetColor();
        }

        public void Wash()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Вымыть {CupMaterial} чашку с кофе");
            Console.ResetColor();
        }
    }

    class CupOfTea : HotDrink, ICup
    {
        public string LeafType { get; set; }
        public string CupMaterial { get; set; }
        public double Capacity { get; set; }

        public override void Drink()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Получите чай: {LeafType}");
            Console.ResetColor();
        }

        public override void AddMilk(int amount)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"В чай добавлено молоко: {amount}");
            Console.ResetColor();
        }

        public override void AddSugar(int amount)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"В чай добавлен сахар: {amount}");
            Console.ResetColor();
        }

        public void Refill()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Повторить чай объемом {Capacity} мл");
            Console.ResetColor();
        }

        public void Wash()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Вымыть {CupMaterial} чашку с чаем");
            Console.ResetColor();
        }
    }

    class Program
    {
        // Метод для вопроса: пишет белый вопрос и читает красный ответ
        static string Ask(string question, string defaultValue)
        {
            Console.Write(question + " "); // Белый текст
            Console.ForegroundColor = ConsoleColor.Red;
            string input = Console.ReadLine(); // Красный ввод
            Console.ResetColor();

            if (input == "") return defaultValue;
            return input;
        }

        // Функция ProcessCup
        static void ProcessCup(HotDrink drink, ICup cup, int sugar, int milk)
        {
            drink.AddSugar(sugar);
            drink.AddMilk(milk);
            drink.Drink();

            cup.Wash();
            cup.Refill();
        }

        static void Main(string[] args)
        {
            // Выбор напитка
            string type = Ask("Выберите напиток: кофе (1) или чай (2):", "1");

            // Вывод справочной информации
            if (type == "1")
            {
                Console.WriteLine("Тип зерен: арабика или робуста (по умолч. арабика);");
            }
            else
            {
                Console.WriteLine("Тип чая: черный или зеленый (по умолч. черный);");
            }
            Console.WriteLine("Сахар: 0...5 (по умолч. 3);");
            Console.WriteLine("Молоко: 0...10 (по умолч. 3);");
            Console.WriteLine("Тип стакана: пластик или стекло (по умолч. пластик);");
            Console.WriteLine("Объем: 0,2 или 0,3 (по умолч. 0,2)");
            Console.WriteLine(); // Пустая строка отступа

            // Поочерёдный ввод параметров (спрашиваем конкретные значения одно за другим)
            string specificType = "";
            if (type == "1")
                specificType = Ask("Тип зерен:", "арабика");
            else
                specificType = Ask("Тип чая:", "черный");

            string s_milk = Ask("Молоко:", "3");
            int milk = int.Parse(s_milk);

            string s_sugar = Ask("Сахар:", "3");
            int sugar = int.Parse(s_sugar);

            string cupMat = Ask("Тип стакана:", "пластик");

            string s_vol = Ask("Объем (мл):", "0,2");
            double vol = double.Parse(s_vol);

            Console.WriteLine("-------------------------");

            // Создание объекта и вывод результатов работы методов
            ICup myCup = null;
            HotDrink myDrink = null;

            if (type == "1")
            {
                CupOfCoffee coffee = new CupOfCoffee();
                coffee.BeanType = specificType;
                coffee.CupMaterial = cupMat;
                coffee.Capacity = vol;
                myCup = coffee;
                myDrink = coffee;
            }
            else
            {
                CupOfTea tea = new CupOfTea();
                tea.LeafType = specificType;
                tea.CupMaterial = cupMat;
                tea.Capacity = vol;
                myCup = tea;
                myDrink = tea;
            }

            // Вывод
            ProcessCup(myDrink, myCup, sugar, milk);

            Console.ReadKey();
        }
    }
}