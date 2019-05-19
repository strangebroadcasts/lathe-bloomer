using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

using TreeBuilder.Generator;

public class LindemayerTurtleTests {

    [Test]
    public void LindemayerTurtle_MoveForward_Works() {
        var system = ScriptableObject.CreateInstance<LindemayerSystem>();
        system.Current = "F";
        var result = LindemayerTurtle.Plot(system);
        Assert.AreEqual(result.Points.Count, 2);
        Assert.AreEqual(result.Segments.Count, 1);
        
        var segment = result.Segments[0];
        Assert.AreEqual(segment.Start, 0);
        Assert.AreEqual(segment.End, 1);
        Assert.AreEqual(segment.Kind, LindemayerSegmentKind.Trunk);
    }

    [Test]
    public void LindemayerTurtle_PushAndPop_Works() {
        var system = ScriptableObject.CreateInstance<LindemayerSystem>();
        // Set up a script which stores the cursor to the stack,
        // moves forward, pops the cursor, turns and moves forward
        system.Current = "[F]+F";
        var result = LindemayerTurtle.Plot(system);

        Assert.AreEqual(result.Points.Count, 3);
        Assert.AreEqual(result.Segments.Count, 2);
        
        var firstSegment = result.Segments[0];
        Assert.AreEqual(firstSegment.Start, 0);
        Assert.AreEqual(firstSegment.End, 1);

        var secondSegment = result.Segments[1];
        Assert.AreEqual(secondSegment.Start, 0);
        Assert.AreEqual(secondSegment.End, 2);
    }
}
