﻿using System;

// A namespace is a logical grouping of types under one name. A namespace is added to a type's name to create its
// Fully Qualified Name. Namespaces are similar to Python modules, except Python modules define a physical on-disk
// grouping in addition to a logical grouping.
namespace Cecs475.War {
	// A class defines a new reference type. In .NET, a reference type uses reference semantics for assignment and
	// copying. (More on this later.) .NET (and thus C#) give us the option of declaring non-reference types, which
	// we will also see later.

	// A comment like the one below is a documentation comment.
	/// <summary>
	/// Represents a single card in a 52-card deck of playing cards.
	/// </summary>
	// This class could be used by other programmers; it represents a generic card, not something internally specific
	// to this one application. "public" allows code from anywhere else in .NET to use this class as long as they have
	// access to its compiled output.
	public class Card : IComparable<Card> {
		// : IComparable<Card> states that the Card class implements an *interface* called IComparable<Card>.
		// We will talk about interfaces later; for now, this communicates to other programmers that Card objects
		// can be compared to other Card objects to see which is "larger".

		// An enum is a new type whose values can only be taken from the names in the enum declaration. Each value
		// in the enum is secretly an integer counting up from 0.
		// Because this type is declared inside Card, other types will have to use the name "Card.Suit"
		// "public" here means that anyone can reference this declaration.
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

		// Normally we think of class design in terms of FIELDS and METHODS. But .NET goes further,
		// introducing a third term: PROPERTIES. A property is like a field that is publicly readable
		// and optionally writeable. Properties allow us to expose certain attributes of an object
		// through its public API, allowing others to query and sometimes change those attributes.

		// A property is declared with an access modifier, a type, a name, and then a body.
		public CardSuit Suit {
			// The body of the property declares whether it is read-only or can also be written to.
			get;
			set;
		}
		// This is called an "auto property". We specify that the public can get and set the value of
		// the Suit property. Later we will expand these get/set statements; for now, they declare
		// a CardSuit field that can be read and written by the public.
		// This property is public, because it represents something that must be known by other code
		// about Card objects.

		// More compactly, and prettier:
		public CardKind Kind { get; set; }


		// Constructor. This method defines what must be known to create an object of the Card class.
		// Any parameters to this method must be provided when constructing a Card.
		public Card(CardKind kind, CardSuit suit) {
			// Since Suit and Kind are properties with setters, we can assign to them as if they
			// are fields.
			this.Suit = suit;
			this.Kind = kind;
		}

		// Every class can define a method ToString for creating a string representation of an object.
		// The override keyword is mandatory and indicates we are changing the behavior of a method defined in a base
		// class.
		public override string ToString() {
			int kindValue = (int)Kind;
			string r;
			if (kindValue >= 2 && kindValue <= 10) {
				r = kindValue.ToString();
			}
			else {
				r = Kind.ToString(); // ToString on an enum returns the name given in code, e.g., "Jack", "Two", etc.
			}
			return $"{r} of {Suit}";
		}

		// Compare this card to another, to decide which wins the War game. 
		public int CompareTo(Card? other) {
			// It doesn't make sense to compare a Card to null, so we throw an exception if asked to.
			ArgumentNullException.ThrowIfNull(other);

			// Compare the cards based on the integer value of their Kind.
			return this.Kind.CompareTo(other.Kind);
		}
	}
}
