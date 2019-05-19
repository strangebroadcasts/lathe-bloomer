using TreeBuilder.Generator;
using UnityEngine;

namespace TreeBuilder.Lathe
{
    public interface ILathe
    {
        Mesh Lathe(LindemayerGraph graph);
    }
    
}