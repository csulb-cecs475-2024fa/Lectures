internal class Program {
	private static void Main(string[] args) {
		int[] values = [1, 2, 3, -4, 5, -6, -7, 8, 9, 10,];
		Console.WriteLine(string.Join(",", FindEvens(values)));
	}

	// CHALLENGE:
	// Write a function that returns all the even integers in a sequence.
	public static IEnumerable<int> FindEvens(IEnumerable<int> numbers) {
		List<int> result = [];

		// Write your code here.

		return result;
    }

	public static IEnumerable<int> FindOdds(IEnumerable<int> numbers) {
		List<int> result = [];

		// Write your code here.

		return result;
	}

	public static IEnumerable<int> FindNegatives(IEnumerable<int> numbers) {
		List<int> result = [];

		// Write your code here.

		return result;
	}

	public static IEnumerable<int> Find(IEnumerable<int> numbers, Func<int, bool> predicate) {
		List<int> result = [];

		foreach (int v in numbers) {
			if (predicate(v)) {
				result.Add(v);
			}
		}

		return result;
	}


}