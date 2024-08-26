// This game challenges the user to hit a target placed at a random distance away,
// by choosing an angle and gunpowder amount to use when firing a cannon.
// The game continues until the user hits the target within 1 meter.

// Newer versions of C# let us write our program with "top level statements", 
// just like Python. 

// C# has a static type system, where we declare the type of a variable before
// assigning it a value.

// "Primitive" types can be assigned literal values.
int targetDistance = 0;
// See chapter 1 notes for other primitive types.
const int MAX_DISTANCE = 1000;

// The Random type generates random numbers. It is not built-in to C#; it is part
// of the .NET libraries. The "new" keyword is needed to construct an object of
// a non-primitive type.
Random rand = new Random();

// Printing.
Console.WriteLine("Welcome to target practice!");

// Choose a random target distance as an integer from 0 to 1000, inclusive.
targetDistance = rand.Next(0, MAX_DISTANCE + 1);

// "Interpolated" strings start with $, and act like f-strings in Python.
Console.WriteLine($"You are trying to hit a target that is {targetDistance}m away.");
bool hitTarget = false;
while (!hitTarget) {
	double angle = GetAngle();
	double gunpowder = GetGunpowder();

	double distanceTraveled = DistanceTraveled(angle, gunpowder);
	double missedBy = Math.Abs(distanceTraveled - targetDistance);
	if (missedBy <= 1.0) {
		Console.WriteLine("You hit the target!");
		hitTarget = true;
	}
	else if (distanceTraveled < targetDistance) {
		Console.WriteLine($"You were short by {missedBy}m. Try again!");
	}
	else {
		Console.WriteLine($"You were long by {missedBy}m. Try again!");
	}
}

// Function declarations start with the return type, then the name, then
// the parameter list.
double GetAngle() {
	double angle = -1;
	while (angle < 0 || angle > 90) {
		Console.Write("Enter an angle of elevation for the cannon, from 0 to 90 degrees: ");
		string? input = Console.ReadLine();
		if (input is null) {
			throw new Exception("No value read from console stream.");
		}
		angle = double.Parse(input);
	}
	return angle;
}
double GetGunpowder() {
	double gunpowder = -1;
	while (gunpowder < 0) {
		Console.Write("Enter an amount of gunpowder to use, in kilograms: ");
		string? input = Console.ReadLine();
		if (input is null) {
			throw new Exception("No value read from console stream.");
		}
		gunpowder = double.Parse(input);
	}
	return gunpowder;
}
double DistanceTraveled(double angle, double gunpowder) {
	// Each kg of gunpowder creates 30 meters per second of velocity.
	const double GUNPOWDER_MPS = 30;
	const double GRAVITY = 9.81;

	double velocity = gunpowder * GUNPOWDER_MPS;
	double radians = angle * Math.PI / 180;

	// From physics: distance = v^2 * sin(2*theta) / G.
	return velocity * velocity * Math.Sin(2 * radians) / GRAVITY;
}
