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
            CreateEmptyCoordingates(Grid.Resolution, Grid.Resolution);
        }

        public void CreateEmptyCoordingates(int x, int y)
        {
            xy = new GameObject[x][];

            for (int xi = 0; xi < x; xi++)
            {
                xy[xi] = new GameObject[y];

                for (int yi = 0; yi < y; yi++)
                {
                    xy[xi][yi] = null;
                }
            }
        }
    }
}