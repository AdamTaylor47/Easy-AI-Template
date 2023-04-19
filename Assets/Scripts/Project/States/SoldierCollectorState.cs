using EasyAI;
using Project;
using Project.Pickups;
using Project.Sensors;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
            
            HealthAmmoPickup ammo = soldier.Sense<NearestAmmoPickupSensor, HealthAmmoPickup>();

            soldier.Navigate(soldier.EnemyFlagPosition);
            if(soldier.CarryingFlag) 
            {
                soldier.Navigate(soldier.TeamFlagPosition);
            }

            if (soldier.Weapons[1].Ammo == 0)
            {
                soldier.Navigate(ammo.transform.position);
            }


            if (soldier.DetectedEnemies.Count == 0)
            {
                soldier.Navigate(soldier.EnemyFlagPosition);
                soldier.NoTarget();
                return;
            }

            Soldier.EnemyMemory target = soldier.DetectedEnemies.OrderBy(e => e.Visible).ThenBy(e => Vector3.Distance(e.Position, soldier.transform.position)).First();

            if (Vector3.Distance(target.Position, soldier.transform.position) < 30)
            {
                soldier.SetTarget(new()
                {
                    Enemy = target.Enemy,
                    Position = target.Position,
                    Visible = target.Visible
                });
            }

            if (soldier.DetectedEnemies.Count > 0)
            {
                if (target.Visible && Vector3.Distance(target.Position, soldier.transform.position) < 30)
                {
                    soldier.Navigate(target.Position);
                }
            }
        }

        public override void Exit(Agent agent)
        {
            agent.Log("Exit: Collect state");
        }
    }
}

