using System;
using System.Globalization;

namespace LearningFrench;

internal class Program
{
    static int numOfCorrect = 0;
    static int numOfWrong = 0;
    static CultureInfo cultureInfo = CultureInfo.GetCultureInfo("Nb");

    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.Unicode;
        Console.InputEncoding = System.Text.Encoding.Unicode;
        Thread.CurrentThread.CurrentCulture = cultureInfo;

        var yes = "ja" +
            "";
        var svar = "";

        while (yes.ToLower().StartsWith('j'))
        {
            Console.WriteLine("Har du lyst til å lære: substantiv, verb, adjektiv eller utrykk?");
            svar = Console.ReadLine() ?? "";
            if (svar.ToLower().StartsWith('s'))
            {
                Kode(FrenchNorwegianDict.DictionarySubstantiv);
            }
            else if(svar.ToLower().StartsWith('v'))
            {
                Kode(FrenchNorwegianDict.DictionaryVerb);
            }
            else if (svar.ToLower().StartsWith('u'))
            {
                Kode(FrenchNorwegianDict.DictionaryUtrykk);
            }
            else if (svar.ToLower().StartsWith('a'))
            {
                Kode(FrenchNorwegianDict.DictionaryAdjektiv);
            }
            else
            {
                Console.WriteLine("Beep beep bop bop");
                break;
            }
            
            Console.WriteLine("Vil du velge på nytt? ");
            yes = Console.ReadLine() ?? "";
        }
        

        Console.WriteLine("Du fikk: " + numOfCorrect + " riktige, og: " + numOfWrong + " feil");
    }

    static string GetInput(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine() ?? "";
    }

    static void Kode(Dictionary<string, string> input)
    {
        do
        {
            var numberOfWordsInDict = input.Count();

            var wordIndex = Random.Shared.Next(numberOfWordsInDict);

            var (french, norwegian) = input.ElementAt(wordIndex);

            var useFrench = Random.Shared.Next() % 2 > 0;

            var challenge = useFrench ? french : norwegian;

            Console.WriteLine(challenge);
            Console.WriteLine("= ");

            var guess = Console.ReadLine();
            var expected = useFrench ? norwegian : french;


            if (string.Compare(guess, expected, true, cultureInfo) == 0)
            {
                Console.WriteLine("Riktig!");
                numOfCorrect++;
            }
            else
            {
                Console.WriteLine("Feil!");
                Console.WriteLine("Svaret er: " + expected);
                numOfWrong++;
            }
        } while (Confirm("Vil du spille igjen? ", "j"));
    }

    static bool Confirm(string prompt, string expected)
    {
        var answer = GetInput(prompt);
        var confirmed = answer.ToLower().StartsWith(expected.ToLower());
        return confirmed;
    }
}