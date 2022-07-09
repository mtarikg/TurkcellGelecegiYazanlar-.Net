using System;
using System.Threading;

namespace hw1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to our game!!!!");
            Console.WriteLine("Let's see whether you are the chosen one for... You will find out at the end.");

            Console.WriteLine("Please enter your identity number:");
            string identityNumber = Console.ReadLine();

            // To check if the player is unlucky. If yes, the player needs to learn the bitter truth.
            if (identityNumber.IndexOf("13") != -1)
            {
                Console.WriteLine("You are the chosen one, maybe?");

                Console.WriteLine("Now enter your full name (Use a comma to separate and uppercase for initials):");
                string fullName = Console.ReadLine();
                string lowercaseFullName = fullName.ToLower();

                // The player's full name must somehow be related to the initials of "the chosen one".
                if (lowercaseFullName.Contains("tco") || lowercaseFullName.Contains("t.co") || lowercaseFullName.Contains("tc.o"))
                {
                    Console.WriteLine("Wow...");

                    string[] splittedFullName = null;
                    bool hasInitial = false;

                    for (int i = 1; i < fullName.Length; i++)
                    {
                        if (Char.IsUpper(fullName[i]))
                        {
                            hasInitial = true;
                            splittedFullName = fullName.Split(".");
                            break;
                        }
                    }

                    if (!hasInitial)
                    {
                        Console.WriteLine("You didn't type any parts of your name in uppercase. " +
                            "You don't deserve to be the chosen one in the first place.");
                    }
                    else
                    {
                        // Only if the player's surname meets the condition, will the player be able to learn the mission.
                        if (splittedFullName[splittedFullName.Length - 1].Contains("tco") ||
                            splittedFullName[splittedFullName.Length - 1].Contains("Tco"))
                        {
                            Console.WriteLine("Congratulations!!!");
                            Console.WriteLine("Get ready to learn your mission!");
                            Console.WriteLine("You are the chosen one for...");

                            int milliseconds = 3000;
                            Thread.Sleep(milliseconds);

                            Console.WriteLine("Nothing.");
                        }
                        else
                        {
                            Console.WriteLine("You were so close to being the chosen one officially... " +
                                "But apparently it was just pure luck. " +
                                "Good luck for the rest of your life.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Sometimes we tend to label ourselves as the chosen one... But you're not. Bring yourself back to reality.");
                }
            }
            else
            {
                Console.WriteLine("Do not ever think about it.");
            }
        }
    }
}
