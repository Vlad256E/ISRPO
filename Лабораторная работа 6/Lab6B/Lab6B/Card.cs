using System;

namespace Lab6B
{
    public class Card
    {
        private string suit; // Масть
        private string rank; // Ранг

        // Закрытый конструктор по умолчанию 
        // Это значит, что нельзя написать new Card() без параметров
        private Card() { }

        // Конструктор с параметрами 
        public Card(string s, string r)
        {
            this.suit = s;
            this.rank = r;
        }

        // Переопределение метода ToString 
        // Возвращает строку вида "Король ♠"
        public override string ToString()
        {
            return rank + " " + suit;
        }
    }
}