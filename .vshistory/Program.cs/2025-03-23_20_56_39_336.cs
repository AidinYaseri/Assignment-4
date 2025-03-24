﻿using System.Text.RegularExpressions;

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
            List<playerInformation> winnerList = new List<playerInformation>();
            PrintHeaderAndMenu();
            int userChoice = ValideInput(1);
            switch (userChoice)
            {
                case 1:
                    AddWinner(winnerList);
                    break;

                case 2:
                    DeleteWinner(winnerList);
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


        static void AddWinner(List<playerInformation> winnerList)
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
            // fix bug
            newWinner.sport = ValideInput();
            InsertWinner(winnerList, newWinner);
        }







        static void InsertWinner(List<playerInformation> winnerList, playerInformation newWinner)
        {
            for (int index = 0; index < winnerList.Count; index++)
            {
                if (winnerList[index].playerName == newWinner.playerName)
                {
                    if (newWinner.playerScore > winnerList[index].playerScore)
                    {
                        winnerList.RemoveAt(index);
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"{newWinner.playerName}'s old score is greater then the new score, the old score will be kept ");
                        return;
                    }
                }
            }
            int insertIndex = 0;
            while (insertIndex < winnerList.Count && winnerList[insertIndex].playerScore > newWinner.playerScore)
            {
                insertIndex++;
            }
            winnerList.Insert(insertIndex, newWinner);

        }
        static void DeleteWinner(List<playerInformation> winnerList, playerInformation newWinner)
        {
            Console.WriteLine("Please enter the name of the winner you wish to delete");
            string userInput = ValideInput();
            int playerIndex;
            for (playerIndex = 0; playerIndex < winnerList.Count; playerIndex++)
            {
                if (userInput == winnerList[playerIndex].playerName)
                {
                    Console.WriteLine("");
                    winnerList.RemoveAt(playerIndex);
                    Console.WriteLine("Winner seccessfully deleted!");
                    Thread.Sleep(1000);
                    return;
                }
            }
            Console.WriteLine("Winner has not been found");
        }
    }
}