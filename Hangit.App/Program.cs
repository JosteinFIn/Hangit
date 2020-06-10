using System;
using System.Text.RegularExpressions;

namespace Hangit.App
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.Write("Your guess: ");
			string input = Console.ReadLine();

			Regex regex = new Regex(@"^[A-ZÆØÅ]$");

			if (regex.IsMatch(input.ToUpper())){ Console.WriteLine("You guessed: " + input); }
			else { Console.WriteLine("Invalid guess"); }

			Console.WriteLine("GAme OvEr!");
		}
	}
}
