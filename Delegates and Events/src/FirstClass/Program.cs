internal class Program {
	private static void Main(string[] args) {
		int[] values = [1, 2, 3, -4, 5, -6, -7, 8, 9, 10,];
		Console.WriteLine(string.Join(",", Find(values, IsPositive)));
		Console.WriteLine(string.Join(",", Find(values, v => v < 0)));

		Console.WriteLine(string.Join(",", Find(values, v => v >= 1 && v <= 5)));
		Console.WriteLine(string.Join(",", Find(values, v => v is >= 1 and <= 5)));
		Console.WriteLine(string.Join(",", Find(["hello", "goodbye"], s => s.Length > 5)));
	}


	public static bool IsPositive(int v) => v > 0;

	// CHALLENGE:
	// Write a function that returns all the even integers in a sequence.
	public static IEnumerable<int> FindEvens(IEnumerable<int> numbers) {
		List<int> result = [];

		// Write your code here.
		foreach (int number in numbers) {
			if (number % 2 == 0) {
				result.Add(number);
			}
		}
		return result;
    }

	public static IEnumerable<int> FindOdds(IEnumerable<int> numbers) {
		List<int> result = [];

		// Write your code here.
		foreach (int number in numbers) {
			if (number % 2 != 0) {
				result.Add(number);
			}
		}
		return result;
	}

	public static IEnumerable<int> FindNegatives(IEnumerable<int> numbers) {
		List<int> result = [];

		// Write your code here.
		foreach (int number in numbers) {
			if (number < 0) {
				result.Add(number);
			}
		}

		return result;
	}


	public static IEnumerable<TData> Find<TData>(IEnumerable<TData> data, Func<TData, bool> predicate) {
		List<TData> result = [];

		foreach (TData v in data) {
			if (predicate(v)) {
				result.Add(v);
			}
		}

		return result;
	}

}