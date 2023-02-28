using A2.Sensors;
using EasyAI;
using UnityEngine;

namespace A2.States
{
    /// <summary>
    /// State for microbes that are seeking a mate.
    /// </summary>
    [CreateAssetMenu(menuName = "A2/States/Microbe Mating State", fileName = "Microbe Mating State")]
    public class MicrobeMatingState : State
    {
        public override void Enter(Agent agent)
        {
            // TODO - Assignment 2 - Complete this state. Have microbes look for mates and reproduce.
            agent.Log("Looking for a mate");
        }
        
        public override void Execute(Agent agent)
        {
            // TODO - Assignment 2 - Complete this state. Have microbes look for mates and reproduce.
            agent.Log("Going to Mate");
            Microbe microbe = agent as Microbe;
            Microbe potentialMate = agent.Sense<NearestMateSensor, Microbe>();
            microbe.AttractMate(potentialMate);
            if (microbe.HasTarget)
            {
                if (microbe.Mate())
                {
                    microbe.Mate();
                    microbe.SetState<MicrobeSeekingPickupState>();
                    microbe.CanMate();
                }
                microbe.Move(microbe.TargetMicrobeTransform.position);

            }
            else 
            {
                microbe.SetState<MicrobeRoamingState>();
            }

            

        }
        
        public override void Exit(Agent agent)
        {
            // TODO - Assignment 2 - Complete this state. Have microbes look for mates and reproduce.
        }
    }
}