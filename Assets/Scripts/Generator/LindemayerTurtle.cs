using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TreeBuilder.Generator;

namespace TreeBuilder.Generator {

	/// <summary>
	/// LindemayerTurtle turns a finished L-system into a tree graph.
	/// </summary>
	public static class LindemayerTurtle {
		/// <summary>
		/// Add a line segment to the graph (graph).
		/// </summary>
		private static void AddSegment(this LindemayerGraph graph, int start, int end, LindemayerSegmentKind kind) {
			graph.Segments.Add(new LindemayerSegment {Start = start, End = end, Kind = kind });
		}

		/// <summary>
		/// Create a graph from a Lindemayer system.
		/// </summary>
		public static LindemayerGraph Plot(LindemayerSystem system) {
			var Params = new {TurnAngle = 25.0f * Mathf.Deg2Rad, MoveDistance = 10.0f};

			var graph = ScriptableObject.CreateInstance<LindemayerGraph>();
			graph.Points = new List<Vector3>();
			graph.Segments = new List<LindemayerSegment>();

			
			var indexStack = new Stack<int>();
			var vectorStack = new Stack<Vector3>();
			var angleStack = new Stack<float>();

			// TODO: Coalesce these into a single struct
			var cursor = new Vector3();
			var currentPoint = 0;
			var angle = 0.0f;

			graph.Points.Add(cursor);
			foreach(var token in system.Current) {
				switch (token)
				{
					case 'F': // Move forward
						var delta = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0f);
						cursor += delta * Params.MoveDistance;
						graph.Points.Add(cursor);
						var thisPoint = graph.Points.Count - 1;
						graph.AddSegment(currentPoint, thisPoint, LindemayerSegmentKind.Trunk);
						currentPoint = thisPoint;
						break;
					case '-': // Turn left
						angle -= Params.TurnAngle;
						break;
					case '+': // Turn right
						angle += Params.TurnAngle;
						break;
					case 'X': // No-op
						break;
					case '[': // Push cursor to stack
						vectorStack.Push(cursor);
						indexStack.Push(currentPoint);
						angleStack.Push(angle);
						break;
					case ']': // Pop cursor from stack
						cursor = vectorStack.Pop();
						currentPoint = indexStack.Pop();
						angle = angleStack.Pop();
						break;
					default:
						Debug.LogError("Unrecognized token " + token.ToString());
						break;
				}
			}
			return graph;
		}
	}
}