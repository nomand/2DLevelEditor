using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runningtap
{
    public class LevelData : MonoBehaviour
    {
        public Vector3[][] xy;

        private void Start()
        {
            CreateCoordingates(16);
        }

        void CreateCoordingates(int resolution)
        {
            xy = new Vector3[resolution][];

            for (int xi = 0; xi < resolution; xi++)
            {
                xy[xi] = new Vector3[resolution];

                for (int yi = 0; yi < resolution; yi++)
                {
                    xy[xi][yi] = Vector3.zero;
                }
            }
        }
    }
}