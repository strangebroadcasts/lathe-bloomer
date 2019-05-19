using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TreeBuilder.Generator {
	[System.Serializable]
	public enum LindemayerSegmentKind
	{
		Trunk,
		Leaf	
	}

	[System.Serializable]
	public struct LindemayerSegment {
		public int Start;
		public int End;
		public LindemayerSegmentKind Kind;
	}

	/// <summary>
	/// LindemayerGraph is the graph resulting from the evaluation
	/// of a Lindemayer system.
	/// </summary>
	public class LindemayerGraph : ScriptableObject {
		public List<Vector3> Points;
		public List<LindemayerSegment> Segments;
	}
}
