using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyAI;
using Project.Pickups;
using Project.Sensors;
using static UnityEditor.FilePathAttribute;

namespace Project.States 
{
    public class SoldierDefendState : State
    {
        Vector3 location;
        public override void Enter(Agent agent)
        {
            
            agent.Log("Enter: Defending state");
            
            Soldier soldier = agent as Soldier;
            location = new Vector3(soldier.TeamFlagPosition.x + Random.Range(5, -5),
                                   soldier.TeamFlagPosition.y + Random.Range(5, -5),
                                   soldier.TeamFlagPosition.z + Random.Range(5, -5)
                                  );

        }

        public override void Execute(Agent agent)
        {
            agent.Log("Execute: Defending state");

            Soldier soldier = agent as Soldier;
            soldier.StopNavigating();
            soldier.Navigate(location);

            HealthAmmoPickup health = soldier.Sense<NearestHealthPickupSensor, HealthAmmoPickup>();

            if (soldier.Health < 50)
            {
                soldier.Navigate(health.transform.position);
            }

            if (soldier.FlagAtBase)
            {
                
                if (!soldier.Moving) 
                {
                    soldier.Navigate(location = new Vector3(soldier.TeamFlagPosition.x + Random.Range(5, -5),
                                   soldier.TeamFlagPosition.y + Random.Range(5, -5),
                                   soldier.TeamFlagPosition.z + Random.Range(5, -5)
                                   ));
                }
                
            }



            


            
        }

        public override void Exit(Agent agent) 
        {
            agent.Log("Exit: Defending state");
        }
    }
}

