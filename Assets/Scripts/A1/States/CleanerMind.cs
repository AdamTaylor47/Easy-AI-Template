using A1.Sensors;
using EasyAI;
using UnityEngine;

namespace A1.States
{
    /// <summary>
    /// The global state which the cleaner is always in.
    /// </summary>
    [CreateAssetMenu(menuName = "A1/States/Cleaner Mind", fileName = "Cleaner Mind")]
    public class CleanerMind : State
    {
        public override void Execute(Agent agent)
        {
            // TODO - Assignment 1 - Complete the mind of this agent along with any sensors and actuators you need.
            if(agent.HasAction<Transform>()) 
            {
                return;
            }

            Floor tile = agent.Sense<CleanTileSensor, Floor>();

            if (tile == null) 
            {
                agent.Log("All tiles are clean");
                
                return;
            }
            
            agent.Move(tile.transform.position);
            agent.Act(tile);
            

        }
        
    }
}