using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyAI;
using Project.Pickups;
using Project.Sensors;
using static UnityEditor.FilePathAttribute;
using Project.Positions;
using System.Linq;
using System.Linq.Expressions;

namespace Project.States 
{
    public class SoldierDefendState : State
    {
        Vector3 location;
        public override void Enter(Agent agent)
        {
            
            agent.Log("Enter: Defending state");
            
        }

        public override void Execute(Agent agent)
        {
            agent.Log("Execute: Defending state");

            Soldier soldier = agent as Soldier;
           

            
            HealthAmmoPickup health = soldier.Sense<NearestHealthPickupSensor, HealthAmmoPickup>();
            HealthAmmoPickup ammo = soldier.Sense<NearestAmmoPickupSensor, HealthAmmoPickup>();
            Vector3 defpos = soldier.Sense<RandomDefensivePositionSensor, Vector3>();
            

            

            if (soldier.Health < 50)
            {
                soldier.Navigate(health.transform.position);
            }
            if (soldier.Weapons[1].Ammo == 0)
            {
                soldier.Navigate(ammo.transform.position);
            }
            if (!soldier.Moving)
            {
                soldier.Navigate(defpos);
            }

            if (soldier.DetectedEnemies.Count == 0)
            {
                soldier.NoTarget();
                return;
            }
            Soldier.EnemyMemory target = soldier.DetectedEnemies.OrderBy(e => e.Visible).ThenBy(e => Vector3.Distance(e.Position, soldier.transform.position)).First();

            soldier.SetTarget(new()
            {
                Enemy = target.Enemy,
                Position = target.Position,
                Visible = target.Visible
            });
            
        }

        public override void Exit(Agent agent) 
        {
            agent.Log("Exit: Defending state");
        }
    }
}

