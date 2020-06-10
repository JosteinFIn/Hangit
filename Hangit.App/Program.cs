using System;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace Hangit.App
{
	class Program
	{
		static void Main(string[] args)
		{
			int guessesLeft = 10;
			while(true)
			{
				guessesLeft--;
				string secretWord = "GODFATHER";

				Console.Write("Your guess: ");
				string input = Console.ReadLine();

				if (IsValid(input.ToUpper()))
				{
					if (secretWord.Contains(input.ToUpper()))
						Console.WriteLine("Correct"); 
					else 
						Console.WriteLine("Wrong");
				}
				else { Console.WriteLine("Invalid guess"); }

				Console.WriteLine("Guesses left: "+ guessesLeft);

				//Console.WriteLine("GAme OvEr!");
			}
		}
		static bool IsValid(string input) => Regex.IsMatch(input, @"^[A-ZÆØÅ]$");
	}
}
