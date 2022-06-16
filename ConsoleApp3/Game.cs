namespace ConsoleApp3
{
    public class Game
    {
        public void PlayGame()
        {

        }

        protected bool IsPlayAgain()
        {
            Console.WriteLine("Do you want to play again?");
            var userAnswer = Console.ReadLine();
            switch (userAnswer.ToLower())
            {
                case "yes":
                    return true;
                case "no":
                    return false;
                default:
                    Console.WriteLine("Enter only \"Yes\" or \"No\"");
                    return IsPlayAgain();
            }
        }

        public void ChooseTheGame()
        {
            Console.WriteLine("Choose the game:" +
                            "\n1.GuessingGame" +
                            "\n2.HangmanGame");
            var userChoice = Console.ReadLine();
            if (userChoice.Contains('1') || userChoice == "GuessingGame")
                new GuessingGame().PlayGame();
            else if (userChoice.Contains('2') || userChoice == "HangmanGame")
                new HangmanGame().PlayGame();
        }
    }
}
