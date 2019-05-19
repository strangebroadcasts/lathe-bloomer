using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

using TreeBuilder.Generator;

public class IntegrationTests {

    [Test]
    public void IntegrationTestsPipeline() {
        var system = ScriptableObject.CreateInstance<LindemayerSystem>();
        var iteration = system.Iterate();
        var graph = LindemayerTurtle.Plot(iteration);
        Assert.IsNotNull(graph);
    }
}
