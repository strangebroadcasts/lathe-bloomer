using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

using TreeBuilder.Generator;

public class LindemayerSystemTests {

    [Test]
    public void LindemayerSystem_Instantiation_Works() {
        var system = ScriptableObject.CreateInstance<LindemayerSystem>();
        Assert.IsNotNull(system);
    }

    [TestCase("X", "F+[[X]-X]-F[-FX]+X")]
    [TestCase("F", "FF")]
    public void LindemayerSystem_Iterating_MaintainsRules(string input, string expected) {
        
        var system = ScriptableObject.CreateInstance<LindemayerSystem>();
        system.Current = input;
        var result = system.Iterate();
        Assert.AreEqual(result.Current, expected);
    }

    
}
