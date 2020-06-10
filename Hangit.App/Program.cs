using System;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace Hangit.App
{
	class Program
	{
		static void Main(string[] args)
		{
			int guessesLeft = 10;
			string guesses = "";
			while(true)
			{
				string secretWord = "GODFATHER";

				Console.WriteLine("\n"+guesses);
				Console.WriteLine("Guesses left: "+ guessesLeft);

				Console.Write("Your guess: ");
				string input = Console.ReadLine();

				if(guessesLeft == 1)
				{
					Console.WriteLine("Game Over");
					break;
				}

				if (IsValid(input.ToUpper()))
				{
					if (secretWord.Contains(input.ToUpper()))
					{
						Console.ForegroundColor = ConsoleColor.Green;
						Console.WriteLine("Correct");
						Console.ResetColor();
					}
					else
					{
						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine("Wrong");
						Console.ResetColor();
						guessesLeft--;
					}
				}
				else 
				{ 
					Console.WriteLine("Invalid guess");
					guessesLeft--;
				}

				if (!guesses.Contains(input.ToUpper()))
				{
					guesses += input.ToUpper() + "  ";
				}

				//Console.WriteLine("GAme OvEr!");
			}
		}
		static bool IsValid(string input) => Regex.IsMatch(input, @"^[A-ZÆØÅ]$");
		/*
		static string ToColors(string input)
		{
			Random random = new Random();
			random.Next(0, 16);
			//char[] c = input.ToCharArray();
			int p = Enum.Parse(ConsoleColor, "Red");
			//foreach (var letter in c)
			//{
				//random.Next(0, 16);
				//Console.
			//}
		}*/
	}
}
