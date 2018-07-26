using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runningtap
{
    public class LevelData : MonoBehaviour
    {
        public GameObject[][] xy;
        public LevelGrid Grid;

        private void Start()
        {
            CreateCoordingates(Grid.resolution);
        }

        void CreateCoordingates(int resolution)
        {
            xy = new GameObject[resolution][];

            for (int xi = 0; xi < resolution; xi++)
            {
                xy[xi] = new GameObject[resolution];

                for (int yi = 0; yi < resolution; yi++)
                {
                    xy[xi][yi] = null;
                }
            }
        }
    }
}