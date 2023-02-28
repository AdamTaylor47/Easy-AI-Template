using EasyAI;
using UnityEngine;

namespace A2.States
{
    /// <summary>
    /// State for microbes that are being hunted.
    /// </summary>
    [CreateAssetMenu(menuName = "A2/States/Microbe Hunted State", fileName = "Microbe Hunted State")]
    public class MicrobeHuntedState : State
    {
        public override void Enter(Agent agent)
        {
            // TODO - Assignment 3 - Complete this state. Add the ability for microbes to evade hunters.
            agent.Log("I'm being hunted!");
        }

        public override void Execute(Agent agent)
        {
            // TODO - Assignment 3 - Complete this state. Add the ability for microbes to evade hunters.
            agent.Log("I dont run, I fight back");
            Microbe microbe = agent as Microbe;
            if (microbe.BeingHunted) 
            {
                if (microbe.Eat()) 
                {
                    microbe.Eat();
                }
                microbe.Move(microbe.Hunter.transform.position);
            }
            
        }
        
        public override void Exit(Agent agent)
        {
            // TODO - Assignment 3 - Complete this state. Add the ability for microbes to evade hunters.
            agent.Log("No longer being hunted.");
        }
    }
}