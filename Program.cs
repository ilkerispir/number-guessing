using System;

namespace number_guessing
{
    class Program
    {
        /*
            Function                       : Main()
            Author                         : Ilker Ispir
            Description                    : Number Guessing
            Date Created                   : 11.08.2020
            Modifications                  : - 
        */
        static void Main()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Welcome to the Number Guessing Game.");
            Console.Write("Please, Enter the Number of Players: ");
            int numberOfPlayers = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            string[] nameOfPlayers = new string[numberOfPlayers];
            int[] pointsOfPlayers = new int[numberOfPlayers];


            #region InputName&Points
            for (int i = 0; i < numberOfPlayers; i++)
            {
                Console.Write($"{i + 1}. enter the name of the player: ");
                nameOfPlayers[i] = Console.ReadLine();
                Console.Clear();

                Console.WriteLine("Zorluk Seviyesi");
                Console.WriteLine("1- Easy (0-10 Numbers) 3 Guessing Rights");
                Console.WriteLine("2- Medium (0-20 Numbers) 5 Guessing Rights");
                Console.WriteLine("3- Difficult (0-30 Numbers) 7 Guessing Rights");
                Console.Write($"{nameOfPlayers[i]} Named Player's Choice: ");         
                string selection = Console.ReadLine();
                Console.Clear();
                int point = 0;
                Random rnd = new Random();

                if (selection == "1")
                {
                    int randomNumber1 = rnd.Next(1, 11);

                    for (int j = 0; j < 10; j++)
                    {
                        Console.WriteLine($"{nameOfPlayers[i]} Enter a number between [1-10].");
                        Console.Write($"{10 - j} you have the right. Guess: ");
                        int guess = Convert.ToInt32(Console.ReadLine());
                        
                        if (guess < randomNumber1)
                        {
                            Console.WriteLine("Increase the number.");
                        }
                        else if (guess > randomNumber1)
                        {
                            Console.WriteLine("Lower the number.");
                        }

                        if (guess == randomNumber1)
                        {
                            Console.WriteLine($"Your prediction is successful {nameOfPlayers[i]}");
                            point = 100 / (j + 1);
                            pointsOfPlayers[i] = point;
                            Console.WriteLine($"Your Score: {pointsOfPlayers[i]}");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Wrong guess");
                        }
                    }
                }

                else if (selection == "2")
                {
                    int randomNumber2 = rnd.Next(1, 21);

                    for (int j = 0; j < 15; j++)
                    {
                        Console.WriteLine($"{nameOfPlayers[i]} Enter a number between [1-20].");
                        Console.Write($"{15 - j} you have the right. Guess:");
                        int guess = Convert.ToInt32(Console.ReadLine());

                        if (guess < randomNumber2)
                        {
                            Console.WriteLine("Increase the number.");
                        }
                        else if (guess > randomNumber2)
                        {
                            Console.WriteLine("Lower the number.");
                        }

                        if (guess == randomNumber2)
                        {
                            Console.WriteLine($"Your prediction is successful {nameOfPlayers[i]}");
                            point = 150 / (j + 1);
                            pointsOfPlayers[i] = point;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Wrong guess");
                        }
                    }
                }

                else if (selection == "3")
                {
                    int randomNumber3 = rnd.Next(1, 31);

                    for (int j = 0; j < 20; j++)
                    {
                        Console.WriteLine($"{nameOfPlayers[i]} Enter a number between [1-30].");
                        Console.Write($"{20 - j} you have the right. Guess: ");
                        int guess = Convert.ToInt32(Console.ReadLine());

                        if (guess == randomNumber3)
                        {
                            Console.WriteLine($"Your prediction is successful {nameOfPlayers[i]}");
                            point = 200 / (j + 1);
                            pointsOfPlayers[i] = point;
                            break;
                        }
                        else if (guess < randomNumber3)
                        {
                            Console.WriteLine("Increase the number.");
                        }
                        else if (guess > randomNumber3)
                        {
                            Console.WriteLine("Lower the number.");
                        }                        
                    }
                }

                Console.Write("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            } 
            #endregion

            #region Sorting
            for (int i = (numberOfPlayers - 1); i >= 0; i--)
            {
                for (int j = 1; j <= i; j++)
                {
                    if (pointsOfPlayers[j - 1] > pointsOfPlayers[j])
                    {
                        int iTemp = pointsOfPlayers[j - 1];
                        string sTemp = nameOfPlayers[j - 1];

                        pointsOfPlayers[j - 1] = pointsOfPlayers[j];
                        nameOfPlayers[j - 1] = nameOfPlayers[j];

                        pointsOfPlayers[j] = iTemp;
                        nameOfPlayers[j] = sTemp;
                    }
                }
            }
            #endregion

            #region ScoreBoard
            Console.Write("Press any button to view the scoreboard...");
            Console.ReadKey();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            int ranking = 1;
            for (int i = (numberOfPlayers - 1); i >= 0; i--)
            {
                Console.WriteLine("Scorboard");
                Console.WriteLine($"{ranking}. {nameOfPlayers[i]} - Point: {pointsOfPlayers[i]}");
                ranking++;
            }
            #endregion

            #region AgainGame
            Console.Write("Press [y] to play again, or a key to exit:");
            string again = Console.ReadLine();
            if (again == "y")
            {
                Console.Clear();
                Main();
            } 
            #endregion
        }
    }
}