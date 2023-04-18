using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyAI;
using System.Linq;
using Project.Pickups;
using Project.Sensors;

namespace Project.States
{
    public class SoldierAttackState : State
    {
        public override void Enter(Agent agent)
        {
            agent.Log("Enter: Attack state");
        }

        public override void Execute(Agent agent)
        {
            agent.Log("Execute: Attack state");
            Soldier soldier = agent as Soldier;
            HealthAmmoPickup health = soldier.Sense<NearestHealthPickupSensor, HealthAmmoPickup>();
            HealthAmmoPickup ammo = soldier.Sense<NearestAmmoPickupSensor, HealthAmmoPickup>();

            if (soldier.Health < 50)
            {
                soldier.Navigate(health.transform.position);
            }

            if (soldier.Weapons[3].Ammo == 0) 
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
                    soldier.StopNavigating();
                }
                else 
                {
                    
                }

            }
            
        }

        public override void Exit(Agent agent)
        {
            agent.Log("Exit: Attack state");
        }
    }
}