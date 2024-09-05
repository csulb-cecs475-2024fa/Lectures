using Cecs475.Students;

internal class Program {
	private static void Main(string[] args) {
		// Demonstrate the differences in value semantics vs reference semantics.

		// The "primitive" types in C# are all "value types". When a value type variable
		// is declared, the variable directly stores the value assigned to it, at the 
		// memory address assigned to the variable.

		int x;
		// As a local (temporary) variable, x is given space on the "stack". 
		// Because int is a value type, the size of x equals the size of an int -- 4 bytes.
		// Draw this.

		x = 5;
		// When x is assigned a value, that value is directly stored at x's memory address.
		// Again, because x is an int, and int is a value type.

		int y;
		// Draw y on the stack.
		y = x;
		// When y is given a value, it is directly stored at y's memory address. But y's address
		// is not x's address. y and x have two different values. They might be equal, but the
		// two values are distinct in memory.
		// Draw this.

		// Assigning a value type to another value type creates a COPY of the original value.
		// This is called "value semantics".

		x += 1;
		// Because x and y are distinct locations in memory, mutating x's value has no effect
		// on y's value.
		Console.WriteLine(x);
		Console.WriteLine(y);

		// This is true of all value type instances, even if they are properties of a class.
		Student s = new Student(5, "Neal", "Terrell");
		int localId = s.Id;
		s.Id = 100;
		Console.WriteLine(localId); // What does this print?

		// Other types in C# are "reference types". Any type declared with the "class" keyword
		// is a reference type. When a reference type variable is declared, the variable stores
		// a *REFERENCE* to an actual value of that type, but the value lives somewhere else.
		// The reference type variable is effectively a *pointer* to the real value's memory address.

		string z = "Hello";
		// z is a local variable and goes on the stack, and a reference type variable is ALWAYS 8 bytes
		// no matter what. The actual string "Hello" lives somewhere else, and z just points to it.

		string w = z;
		// Now w (8 bytes on stack) points to the same string instance as z.
		// Since strings are immutable in C#, there's not much more to do with this example.

		// Now draw the Student variable s.


		Student u = s;
		u.Hobbies.Add("Baseball");
		// Draw u.
		// Copying a reference variable to another simply makes the second point to the same object
		// as the first. This is called "reference semantics".
		// If we *mutate* some field of s, then u will "see" that mutation.
		s.Id = 9999;
		List<string> hobbies = s.Hobbies;
		hobbies.Add("Coding");
		Console.WriteLine(u.Id);
		Console.WriteLine(string.Join(',', u.Hobbies));

		// LESSONS:
		// If you return a value type, the caller receives a copy of your value. They can mutate it
		//		without affecting your value.

		// If you return a reference type, the caller can mutate your value through their reference.
		//		This might not be what you want, so carefully consider whether to expose reference
		//		types as return values or properties.
	}
}