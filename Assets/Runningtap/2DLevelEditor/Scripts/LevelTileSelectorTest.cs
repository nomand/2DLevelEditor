using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runningtap
{
    //shitcode to get placement and storage prototyped

    public class LevelTileSelectorTest : MonoBehaviour
    {
        public GameObject Level;
        public GameObject[] Tiles;

        private LevelData levelData;
        private int currentSelection;

        private void Start()
        {
            levelData = GetComponent<LevelData>();
        }

        private void OnEnable()
        {
            LevelGridCursor.TilePlacement += PlaceTile;
        }

        private void OnDisable()
        {
            LevelGridCursor.TilePlacement -= PlaceTile;
        }

        public void SelectTile(int index)
        {
            currentSelection = index;
        }

        bool IsCellEmpty(Vector3 position)
        {
            return (levelData.xy[Mathf.RoundToInt(position.x)][Mathf.RoundToInt(position.y)] == Vector3.zero) ? true : false;
        }

        public void PlaceTile(Vector3 position)
        {
            if (IsCellEmpty(position))
            {
                levelData.xy[Mathf.RoundToInt(position.x)][Mathf.RoundToInt(position.y)] = position;
                Instantiate(Tiles[currentSelection], position, Quaternion.identity, Level.transform);
            }
        }
    }
}