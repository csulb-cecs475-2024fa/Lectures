using Cecs475.War;
namespace Cecs475.War.Test {
	public class WarTests {
		[Fact]
		public void TestBadShuffle() {
			Deck d = new Deck();
			d.ShuffleBadDesign();

			// How can we test d to see if it's correct?

		}

		[Fact]
		public void TestShuffle() {
			Random r = new Random(1);
			Deck d = new Deck();
			d.Shuffle(r);

		}
	}
}