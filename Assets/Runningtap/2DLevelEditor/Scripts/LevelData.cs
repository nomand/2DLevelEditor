using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace Runningtap
{
    public class LevelData : MonoBehaviour
    {
        public GameObject[][] xy;
        public LevelGrid Grid;

        private static string gameDataProjectFilePath = "/Runningtap/2DLevelEditor/StreamingAssets/LevelData.json";

        private void Start()
        {
            CreateEmptyCoordingates(Grid.X, Grid.Y);
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

        public void SaveData()
        {
            string dataAsJson = JsonUtility.ToJson(this.xy, true);
            string filePath = Application.dataPath + gameDataProjectFilePath;
            File.WriteAllText(filePath, dataAsJson);
        }
    }
}