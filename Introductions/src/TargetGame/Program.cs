namespace Csulb.TargetGame {
	// This game challenges the user to hit a target placed at a random distance away,
	// by choosing an angle and gunpowder amount to use when firing a cannon.
	// The game continues until the user hits the target within 1 meter.
	internal class Program {
		static void Main(string[] args) {
			Console.WriteLine("Welcome to the Target Game!");

			double angle = 0;
			double gunpowder = 0;
			bool finished = false;
			const double GUNPOWDER_TO_MPS = 10;

			Random random = new Random();
			int targetDistance = random.Next(100, 1000);
			
			Console.WriteLine($"The target is {targetDistance}m away.");

			do {
				Console.WriteLine();
				Console.Write("What angle will you shoot your cannon? [0-90.0 degrees] ");
				angle = Convert.ToDouble(Console.ReadLine()) * Math.PI / 180;

				Console.Write("How much gunpowder? [0 or more kg] ");
				gunpowder = Convert.ToDouble(Console.ReadLine());

				// Compute the distance travelled by the cannonball. 
				double velocity = GUNPOWDER_TO_MPS * gunpowder;
				double velocityY = velocity * Math.Sin(angle);
				double velocityX = velocity * Math.Cos(angle);

				// Without air resistance, and assuming the cannon is fired from the ground,
				// the time to the apex of the arc is the vertical velocity divided by vertical acceleration.
				double timeToApex = velocityY / 9.8;
				// The time from the apex to the ground is the same as from ground to apex, so the total
				// time of flight is 2 * time to apex.
				double timeOfFlight = 2 * timeToApex;
				// The total distance travelled horizontally is the horizontal velocity times the time of flight.
				double horizontalDistance = timeOfFlight * velocityX;
				double diff = horizontalDistance - targetDistance;

				if (diff < 1 && diff > -1) {
					Console.WriteLine("You hit the target!");
					finished = true;
				}
				else if (diff > 0) {
					Console.WriteLine($"Your shot landed {diff:F2}m past the target.");
				}
				else {
					Console.WriteLine($"Your shot landed {-diff:F2}m short of the target.");
				}
			} while (!finished);
		}
	}
}
