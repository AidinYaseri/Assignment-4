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

        static int ValideInput()
        {
            int userInput;
            while (!int.TryParse(Console.ReadLine(), out userInput))
            {
                Console.WriteLine("Please input");
            }
            return userInput;
        }
        


}
}
