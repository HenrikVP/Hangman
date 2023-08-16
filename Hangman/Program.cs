namespace Hangman
{
    internal class Program
    {
        static string guessedLetters ="";
        //\r\\r\nBlyant\r\nVindmølle\r\nChokolade\r\nRegnbue\r\nSkjorte\r\nTelefon\r\nBjergtop\r\nFuglesang\r\nLommelygte\r\nCykel\r\nHavbølge\r\nStjerneskud\r\nPandekage\r\nMikroskop\r\nLænestol\r\nRaket\r\nKaktus

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, and welcome to hangman");
            string word = RandomWord();
            string letter = InputLetter();
            AddLetterToGuessed(letter);
            GUI(word);
        }

        static string InputLetter()
        {
            char letter;
            do
            {
                Console.Write("\nInput a letter: ");
                letter = Console.ReadKey().KeyChar;
            }
            while (!char.IsLetter(letter));

            return letter.ToString();
        }

        static void AddLetterToGuessed(string letter)
        {
            if (guessedLetters.Contains(letter))
            {
                Console.WriteLine("You already guessed that letter!");
            }
            else { guessedLetters += letter; }
        }

        static void TestingKeyboard()
        {
            while (true)
            {
                ConsoleKeyInfo letter = Console.ReadKey();
                Console.WriteLine(letter + " " + (int)letter.KeyChar);
            }
        }

        static void GUI(string word)
        {
            //If letter is in position in a loop of char in words,
            //then write the letter otherwise write underscore
            //int numLetters = word.Length;
            foreach (char letter in word) 
            {
                if (guessedLetters.Contains(letter)) Console.Write(letter);
                else Console.Write("_");
            }
            
            //for (int i = 0; i < numLetters; i++)
            //{
            //    if (guessedLetters.Contains(word[i])) Console.Write(word[i]);
            //    else Console.Write("_");
            //}

            //string underScores = "".PadLeft(numLetters, '_');
            //Console.WriteLine(underScores);
        }

        static string RandomWord()
        {
            string[] words = { "Kaffekrus", "Elefant", "Skygge", "Blyant", "Vindmølle", "Chokolade", "Regnbue", "Skjorte", "Telefon", "Bjergtop", "Fuglesang", "Lommelygte", "Havbølge", "Stjerneskud", };

            //return words[new Random().Next(words.Length)]; ;

            Random rnd = new Random();
            int num = rnd.Next(words.Length);
            string word = words[num];
            return word;
        }
    }
}