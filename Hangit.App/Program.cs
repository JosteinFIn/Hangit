using System;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace Hangit.App
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.Write("Your guess: ");
			string input = Console.ReadLine();

			if (IsValid(input.ToUpper())){ Console.WriteLine("You guessed: " + input); }
			else { Console.WriteLine("Invalid guess"); }

			Console.WriteLine("GAme OvEr!");

		}
		static bool IsValid(string input) => Regex.IsMatch(input, @"^[A-ZÆØÅ]$");
	}
}
