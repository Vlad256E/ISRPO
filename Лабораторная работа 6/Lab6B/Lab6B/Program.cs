using System;

namespace Lab6B
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck myDeck = new Deck();

            Console.WriteLine("Первые 5 карт новой колоды");
            for (int i = 0; i < 5; i++)
                Console.WriteLine(myDeck.GetCard(i));

            Console.WriteLine("\nПеремешиваем...");
            myDeck.Shuffle(); 

            Console.WriteLine("Первые 5 карт перемешанной колоды");
            for (int i = 0; i < 5; i++)
                Console.WriteLine(myDeck.GetCard(i));

            Console.ReadKey();
        }
    }
}