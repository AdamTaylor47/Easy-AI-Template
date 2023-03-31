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
            
            for(int i = 1; i < NodeArea.RangeX-1; i++) 
            {
                for(int k = 1; k < NodeArea.RangeZ-1; k++) 
                {   
                    if (NodeArea.IsOpen(i, k) == false)
                    {
                        // when i - 1 and k + 1
                        if (NodeArea.IsOpen(i - 1 , k ) && NodeArea.IsOpen(i , k + 1))
                        {
                            for (int x = 1; x <= cornerNodeSteps; x++)
                            {
                                if (NodeArea.IsOpen(i - (1 + x), k) && NodeArea.IsOpen(i, k + (1 + x)))
                                {
                                    if (x == cornerNodeSteps)
                                    {
                                        NodeArea.AddNode(i - (1 + x), k + (1 + x));
                                    }
                                }
                                else 
                                {
                                    break;
                                }
                            }
                        }

                        // when i - 1 and k - 1
                        if (NodeArea.IsOpen(i - 1, k) && NodeArea.IsOpen(i, k - 1))
                        {
                            for (int x = 1; x <= cornerNodeSteps; x++)
                            {
                                if (NodeArea.IsOpen(i - (1 + x), k) && NodeArea.IsOpen(i, k - (1 + x)))
                                {
                                    if (x == cornerNodeSteps)
                                    {
                                        NodeArea.AddNode(i - (1 + x), k - (1 + x));
                                    }
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        // when i + 1 and k - 1
                        if (NodeArea.IsOpen(i + 1, k) && NodeArea.IsOpen(i, k - 1))
                        {
                            for (int x = 1; x <= cornerNodeSteps; x++)
                            {
                                if (NodeArea.IsOpen(i + (1 + x), k) && NodeArea.IsOpen(i, k - (1 + x)))
                                {
                                    if (x == cornerNodeSteps)
                                    {
                                        NodeArea.AddNode(i + (1 + x), k - (1 + x));
                                    }
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        // when i + 1 and k + 1
                        if (NodeArea.IsOpen(i + 1, k) && NodeArea.IsOpen(i, k + 1))
                        {
                            for (int x = 1; x <= cornerNodeSteps; x++)
                            {
                                if (NodeArea.IsOpen(i + (1 + x), k) && NodeArea.IsOpen(i, k + (1 + x)))
                                {
                                    if (x == cornerNodeSteps)
                                    {
                                        NodeArea.AddNode(i + (1 + x), k + (1 + x));
                                    }
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }

                    }
                }
            }
            
            
        }
    }
}