using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
namespace Cecs475.Web.Calculator.Controllers {
	public class BinaryOperands<T> {
		public required T X { get; set; }
		public required T Y { get; set; }
	}

	// This simple class will demo attribute-based routing.
	[ApiController]
	[Route("[controller]")]
	public class CalcController : ControllerBase {
		// We write a method and add an attribute to it for the type of request it can handle.
		[HttpGet]
		// And we also define the route for this method.
		[Route("Add")] // the full route is Calc/Add
		public int Add(int x, int y) {
			// GET methods are called using URL parameters, as in /Calc/Add?x=10&y=5
			return x + y;
		}

		// POST methods are called with a body that contains the arguments. Only one argument
		// can come from the body, so if we want to take multiple values in an argument, we need
		// a package type to contain them.
		[HttpPost]
		[Route("Multiply")]
		public int Multiply([FromBody]BinaryOperands<int> ops) {
			return ops.X * ops.Y;
		}

		[HttpPost]
		[Route("Divide")]
		public double Divide([FromBody]BinaryOperands<double> ops) {
			return ops.X / ops.Y;
		}
	}
}
