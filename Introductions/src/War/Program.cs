/*
 * Lecture 2: Card game program. 
 * Lessons:
 *		Type basics
 *		Members: fields, properties, methods, events
 *		I/O
 *		Flow control
 *		Enums
 */


using System;

namespace Cecs475.War {
	public class Program {
		// The entry point for the application.
		public static void Main(string[] args) {
			// This class has access to any class in the same project, or in an assembly that has been referenced. (Later.)


			// Build a deck for player 1.
			Deck d1 = new Deck();

			// An "interpolated string" starts with a $. In the string, {}
			// surrounds an expression that will be evaluated and placed in the string
			// at run time.
			Console.WriteLine($"Player 1's deck (debug): {d1}");
			d1.Shuffle();
			Console.WriteLine();
			Console.WriteLine($"Player 1's deck shuffled: {d1}");

			Deck d2 = new Deck();
			d2.Shuffle();

			Console.WriteLine();
			Console.WriteLine("Let's play WAR!");
			while (d1.Count > 0) { // calls the Count property accessor
				// Deal one card from each deck, compare, and print result.
				Card c1 = d1.DealOne();
				Card c2 = d2.DealOne();

				int compare = c1.CompareTo(c2);
				string message = compare == 0 ? "Tie!" :
					compare < 0 ? "Player 2 wins!" :
					"Player 1 wins";

				Console.WriteLine($"{c1} vs. {c2} ... {message}");

				// Ask to go to next deal.
				string again;
				Console.WriteLine("Continue? y/n:");
				again = Console.ReadLine();
				if (again != "y") {
					break;
				}
				Console.WriteLine();
			}
		}
	}
}
