namespace CoffeeMachine
{
    // Класс для описания напитка, как требуется в задании
    public class Drink
    {
        public string Name { get; set; }      // Название
        public int Price { get; set; }        // Цена
        public string ImagePath { get; set; } // Путь к картинке

        public Drink(string name, int price, string imagePath)
        {
            Name = name;
            Price = price;
            ImagePath = imagePath;
        }
    }
}