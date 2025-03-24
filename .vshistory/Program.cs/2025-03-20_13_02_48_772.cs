using System.Text.RegularExpressions;

namespace Assignment_4
{
    internal class Program
    {
        /*
* Programming 2 - Assignment X – Winter 2025
* Created by:      Aidin yaseri 2467917
* Tested by:       TESTER NAME
* Relationship:    colleague/father/mother/etc
* Date:            TODAY'S DATE
*
* Description: The goal of this program is to do the * following… 
*/
        struct playerInformation
        {
            public string playerName;
            public int playerScore;
            public DateTime endingTime;
            public string sport;
            public int playerAge;
        }
        static void Main(string[] args)
        {
            bool changesSaved = false;
            string filename;
            List<playerInformation> players = new List<playerInformation>();
            PrintHeaderAndMenu();
            int userChoice = ValideInput(1);
            switch (userChoice)
            {
                case 1:
                    AddWinner(players);
                    break;

                case 2:
                    break;

                case 3:
                    break;

                case 4:
                    break;

                case 5:
                    break;

                case 6:
                    break;
                    


            }
        static void PrintHeaderAndMenu()
        {
            Console.WriteLine("      ************************************");
            Console.WriteLine("Welcome to Programming 2 - Assignment 4 – Winter 2025");
            Console.WriteLine("Created by Aidin Yaseri (2467917) on 2025-03-19");
            Console.WriteLine("      ************************************");
            Console.WriteLine();
            Console.WriteLine("Select one of the options below:");
            Console.WriteLine();
            Console.WriteLine("1. Add a winner to the leaderboard");
            Console.WriteLine("2. Delete an entry from the leaderboard");
            Console.WriteLine("3. Save the leaderboard to a file");
            Console.WriteLine("4. Load the leaderboard from a file");
            Console.WriteLine("5. Clear the leaderboard");
            Console.WriteLine("6. Quit");
            }
        }

        static int ValideInput(int minValue)
        {
            int userInput;
            while (!int.TryParse(Console.ReadLine(), out userInput) || userInput < minValue)
            {
                Console.WriteLine("Please input");
            }
            return userInput;
        }
        static string ValideInput()
        {
            string userInput;
            do
            {
                userInput = Console.ReadLine();
                if (Regex.IsMatch(userInput, @"\d"))
                {
                    Console.WriteLine($"Please enter no numbers");
                }
            } while (Regex.IsMatch(userInput, @"\d"));
            return userInput;
        }
       

        static void AddWinner(List<playerInformation> players)
        {
            int minScore = 0;
            int minAge = 0;
            playerInformation newWinner = new playerInformation();

            Console.WriteLine("**Add Player**");
            Console.WriteLine("Enter the name of the winner:");
            newWinner.playerName = ValideInput();
            Console.WriteLine("Enter the age of the winner");
            newWinner.playerAge = ValideInput(minAge);
            Console.WriteLine("Enter the score of the winner");
            newWinner.playerScore = ValideInput(minScore);
            Console.WriteLine("Enter the time ending of the winner");
            newWinner.endingTime = DateTime.Parse(ValideInput());
            Console.WriteLine("Enter the sport of the winner");
            newWinner.sport = ValideInput();
            foreach(playerInformation winner in players)
            {
                if (newWinner.playerName == winner.playerName)
                {
                   if(newWinner.playerScore > winner.playerScore)
                    {
                        int newWinnerIndex = 0;
                        players.Remove(winner);
                        for (int index = 0; index < players.Count; index++)
                        {
                            if (players[index].playerScore <newWinner.playerScore)
                            {
                             newWinnerIndex = index;
                            }
                        }
                        players.i
                    }
                }
            }
            players.Add(newWinner);
           


        }

        
        


}
}
