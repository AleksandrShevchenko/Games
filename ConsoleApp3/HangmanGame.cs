namespace ConsoleApp3
{
    public class HangmanGame : Game
    {
        int lifes = 6;
        string word;
        char[] hiddenWord;

        List<string> words = new List<string>()
        {
        "Cat",
        "Dog",
        "Phone",
        "Table",
        "Station",
        "Driver",
        "Notebook",
        "Cactus"
        };

        new public void PlayGame()
        {
            InitializeWord();
            CheckTheWord();
            if (IsPlayAgain())
            {
                lifes = 6;
                PlayGame();
            }
        }

        private void InitializeWord()
        {
            word = words.ElementAt(new Random().Next(words.Count));
            hiddenWord = new char[word.Length];
            for (int i = 0; i < word.Length; i++)
                hiddenWord[i] = '_';
        }

        private void CheckTheWord()
        {
            UpdateDisplayedInfo();
            while (hiddenWord.Contains('_'))
            {
                CheckLetter();
                if (lifes == 0)
                {
                    Console.WriteLine("Game over");
                    break;
                }
                UpdateDisplayedInfo();
            }
            if (!hiddenWord.Contains('_'))
                Console.WriteLine("Congratulations!");
        }

        private void UpdateDisplayedInfo()
        {
            Console.Clear();
            Console.WriteLine(hiddenWord);
            Console.WriteLine($"Lifes: {lifes}");
        }

        private void CheckLetter()
        {
            char letter = GetTheLetter();
            if (word.ToLower().Contains(letter))
            {
                for (int i = 0; i < word.Length; i++)
                    if (char.ToLower(word[i]) == letter)
                        hiddenWord[i] = letter;
            }
            else
            {
                Console.WriteLine("\nNo such letter");
                lifes--;
            }
        }

        private char GetTheLetter()
        {
            Console.WriteLine("Enter a letter");
            var userInput = Console.ReadLine();
            if (userInput.Length == 1)
            {
                if (char.IsLetter(userInput[0]))
                    return userInput[0];
                else
                {
                    Console.WriteLine("Enter correct letter");
                    return GetTheLetter();
                }
            }

            else
            {
                Console.WriteLine("Enter correct single letter");
                return GetTheLetter();
            }
        }
    }
}
