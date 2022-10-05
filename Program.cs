namespace DiceRollerJT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int index = -1;
            int userDiceNum;
            int dice1;
            int dice2;

            bool start = true;
            while (start)
            {
                try //use exception handling to ensure input accepts only numbers
                {
                    Console.WriteLine("Enter the number of sides for a pair of dice."); //prompt user to enter the number of sides for a pair of dice
                    userDiceNum = int.Parse(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Your input was not a valid, please enter a positive number");
                    Console.WriteLine();
                    continue;
                }
                Console.WriteLine();

                bool rollDiceAgain = true;
                while (rollDiceAgain == true)
                {
                    if (userDiceNum == 6) //if user selects six-sided die
                    {
                        Console.WriteLine("Rolling x2 dice with {0} sides ...", +userDiceNum);

                        Random rnd = new Random(); //static method will generate random #s
                        dice1 = rnd.Next(1, 7);
                        dice2 = rnd.Next(1, 7);

                        Console.WriteLine("{0}, {1}", dice1, dice2); //print results of two dice rolls.
                        Console.WriteLine();

                        Console.WriteLine("Checking for dice result combinations...");

                        Console.WriteLine(diceCombos(dice1, dice2)); //run method to find dice combinations
                        Console.WriteLine(diceCombosSums(dice1, dice2));

                        if (diceCombos(dice1, dice2) == null && diceCombosSums(dice1,dice2) == null)
                        {
                            Console.WriteLine("No combos found.");
                        }
                        Console.WriteLine();

                        break;
                    }
                    else if (userDiceNum < 3)
                    {
                        Console.WriteLine("There are not enough sides, please try again.");
                        Console.WriteLine();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Rolling x2 dice with {0} sides ...", +userDiceNum);
                        Random rnd = new Random();
                        for (int i = 0; (i < userDiceNum); i++)
                        {
                            Console.WriteLine(rnd.Next(1, 7));
                        }
                        Console.WriteLine();
                        break;
                    }

                }

                start = restart(); //prompt to restart or quit
                Console.WriteLine();
            }

        }

        public static string diceCombos(int num1, int num2)
        {
            int sum = num1 + num2;
           
            if (num1 == 1 && num2 == 1)
            {
               return "Snake Eyes";
            }
            else if (num1 == 1 && num2 == 2 || num1 == 2 && num2 == 1)
            {
                return "Ace Deuce";
            }
            else if (num1 == 6 && num2 == 6)
            {
                return "Box Cars";
            }
            else
            {
                return null;
            }
        }

        public static string diceCombosSums(int num1, int num2)
        {
            int sum = num1 + num2;

            if (sum == 2)
            {
                return "Craps: win if you bet on the 'Don't Pass' line, lose if you bet on 'Pass' line";
            }
            else if (sum == 7 || sum == 11)
            {
                return "Win";
            }
            else if (sum == 12)
            {
                return "Craps: tie if you bet on the 'Don't Pass' line, lose if you bet on 'Pass' line";
            }
            else
            {
                return null;
            }
        }

        public static bool restart()
        {
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Do you want to roll another pair of dice? Y/N");
            string input = Console.ReadLine().ToLower();

            if (input == "y")
            {
                return true;
            }
            else if (input == "n")
            {
                return false;
            }
            else //if user input is not "y" or "n"
            {
                Console.WriteLine("I'm sorry, I'm afraid I can't do that, invalid input. Please try again.");
                return restart();
            }
        }
    }
}
