using EasyAI.Navigation.Nodes;
using UnityEngine;

namespace EasyAI.Navigation.Generators
{
    /// <summary>
    /// Convex corner graph placement for nodes.
    /// </summary>
    public class CornerGraphGenerator : NodeGenerator
    {
        [SerializeField]
        [Min(0)]
        [Tooltip("How far away from corners should the nodes be placed.")]
        private int cornerNodeSteps = 3;

       
     
        /// <summary>
        /// Place nodes at convex corners.
        /// </summary>
        public override void Generate()
        {
            // TODO - Assignment 4 - Complete corner-graph node generation.
            
            for(int i = 0; i < NodeArea.RangeX; i++) 
            {
                for(int k = 0; k < NodeArea.RangeZ; k++) 
                {
                    if (NodeArea.IsOpen(i, k) == true)
                    {
                        NodeArea.AddNode(i, k);
                    }
                }
            }
            
            
        }
    }
}