using System;
using Lab6B_WPF;

namespace Lab6B_WPF
{
    public class Deck
    {
        // Массив из 52 карт 
        private Card[] cards;

        // Конструктор по умолчанию 
        public Deck()
        {
            cards = new Card[52];

            // Списки для генерации
            string[] suits = { "♥", "♦", "♣", "♠" };
            string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Валет", "Дама", "Король", "Туз" };

            int index = 0;
            // Двойной цикл для заполнения колоды
            foreach (string s in suits)
            {
                foreach (string r in ranks)
                {
                    cards[index] = new Card(s, r);
                    index++;
                }
            }
        }

        // Метод получения карты по индексу 
        public Card GetCard(int index)
        {
            if (index >= 0 && index < 52)
                return cards[index];
            return null;
        }

        // Метод ручной установки карты
        public void SetCard(int index, string s, string r)
        {
            if (index >= 0 && index < 52)
                cards[index] = new Card(s, r);
        }

        // Метод перемешивания 
        public void Shuffle()
        {
            Random rnd = new Random();
            for (int i = 0; i < cards.Length; i++)
            {
                // Выбираем случайную карту
                int j = rnd.Next(cards.Length);

                // Меняем местами текущую карту (i) и случайную (j)
                Card temp = cards[i];
                cards[i] = cards[j];
                cards[j] = temp;
            }
        }
    }
}