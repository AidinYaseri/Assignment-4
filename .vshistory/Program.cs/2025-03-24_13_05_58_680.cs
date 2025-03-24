﻿using System;
using System.Globalization;
using System.Numerics;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Assignment_4
{
    internal class Program
    {
        /*
        * Programming 2 - Assignment 4 – Winter 2025
        * Created by:      Aidin yaseri 2467917
        * Tested by:       Makan homayoun
        * Relationship:    colleague
        * Date:            2025-03-24
        *
        * Description: The goal of this program is to do the * following… 
        */

        // Structure to store winners information
        struct playerInformation
        {
            public string playerName; // player's name (String)
            public int playerScore;   // player's score (integer)
            public DateTime endingTime;    // Date and time the player finished(DateTime)
            public string sport;    // Sport the player played(string)
            public int playerAge;   // Player's age (integer)
        }
        static void Main(string[] args)
        {
            List<playerInformation> winnerList = new List<playerInformation>(); // A List to store playerInformation structs
            winnerList = AutoLoadLeaderBoard(); //  Loads leaderboard data from a file
            bool quitProgram = false; //   boolean to control the main program loop

            //Continues until the user chooses to quit.
            do
            {
                PrintHeaderAndMenu();  // Displays the program header and menu options.
                int userChoice = ValideInput(1); // Gets and validates user's menu choice

                // Switch case to handle user's menu choice
                switch (userChoice)
                {
                    case 1:
                        AddWinner(winnerList); // Adds a new winner to the leaderboard
                        break;

                    case 2:
                        DeleteWinner(winnerList); //  Removes a winner from the leaderboard
                        break;

                    case 3:
                        SavingLeaderBoard(winnerList); // Saves the leaderboard to a file
                        break;

                    case 4:
                        LoadingLeaderBoard(winnerList); //  Loads the leaderboard from a file
                        break;

                    case 5:
                        ClearLeaderBoard(winnerList);// Clears all entries from the leaderboard
                        break;

                    case 6:
                        Quit(winnerList); //  Handles quitting the program and autosave
                        quitProgram = true; //  Sets the flag to exit the loop
                        break;
                }

            } while (!quitProgram);
            Console.ReadKey();// Keeps the console window open until a key is pressed   
        }

        // PrintHeaderAndMenu function: Displays the program's title and menu options to the user
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

        // ValideInput function: Gets and validates integer input from the user
        static int ValideInput(int minValue)
        {
            // Loops until valid integer input is provided
            int userInput;
            while (!int.TryParse(Console.ReadLine(), out userInput) || userInput < minValue)
            {
                Console.WriteLine("Please input a positive number");
            }
            return userInput;
        }

        // ValideInput function: Gets and validates string input from the user
        static string ValideInput()
        {
            string userInput;
            // Loops until valid string input is provided
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

        // ValideInput function: Gets and validates DateTime input from the user
        static DateTime ValideInput(string format)
        {
            DateTime userInput;
            bool isValid = false;
            // Loops until valid DateTime input is provided
            do
            {

                string input = Console.ReadLine();
                if (DateTime.TryParse(input, out userInput))
                {
                    isValid = true;
                }
                else
                {
                    Console.WriteLine($"Invalid format. Please use the format: {format}");
                }
            } while (!isValid);
            return userInput;

        }

        // AddWinner function: Collects Winner's information and adds a new winner to the leaderboard
        static void AddWinner(List<playerInformation> winnerList)
        {
            int minScore = 0;
            int minAge = 0;
            playerInformation newWinner = new playerInformation();

            Console.WriteLine("**Add Player**");
            Console.WriteLine("Enter the name of the winner:");
            newWinner.playerName = ValideInput(); // Gets and validates player name
            Console.WriteLine("Enter the age of the winner");
            newWinner.playerAge = ValideInput(minAge); // Gets and validates player age
            Console.WriteLine("Enter the score of the winner");
            newWinner.playerScore = ValideInput(minScore); // Gets and validates player score
            Console.WriteLine("Enter the time ending of the winner [yyyy-MM-dd HH:mm:ss]");
            newWinner.endingTime = ValideInput("[yyyy-MM-dd HH:mm:ss]"); // Gets and validates the ending time
            Console.WriteLine("Enter the sport of the winner");
            newWinner.sport = ValideInput(); // Gets and validates the sport
            InsertWinner(winnerList, newWinner); // Inserts the new winner into the leaderboard list
            Console.WriteLine("Winner Successfully added");
            DisplayLeaderBoard(winnerList);// Displays the updated leaderboard
            Thread.Sleep(1000); // Pauses to show the message.
        }

        // InsertWinner function: Inserts a new winner into the correct position in the leaderboard based on their score
        static void InsertWinner(List<playerInformation> winnerList, playerInformation newWinner)
        {
            // Checks if a player with the same name already exists.  If so, it compares scores and either replaces the old score or rejects the new one
            for (int index = 0; index < winnerList.Count; index++)
            {
                if (winnerList[index].playerName == newWinner.playerName)
                {
                    if (newWinner.playerScore > winnerList[index].playerScore)
                    {
                        // Removes the old entry if the new score is higher
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
            // Finds the correct index to insert the new winner based on their score 
            int insertIndex = 0;
            while (insertIndex < winnerList.Count && winnerList[insertIndex].playerScore > newWinner.playerScore)
            {
                insertIndex++;
            }
            // Inserts the new winner at the determined index
            winnerList.Insert(insertIndex, newWinner);

        }

        // DeleteWinner function: Deletes a winner from the leaderboard based on the player's name
        static void DeleteWinner(List<playerInformation> winnerList)
        {
            Console.WriteLine("Please enter the name of the winner you wish to delete");
            string userInput = ValideInput();// Gets the name of the winner to delete
            int playerIndex;
            // Finds the winner with the given name through the leaderboard
            for (playerIndex = 0; playerIndex < winnerList.Count; playerIndex++)
            {
                if (userInput == winnerList[playerIndex].playerName)
                {
                    Console.WriteLine("Are you sure about this action? [y/n]");

                    // Prompts the user for confirmation before deleting
                    string confirmation;
                    do
                    {
                        confirmation = ValideInput().ToLower();
                        if (confirmation != "y" && confirmation != "n")
                        {
                            Console.WriteLine("Invalid input. Please enter [y/n]:");
                        }
                    } while (confirmation != "y" && confirmation != "n");
                    // If the user confirms, the player is removed from the leaderboard
                    if (confirmation == "y")
                    {
                        winnerList.RemoveAt(playerIndex);
                        Console.WriteLine("Winner seccessfully deleted!");
                        DisplayLeaderBoard(winnerList);
                        Thread.Sleep(1000);

                    }
                    else
                    {
                        Console.WriteLine("Winner deleting cancelled");
                        DisplayLeaderBoard(winnerList);
                        Thread.Sleep(1000);
                    }
                    return;

                }
            }
            Console.WriteLine("Winner has not been found");// Message if the player is not found
            Thread.Sleep(1000);
        }

        // SavingLeaderBoard function: Saves the leaderboard data to a CSV file
        static void SavingLeaderBoard(List<playerInformation> winnerList)
        {
            DisplayLeaderBoard(winnerList);// Displays the leaderboard before saving
            Console.WriteLine("please enter the file name you wish to save (do not include file extension)");
            string fileName = Console.ReadLine(); // Gets the filename from the user
            StreamWriter writer = null;
            try
            {
                writer = new StreamWriter($"../../../{fileName}.csv", true);

                if (winnerList.Count == 0)
                {
                    Console.WriteLine("The LeaderBoard is empty");
                    Thread.Sleep(1000);
                    return;
                }
                else
                {
                    foreach (playerInformation player in winnerList)
                    {
                        string formattedDate = player.endingTime.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                        writer.WriteLine($"{player.playerName},{player.playerScore},{player.playerAge}, {player.sport},{formattedDate},");
                    }
                }

                Console.WriteLine($"Leaderboard saved successfully to {fileName}!");
                Thread.Sleep(1000);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
                Thread.Sleep(1000);
            }
            finally
            {
                writer.Close();
            }
        }

        static void LoadingLeaderBoard(List<playerInformation> winnerList)
        {
            Console.WriteLine("Please enter the file name you wish to load (do not include file extension):");
            string fileName = Console.ReadLine();

            if (!File.Exists($"../../../{fileName}.csv"))
            {
                Console.WriteLine($"File path: ../../../{fileName}.csv");
                Console.WriteLine("File not found");
                Thread.Sleep(1000);
                return;
            }
            else
            {
                StreamReader reader = null;
                try
                {
                    reader = new StreamReader($"../../../{fileName}.csv", true);

                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        string[] parts = line.Split(',');


                        playerInformation newWinner;
                        newWinner.playerName = parts[0];
                        newWinner.playerScore = int.Parse(parts[1]);
                        newWinner.playerAge = int.Parse(parts[2]);
                        newWinner.sport = parts[3];
                        newWinner.endingTime = DateTime.Parse(parts[4]);

                        Console.WriteLine(newWinner);
                        winnerList.Add(newWinner);

                    }

                    Console.WriteLine($"Leaderboard loaded from {fileName}!");
                    Thread.Sleep(1000);
                    DisplayLeaderBoard(winnerList);
                    Thread.Sleep(1000);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error loading leaderboard: {ex.Message}");
                    Thread.Sleep(1000);
                }
                finally
                {
                    reader.Close();
                }
            }
        }

        static void DisplayLeaderBoard(List<playerInformation> winnerList)
        {
            if (winnerList.Count == 0)
            {
                Console.WriteLine("The LeaderBoard is empty");
                return;
            }
            else
            {
                Console.WriteLine("=====================================================================================");
                Console.WriteLine("| {0,-6} | {1,-10} | {2,-7} | {3,-5} | {4,-8} | {5,-22} |", "RANK", "NAME", "SCORE", "AGE", "SPORT", "ENDING TIME");
                Console.WriteLine("=====================================================================================");
                int rank = 1;
                foreach (playerInformation winner in winnerList)
                {
                    if (rank == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("| {0,-6} | {1,-10} | {2,-7} | {3,-5} | {4,-8} | {5,-20} |", rank, winner.playerName, winner.playerScore, winner.playerAge, winner.sport, winner.endingTime);
                        rank++;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {

                        Console.WriteLine("| {0,-6} | {1,-10} | {2,-7} | {3,-5} | {4,-8} | {5,-20} |", rank, winner.playerName, winner.playerScore, winner.playerAge, winner.sport, winner.endingTime);
                        rank++;

                    }

                }
                Console.WriteLine("=====================================================================================");
            }
        }
        static void ClearLeaderBoard(List<playerInformation> winnerList)
        {
            Console.WriteLine("Are you sure you want to clear the leaderboard? [y/n]");
            string input = ValideInput().ToLower();
            if (input == "y")
            {
                winnerList.Clear();
                Console.WriteLine("Leaderboard has been cleared successfully!");
                Thread.Sleep(1000);
                DisplayLeaderBoard(winnerList);
            }
            else
            {
                Console.WriteLine("Leaderboard clearing canceled.");
                Thread.Sleep(1000);
            }
        }
        static List<playerInformation> AutoLoadLeaderBoard()
        {
            string fileName = "leaderboard";
            if (!File.Exists($"../../../{fileName}.csv"))
            {
                Console.WriteLine("No previous leaderboard found. Starting fresh.");
                Thread.Sleep(1000);
                return new List<playerInformation>();
            }
            StreamReader reader = null;
            try
            {
                List<playerInformation> winnerList = new List<playerInformation>();

                reader = new StreamReader($"../../../{fileName}.csv", true);

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] parts = line.Split(',');

                    playerInformation newWinner;
                    newWinner.playerName = parts[0];
                    newWinner.playerScore = int.Parse(parts[1]);
                    newWinner.playerAge = int.Parse(parts[2]);
                    newWinner.sport = parts[3];
                    newWinner.endingTime = DateTime.Parse(parts[4]);
                    winnerList.Add(newWinner);



                }
                Console.WriteLine($"Leaderboard loaded from {fileName}!");
                Thread.Sleep(1000);
                return winnerList;
            }


            catch (Exception ex)
            {
                Console.WriteLine($"Error loading leaderboard: {ex.Message}");
                Thread.Sleep(1000);
                return new List<playerInformation>();
            }
            finally
            {
                reader.Close();

            }


        }
        static void AutoSaveLeaderBoard(List<playerInformation> winnerList)
        {
            string fileName = "leaderboard";
            StreamWriter writer = null;
            try
            {
                writer = new StreamWriter($"../../../{fileName}.csv", true);

                if (winnerList.Count == 0)
                {
                    Console.WriteLine("The LeaderBoard is empty");
                    Thread.Sleep(1000);
                    return;
                }
                else
                {
                    foreach (playerInformation player in winnerList)
                    {
                        string formattedDate = player.endingTime.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                        writer.WriteLine($"{player.playerName},{player.playerScore},{player.playerAge}, {player.sport},{formattedDate},");
                    }
                }

                Console.WriteLine($"Leaderboard saved successfully to {fileName}!");
                Thread.Sleep(1000);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving leaderboard: {ex.Message}");
                Thread.Sleep(1000);
            }
            finally
            {
                writer.Close();
            }
        }
        static void Quit(List<playerInformation> winnerList)
        {
            Console.WriteLine("Saving leaderboard before exiting");
            Thread.Sleep(1000);
            AutoSaveLeaderBoard(winnerList);

        }
    }
}