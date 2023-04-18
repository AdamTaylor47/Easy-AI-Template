using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyAI;

namespace Project.States
{
    public class SoldierRoamState : State
    {
        public override void Enter(Agent agent)
        {
            agent.Log("Enter: Roam state");
        }

        public override void Execute(Agent agent)
        {
            agent.Log("Execute: Roam state");
            Soldier soldier = agent as Soldier;
            
        }

        public override void Exit(Agent agent)
        {
            agent.Log("Exit: Roam state");
        }
    }
}