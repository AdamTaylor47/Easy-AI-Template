using A2.Pickups;
using A2.Sensors;
using EasyAI;
using UnityEngine;
using UnityEngine.InputSystem.Android;

namespace A2.States
{
    /// <summary>
    /// State for microbes that are seeking a pickup.
    /// </summary>
    [CreateAssetMenu(menuName = "A2/States/Microbe Seeking Pickup State", fileName = "Microbe Seeking Pickup State")]
    public class MicrobeSeekingPickupState : State
    {
        public override void Enter(Agent agent)
        {
            // TODO - Assignment 2 - Complete this state. Have microbes look for pickups.
            agent.Log("Looking for a pickup");
        }
        
        public override void Execute(Agent agent)
        {
            // TODO - Assignment 2 - Complete this state. Have microbes look for pickups.
            agent.Log("Going to Pickup");
            
            NeverHungryPickup hungerPickup = agent.Sense<NearestPickupSensor, NeverHungryPickup>();
            RejuvenatePickup lifePickup = agent.Sense<NearestPickupSensor, RejuvenatePickup>();
            OffspringPickup offSpringPickup = agent.Sense<NearestPickupSensor, OffspringPickup>();
            MatePickup matePickup = agent.Sense<NearestPickupSensor, MatePickup>();

            if (lifePickup) 
            {
                agent.Move(lifePickup.transform.position);
                agent.Act(lifePickup);
            }
            if (hungerPickup) 
            {
                agent.Move(hungerPickup.transform.position);
                agent.Act(hungerPickup);
            }
            if (matePickup) 
            {
                agent.Move(matePickup.transform.position);
                agent.Act(matePickup);
            }
            if (offSpringPickup)
            {
                agent.Move(offSpringPickup.transform.position);
                agent.Act(offSpringPickup);
            }

        }
        
        public override void Exit(Agent agent)
        {
            // TODO - Assignment 2 - Complete this state. Have microbes look for pickups.
            agent.Log("Nothing to Pick up");
        }
    }
}