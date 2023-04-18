using EasyAI;
using System.Linq;
using UnityEngine;

namespace Project.States
{
    /// <summary>
    /// The global state which soldiers are always in.
    /// </summary>
    [CreateAssetMenu(menuName = "Project/States/Soldier Mind", fileName = "Soldier Mind")]
    public class SoldierMind : State
    {
        public override void Execute(Agent agent)
        {
            // TODO - Project - Create unique behaviours for your soldiers to play capture the flag.
            Soldier soldier = agent as Soldier;

            
            if (soldier.Role == Soldier.SoliderRole.Attacker) 
            {
                soldier.SetWeaponPriority(shotgun:2,machineGun:1,pistol:3,rocketLauncher:4,sniper:5);
                //agent.SetState<SoldierAttackState>();
            }
            if (soldier.Role == Soldier.SoliderRole.Defender)
            {
                soldier.SetWeaponPriority(shotgun: 5, machineGun: 2, pistol: 3, rocketLauncher: 4, sniper: 1);
                agent.SetState<SoldierDefendState>();
            }
            if (soldier.Role == Soldier.SoliderRole.Collector)
            {
                soldier.SetWeaponPriority(shotgun: 1, machineGun: 2, pistol: 3, rocketLauncher: 4, sniper: 5);
                //agent.SetState<SoldierCollectorState>();
            }

            

        }
    }
}