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
			Console.Title = "Hangman game";
			int guessesLeft = 10;
			string guesses = "";
			string secretWord = "GODFATHER";
			//string maskedWord = new String('-', secretWord.Length);

			while (true)
			{
				Console.Clear();
				InfoLine("\n" + MaskedSecretWord2(secretWord, guesses));
				InfoLine("\n" + guesses);
				InfoLine("Guesses left: " + guessesLeft);
				InfoLine("Your guess: ");
				string input = Console.ReadLine();


				if (guesses.Contains(input.ToUpper()))
				{
					InfoLine("\nYou have allready guessed " + input.ToUpper());
					Console.ReadKey();
					continue;
				}

				if (guessesLeft == 1)
				{
					ErrorLine("Game Over");
					break;
				}

				if (IsValid(input.ToUpper()))
				{
					if (secretWord.Contains(input.ToUpper()))
					{
						SuccessLine("CORRECT!");
						guesses += input.ToUpper() + "  ";

					}
					else
					{
						ErrorLine("WRONG");
						guesses += input.ToUpper() + "  ";
						guessesLeft--;
					}
				}
				else
				{
					InfoLine("Invalid guess");
				}
				if (AllLettersGuessCorrect(secretWord, guesses))
				{
					ToColors("-*-*-*-*-*-*-*-*-*-*-YOU WIN!-*-*-*-*-*-*-**-");
					Console.ReadKey();
					//break;
				}
				Console.ReadKey();
			}
		}
		private static bool AllLettersGuessCorrect(string secretWord, string guesses)
		{
			return MaskedSecretWord2(secretWord, guesses) == secretWord;
		}

		private static void InfoLine(string message)
		{
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine(message);
		}

		private static void SuccessLine(string message)
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine(message);
		}

		private static void ErrorLine(string message)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine(message);
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
		private static string MaskedSecretWord2(string secretWord, string guesses)
		{
			string validate = "";
			foreach (char letter in secretWord)
			{
				if (guesses.Contains(letter))
					validate += letter;
				else
					validate += '-';
			}
			return validate;
		}

		private static bool LetterExistInSecretword(char letter, char[] guessesLetters)
		{
			foreach (var guessLetter in guessesLetters)
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
