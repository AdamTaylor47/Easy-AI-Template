using EasyAI;
using Project;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.States { 
    public class SoldierCollectorState : State
    {
        public override void Enter(Agent agent)
        {
            agent.Log("Enter: Collect state");
        }

        public override void Execute(Agent agent)
        {
            agent.Log("Execute: Collect state");
            Soldier soldier = agent as Soldier;
            soldier.Navigate(soldier.EnemyFlagPosition);

        }

        public override void Exit(Agent agent)
        {
            agent.Log("Exit: Collect state");
        }
    }
}

