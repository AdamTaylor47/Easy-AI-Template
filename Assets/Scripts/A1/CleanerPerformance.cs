using A1.Sensors;
using A1.States;
using EasyAI;
using UnityEngine;

namespace A1
{
    [DisallowMultipleComponent]
    public class CleanerPerformance : PerformanceMeasure
    {
        private float time;

        public override float CalculatePerformance() 
        {
            return time;
        }

        private void Update() 
        {
            time += Time.deltaTime;
        }
            

    }
}

