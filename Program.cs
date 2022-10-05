namespace DiceRollerJT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool start = true;
            while (start)
            {

                //prompt user to enter the number of sides for a pair of dice
                //use exception handling to ensure input accepts only numbers
                //prompt user to roll dice (app will roll x2 dice and display the result)
                //static method will generate random #s

                //(?) for six sided dice, display result combos
                //use static method string and loops for different combos?

                //ask user if they would like to roll the dice again (returns to roll dice again, not the start, will require another while loop?)

                start = restart(); //prompt to restart or quit
                Console.WriteLine();
            }

        }

        public static bool restart()
        {
            Console.WriteLine("Do you want to restart? Y/N");
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