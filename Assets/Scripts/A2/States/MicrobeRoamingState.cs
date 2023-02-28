using EasyAI;
using UnityEngine;

namespace A2.States
{
    /// <summary>
    /// Roaming state for the microbe, doesn't have any actions and only logs messages.
    /// </summary>
    [CreateAssetMenu(menuName = "A2/States/Microbe Roaming State", fileName = "Microbe Roaming State")]
    public class MicrobeRoamingState : State
    {
        Vector3 location;
        public override void Enter(Agent agent)
        {
            // TODO - Assignment 2 - Complete this state. Have microbes randomly roam around.
            agent.Log("Time to roam");
            location = new Vector3(Random.Range(-20, 20), Random.Range(-20, 20), Random.Range(-20, 20));
        }

        public override void Execute(Agent agent)
        {
            // TODO - Assignment 2 - Complete this state. Have microbes randomly roam around.
            agent.Log("Roam Time");
            
            Microbe microbe = agent as Microbe;
            microbe.StopMoving();
            microbe.Move(location);
            if (!microbe.Moving) 
            {
                location = new Vector3(Random.Range(-20, 20), Random.Range(-20, 20), Random.Range(-20, 20));
            }
        }
        
        public override void Exit(Agent agent)
        {
            // TODO - Assignment 2 - Complete this state. Have microbes randomly roam around.
        }
    }
}