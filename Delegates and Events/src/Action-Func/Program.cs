using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Action_Func {
	/* A "delegate" gives a name to a particular "type" of function.
	 * The delegate statement declares a new type you can use; variables of the delegate type
	 * can be assigned *FUNCTIONS* that match the delegate's requirements.
	 */
	public delegate void PrintAnIntFunction(int param);
	// This delegate type is named "PrintAnIntFunction". Any variable declared of this type
	// can be assigned to any function that takes an integer parameter and has no return value.

	public class Program {
		// This function takes an integer parameter and has no return value.
		public static void PrintInt(int p) {
			Console.WriteLine(p);
		}

		public static void DoNothing(int p) {

		}

		public static void Main(string[] args) {
			// Declare variable p equal to the PrintInt function.
			PrintAnIntFunction p = PrintInt;

			// The most important thing we can do with a delegate variable is call the function
			// it points to.
			p(10);

			/* Giving a new name to every pattern of function in every context you might need one
			 * is very tedious. C# 3.5 introduced the Action<T> and Func<T> delegate types.
			 * 
			 * Action<T> is a pointer to a void function taking a parameter of type T.
			 * Action<T1, T2, ...Tn> is a void function taking params of types T1, T2, etc.
			 * 
			 * Func<T, TResult> is a function taking a param of type T, returning a value
			 *			of type TResult. 
			 *	Func<T1, T2, ..., TResult> likewise.
			 */
			Action<int> p2 = PrintInt;
			p2(100);

			// Why is that helpful?




			// So now we can do:
			Func<int, int, double> f = NthPower;
			Console.WriteLine($"{f(5, 3)}"); // what is the output?


			Console.WriteLine("Choose an option:");
			Console.WriteLine("1) Pow\n2) Root\n3) Product");
			int choice = int.Parse(Console.ReadLine());
			f = choice switch {
				1 => NthPower,
				2 => NthRoot,
				_ => Product
			};
			Console.WriteLine($"{f(5, 3)}"); // what is the output?
		}

		public static double NthPower(int first, int second) {
			return Math.Pow(first, second);
		}

		public static double NthRoot(int first, int second) {
			return Math.Pow(first, 1.0 / second);
		}

		public static double Product(int first, int second) {
			return first * second;
		}

	}
}
