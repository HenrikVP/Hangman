namespace Hangman
{
    internal class Program
    {
        static int livesLeft = 6;
        static string guessedLetters = "";
        //\r\\r\nBlyant\r\nVindmølle\r\nChokolade\r\nRegnbue\r\nSkjorte\r\nTelefon\r\nBjergtop\r\nFuglesang\r\nLommelygte\r\nCykel\r\nHavbølge\r\nStjerneskud\r\nPandekage\r\nMikroskop\r\nLænestol\r\nRaket\r\nKaktus

        //TODO wrong answer should cost a life.
        //TODO Finish game when all letters have been guessed.

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, and welcome to hangman");
            string word = RandomWord();

            while (true)
            {
                GUI(word);
                string letter = InputLetter();
                AddLetterToGuessed(letter);
                IsLetterInWord(word, letter);
            }
        }

        static string InputLetter()
        {
            char letter;
            do
            {
                Console.Write("\n\nInput a letter: ");
                letter = char.ToUpper(Console.ReadKey().KeyChar);
            }
            while (!char.IsLetter(letter));

            return letter.ToString();
        }

        static void IsLetterInWord(string word, string letter)
        {
            if (word.Contains(letter)) Console.WriteLine("\nGood job!");
            else
            {
                Console.WriteLine("\nWRONG!!!");
                Hangman();
            }
        }

        static void Hangman()
        {
            livesLeft--;
            if (livesLeft == 0) { Console.WriteLine("You killed a man!"); }
            //TODO finish the game, ask for a retry
        }

        static void AddLetterToGuessed(string letter)
        {
            if (guessedLetters.Contains(letter))
            {
                Console.WriteLine("You already guessed that letter!");
            }
            else { guessedLetters += letter; }
        }

        static void GUI(string word)
        {
            //If letter is in position in a loop of char in words,
            //then write the letter otherwise write underscore
            Console.WriteLine($"\nLives Left: {livesLeft}\nGuessed Letters: {guessedLetters}\n");
            foreach (char letter in word)
            {
                if (guessedLetters.Contains(letter)) Console.Write(letter + " ");
                else Console.Write("_ ");
            }
        }

        static string RandomWord()
        {
            string[] words = { "Kaffekrus", "Elefant", "Skygge", "Blyant", "Vindmølle", "Chokolade", "Regnbue", "Skjorte", "Telefon", "Bjergtop", "Fuglesang", "Lommelygte", "Havbølge", "Stjerneskud", };

            //return words[new Random().Next(words.Length)]; ;

            Random rnd = new Random();
            int num = rnd.Next(words.Length);
            string word = words[num];
            return word.ToUpper();
        }
    }
}