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
			string secretWord = "GODFATHER";
			string maskedWord = new String('-', secretWord.Length);

			while(true)
			{
				Console.Clear();
				Console.WriteLine("\n"+MaskedSecretWord(secretWord, guesses));
				Console.WriteLine("\n"+guesses);
				Console.WriteLine("Guesses left: "+ guessesLeft);
				Console.Write("Your guess: ");
				string input = Console.ReadLine();

				if (guesses.Contains(input.ToUpper()))
				{
					Console.WriteLine("\nYou have allready guessed " + input.ToUpper());
					continue;
				}


				if (guessesLeft == 1)
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
						guesses += input.ToUpper() + "  ";

					}
					else
					{
						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine("Wrong");
						Console.ResetColor();
						//guesses += input.ToUpper() + "  ";
						guessesLeft--;
					}
				}
				else 
				{ 
					Console.WriteLine("Invalid guess");
					guessesLeft--;
				}
			}
		}

		private static string MaskedSecretWord(string secretWord, string guesses)
		{
			string validate = "";
			char[] guessesLetters = guesses.ToCharArray(); ;
			char[] secretLetters = secretWord.ToCharArray();

			foreach (var letter in secretLetters)
			{

				if (LetterExistInSecretword(letter, guessesLetters))
					validate += letter;
				else
					validate += '-';
			}
			return validate;
		}

		private static bool LetterExistInSecretword(char letter, char[] guessesLetters)
		{
			foreach(var guessLetter in guessesLetters)
			{
				if (guessLetter == letter)
					return true;
			}
			return false;
		}

		static bool IsValid(string input) => Regex.IsMatch(input, @"^[A-ZÆØÅ]$");

		//TEST//
		static void ToColors(string input)
		{
			//string s = "";
			Random random = new Random();
			char[] c = input.ToCharArray();
			foreach (var letter in c)
			{
				int rand = random.Next(1, 16);
				ConsoleColor clr = (ConsoleColor)rand;
				Console.ForegroundColor = clr;
				Console.Write(letter);
				Console.ResetColor();
			}
			Console.WriteLine("\n");
		}
	}
}
