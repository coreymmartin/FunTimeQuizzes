using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace FunTimeQuizzes
{
    public class Program
    {
        static int AskForInt(string msg = "please enter an integer", int lowerLimit = 0, int upperLimit = 1000) 
        {
            bool gotInt = false;
            bool intGood = false;
            int userInt = 0;
            do 
            {
                Console.Clear();
                Console.WriteLine(msg);
                gotInt = int.TryParse(Console.ReadLine(), out userInt);
                if (gotInt && lowerLimit <= userInt && userInt <= upperLimit)
                    intGood = true;
            } while (!intGood);
            return userInt;
        }

        static void Main(string[] args) {
            int userInput;
            bool runMain = true;
            Quiz funtime = new Quiz();
            Console.WriteLine("welcome to fun time quizzes!");
            Thread.Sleep(500);
            do
            {
                userInput = AskForInt($"hey there, please enter an option... \n0: to begin quiz\n1: to redeem yourself ({funtime.GetNumFailedQuestions()} redemptions available)\n2: to edit configuration\n3: to be a quitter", 0, 3);
                if (userInput == 0)
                {
                    Console.WriteLine("beginning fun time quiz!");
                    funtime.Run();
                }
                else if (userInput == 1)
                {
                    if (funtime.GetNumFailedQuestions() > 0)
                        funtime.RedeemYourself();
                    else
                    {
                        Console.WriteLine("you have nothing to be ashamed of...");
                        Thread.Sleep(500);
                    }
                }
                else if (userInput == 2)
                {
                    Console.WriteLine("FunTimeQuizzesConfiguration");
                    funtime.UpdateConfiguration();
                }
                else
                {
                    funtime.DisplayStats();
                    Console.WriteLine("see you later...\n");
                    runMain = false;
                }
            } while (runMain); }
    }
}
