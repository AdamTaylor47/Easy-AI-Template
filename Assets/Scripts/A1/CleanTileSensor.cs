
using UnityEngine;
using EasyAI;
using System.Linq;
using System.Drawing.Text;

namespace A1.Sensors 
{
    [DisallowMultipleComponent]
    public class CleanTileSensor : Sensor 
    {
        public override object Sense() 
        {
            
            Floor[] tiles = FindObjectsOfType<Floor>().Where(m => m.IsDirty == true).ToArray();
            

            if (tiles.Length == 0) 
            {
                Log("no tiles to clean, cleaning risky tiles instead");
                tiles = FindObjectsOfType<Floor>().Where(m => m.LikelyToGetDirty == true).ToArray();
                
            }
            
            Log("Getting closest tile");
            return tiles.OrderBy(x => Vector3.Distance(Agent.transform.position, x.transform.position)).First();
            

            /*
            Log("Getting Furthest tile?");
            return tiles.OrderBy(x => Vector3.Distance(Agent.transform.position, x.transform.position)).Last();
            */

            /*
            Log("Getting random tile");
            return tiles.OrderBy(x => Random.Range(0,tiles.Length)).First();
            */

        }
    }
}

