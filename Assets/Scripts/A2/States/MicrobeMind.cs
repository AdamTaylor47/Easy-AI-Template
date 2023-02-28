using A2.Sensors;
using EasyAI;
using Project.Pickups;
using System.Linq;
using UnityEngine;

namespace A2.States
{
    /// <summary>
    /// The global state which microbes are always in.
    /// </summary>
    [CreateAssetMenu(menuName = "A2/States/Microbe Mind", fileName = "Microbe Mind")]
    public class MicrobeMind : State
    {
        public override void Execute(Agent agent)
        {
            // TODO - Assignment 2 - Complete the mind of the microbes.
            Microbe microbe = agent as Microbe;

            if (!microbe.IsAdult)
            {
                agent.SetState<MicrobeSeekingPickupState>();
            }

            if (microbe.IsAdult)
            {
                agent.SetState<MicrobeMatingState>();
                
            }
            if (microbe.DidMate == true)
            {
                agent.SetState<MicrobeRoamingState>();
            }
            if (microbe.IsHungry == true)
            {
                agent.SetState<MicrobeHungryState>();
            }
            if (microbe.BeingHunted == true)
            {
                agent.SetState<MicrobeHuntedState>();
            }
            if (microbe.Moving == false)
            {
                agent.SetState<MicrobeRoamingState>();
            }
            
            

            
            
 
            
           
        }
    }
}