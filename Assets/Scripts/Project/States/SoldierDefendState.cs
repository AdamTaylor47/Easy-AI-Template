using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyAI;
using Project.Pickups;
using Project.Sensors;
using static UnityEditor.FilePathAttribute;
using Project.Positions;
using System.Linq;

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
            soldier.StopNavigating();

            
            HealthAmmoPickup health = soldier.Sense<NearestHealthPickupSensor, HealthAmmoPickup>();
            HealthAmmoPickup ammo = soldier.Sense<NearestAmmoPickupSensor, HealthAmmoPickup>();
            StrategicPoint defpos = soldier.Sense<RandomDefensivePositionSensor, StrategicPoint>();

            if (soldier.DetectedEnemies.Count == 0)
            {
                soldier.Navigate(soldier.TeamFlagPosition);
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
            if (soldier.Health < 50)
            {
                soldier.Navigate(health.transform.position);
            }
            if (soldier.Weapons[1].Ammo == 0)
            {
                soldier.Navigate(ammo.transform.position);
            }
            
        }

        public override void Exit(Agent agent) 
        {
            agent.Log("Exit: Defending state");
        }
    }
}

