using System.Collections;
using System.Collections.Generic;
using TreeBuilder.Generator;
using UnityEngine;

public class DebugVisualizer : MonoBehaviour {
	public LindemayerGraph Graph;
	public int Iterations = 4;

	// Use this for initialization
	void Start () {
		var system = ScriptableObject.CreateInstance<LindemayerSystem>();
		for (int i = 0; i < Iterations; i++)
		{
			system = system.Iterate();
		}
        Graph = LindemayerTurtle.Plot(system);		
	}
	
	// Update is called once per frame
	void Update () {
		foreach(var segment in Graph.Segments)
		{
			var startPoint = Graph.Points[segment.Start];
			var endPoint = Graph.Points[segment.End];
			Debug.DrawLine(startPoint, endPoint, Color.black, 0f);		
		}
	}
}
