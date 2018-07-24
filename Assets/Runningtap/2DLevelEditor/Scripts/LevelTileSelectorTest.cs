using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runningtap
{
    //shitcode to get placement and storage prototyped

    public class LevelTileSelectorTest : MonoBehaviour
    {
        public GameObject Level;
        public GameObject[] tiles;

        private int currentSelection;

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

        void PlaceTile(Vector3 position)
        {
            Instantiate(tiles[currentSelection], position, Quaternion.identity, Level.transform);
        }
    }
}