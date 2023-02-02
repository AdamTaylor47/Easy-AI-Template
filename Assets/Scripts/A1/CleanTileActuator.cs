using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyAI;

namespace A1.Actuators 
{
    [DisallowMultipleComponent]
    public class CleanTileActuator : Actuator 
    {
        [Tooltip("How far away from the tile must the agent be to clean it")]
        [Min(float.Epsilon)]

        [SerializeField]
        private float cleanDistance = 3;
        public override bool Act(object agentAction)
        {
            if (agentAction is not Floor tile) 
            {
                return false;
            }
            if (Vector3.Distance(Agent.transform.position, tile.transform.position) > cleanDistance) 
            {
                //not close enough
                Log("Not close enough");
                return false;
            }


            tile.Clean();
            Log("cleaned");
            
            return true;
        }
    }


}
