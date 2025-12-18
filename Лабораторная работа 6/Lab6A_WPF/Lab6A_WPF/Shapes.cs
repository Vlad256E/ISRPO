using System;

// Базовый класс фигура 
public class Shape
{
    protected double Area; // Площадь
    protected double Perimeter; // Периметр
    protected string Name; // Название

    // Конструктор по умолчанию (задает 0, 0, "без названия") 
    public Shape()
    {
        Area = 0;
        Perimeter = 0;
        Name = "без названия";
    }

    // Метод вывода данных на консоль 
    public virtual void Show()
    {
        Console.WriteLine($"Фигура: {Name}");
        Console.WriteLine($"Площадь: {Area:F2}"); // Обрезает до 2 знаков после запятой
        Console.WriteLine($"Периметр: {Perimeter:F2}");
    }

    // Добавляем метод для получения строки (нужен для WPF)
    public string GetInfo()
    {
        return $"Фигура: {Name}\nПлощадь: {Area:F2}\nПериметр: {Perimeter:F2}";
    }
}

// Класс прямоугольник (Наследник Shape) 
public class Rect : Shape
{
    protected double width;
    protected double height;

    // Конструктор по умолчанию 
    public Rect() : base() // Вызывает конструктор родителя (Shape)
    {
        Name = "Прямоугольник";
        width = 0;
        height = 0;
    }

    // Конструктор с параметрами 
    public Rect(double w, double h)
    {
        Name = "Прямоугольник";
        width = w;
        height = h;
        Calculate(); // Считаем 
    }

    public void Calculate()
    {
        Area = width * height;
        Perimeter = 2 * (width + height);
    }
}

// Класс квадрат (Наследник Прямоугольника), потому что как прямоугольник, но у него все стороны равны
public class Square : Rect
{
    // Конструктор принимает одну сторону (side), а затем передаёт как две, потому что СТОРОНЫ РАВНЫ у квадрата
    public Square(double side) : base(side, side)
    {
        Name = "Квадрат";
        // Площадь и периметр уже посчитались в Rect, нам ничего писать не надо
    }
}

// Класс окружность (Наследник Shape) 
public class Circle : Shape
{
    private double radius;

    // Конструктор по умолчанию 
    public Circle() : base()
    {
        Name = "Окружность";
        radius = 0;
    }

    // Конструктор с параметрами
    public Circle(double r)
    {
        Name = "Окружность";
        radius = r;

        Area = Math.PI * radius * radius;
        Perimeter = 2 * Math.PI * radius;
    }
}