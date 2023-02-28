using A2.Sensors;
using EasyAI;
using UnityEngine;

namespace A2.States
{
    /// <summary>
    /// State for microbes that are hungry and wanting to seek food.
    /// </summary>
    [CreateAssetMenu(menuName = "A2/States/Microbe Hungry State", fileName = "Microbe Hungry State")]
    public class MicrobeHungryState : State
    {
        public override void Enter(Agent agent)
        {
            // TODO - Assignment 2 - Complete this state. Have microbes search for other microbes to eat.
            agent.Log("Looking for some food >:)");
        }
        
        public override void Execute(Agent agent)
        {
            // TODO - Assignment 2 - Complete this state. Have microbes search for other microbes to eat.
            agent.Log("Going to my food");
            Microbe microbe = agent as Microbe;
            Microbe prey = agent.Sense<NearestPreySensor, Microbe>();
            microbe.StartHunting(prey);
            if (microbe.HasTarget) 
            {
                if (microbe.Eat())
                {
                    microbe.Log("I am full and in a food coma Zzzzz");
                    microbe.Eat();
                    

                }
                microbe.Move(microbe.TargetMicrobeTransform.position);
            }

           
        }
        
        public override void Exit(Agent agent)
        {
            // TODO - Assignment 2 - Complete this state. Have microbes search for other microbes to eat.
        }
    }
}