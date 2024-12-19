using System;

namespace LearningFrench;

internal class Program
{
    static void Main(string[] args)
    {
        var cultureInfo = System.Globalization.CultureInfo.GetCultureInfo("Nb");
        Console.OutputEncoding = System.Text.Encoding.Unicode;
        Console.InputEncoding = System.Text.Encoding.Unicode;
        Thread.CurrentThread.CurrentCulture = cultureInfo;

        var numberOfWordsInDict = FrenchNorwegianDict.Dictionary.Count;

        var ja = "Ja";

        while (ja.ToLower().StartsWith('j')) 
        {
            var wordIndex = Random.Shared.Next(numberOfWordsInDict);

            var (french, norwegian) = FrenchNorwegianDict.Dictionary.ElementAt(wordIndex);

            var useFrench = Random.Shared.Next() % 2 > 0;

            var challenge = useFrench ? french : norwegian;

            Console.WriteLine(challenge);
            Console.WriteLine("= ");

            var guess = Console.ReadLine();
            var expected = useFrench ? norwegian : french;


            if (string.Compare(guess, expected, true, cultureInfo) == 0)
            {
                Console.WriteLine("Riktig!");
            }
            else
            {
                Console.WriteLine("Feil!");
                Console.WriteLine("Svaret er: " + expected);
            }

            Console.WriteLine("Vil du spille igjen?");
            ja = Console.ReadLine() ?? "";
        }
    }
}