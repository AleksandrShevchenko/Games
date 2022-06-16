namespace ConsoleApp3
{
    public class GuessingGame : Game
    {
        public void PlayGame(int expectedNumber = 50)
        {
            var userNumber = GetNumberInput();
            CheckNumber(userNumber, expectedNumber);
        }

        private int GetNumberInput()
        {
            Console.WriteLine("Enter the number");
            try
            {
                return int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Not a number");
                return GetNumberInput();
            }
        }

        private void CheckNumber(int number, int expectedNumber)
        {
            if (number < 0 || number > expectedNumber)
            {
                Console.WriteLine("Number outside of boundaries");
                PlayGame(expectedNumber);
            }

            var randomNumber = new Random().Next(0, expectedNumber);
            if (number == randomNumber)
            {
                Console.WriteLine("Bullseye");
                if (IsPlayAgain())
                    PlayGame();
                Console.Clear();
            }
            else
            {
                var status = number > randomNumber ? "smaller" : "bigger";
                Console.WriteLine($"My number is {status}");
                int userNumber = GetNumberInput();
                CheckNumber(userNumber, number);
            }
        }
    }
}