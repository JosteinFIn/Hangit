using System;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace Hangit.App
{
	class Program
	{
		static void Main(string[] args)
		{
			while(true)
			{
				string secretWord = "GODFATHER";

				Console.Write("Your guess: ");
				string input = Console.ReadLine();
				
				if (IsValid(input.ToUpper()) && secretWord.Contains(input.ToUpper()))
				{ 
					Console.WriteLine("Correct"); 
				}
				else if (IsValid(input.ToUpper()) && !secretWord.Contains(input))
				{
					Console.WriteLine("Wrong");
				}
				else { Console.WriteLine("Invalid guess"); }

				//Console.WriteLine("GAme OvEr!");
			}
		}
		static bool IsValid(string input) => Regex.IsMatch(input, @"^[A-ZÆØÅ]$");
	}
}
