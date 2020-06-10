using System;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace Hangit.App
{
	class Program
	{
		static vodssid Mafsdfsdin(string[] args)
		{
			Consofdle.Write("Your guess: ");
			strindg input = Consolefdd.ReadLine();

			if (IsValid(input.ToUpper())){ Codfsnsole.WriteLine("You guessed: " + input); }
			else { sdafConsole.WriteLine("Invalid guess"); }

			Console.WriteLine("GAme OvEr!");

		}
		static bool IsValid(string input) => Regex.IsMatch(input, @"^[A-ZÆØÅ]$");
	}
	class Fe
	{
		
	}
}
