using System;

// This is the same class as our intoductory example.
namespace Cecs475.War.Model {
	public class Card : IComparable<Card> {
		public enum CardSuit {
			Spades, // 0
			Clubs,  // 1, etc.
			Diamonds,
			Hearts
		}

		public enum CardKind {
			Two = 2, // a value can be supplied explicitly, and other values will count up from there.
			Three,
			Four,
			Five,
			Six,
			Seven,
			Eight,
			Nine,
			Ten,
			Jack,
			Queen,
			King,
			Ace // == 14
		}


		public Card(CardKind kind, CardSuit suit) {
			Suit = suit;
			Kind = kind;
		}

		public CardSuit Suit { get; init; }

		public CardKind Kind { get; init; }

		public override string ToString() {
			int kindValue = (int)Kind;
			string r;
			if (kindValue >= 2 && kindValue <= 10) {
				r = kindValue.ToString();
			}
			else {
				r = Kind.ToString(); // ToString on an enum returns the name given in code, e.g., "Jack", "Two", etc.
			}
			return r + " of " + Suit.ToString();
		}

		public int CompareTo(Card? other) {
			ArgumentNullException.ThrowIfNull(other);
			return Kind.CompareTo(other.Kind);
		}
	}
}
