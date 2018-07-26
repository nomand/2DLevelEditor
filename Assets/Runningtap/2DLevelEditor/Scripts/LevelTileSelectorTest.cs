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

        public enum Mode
        {
            Paint,
            Erase,
            Move
        }
        [HideInInspector]
        public Mode cursorMode = Mode.Paint;

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

        public void SetBrushMode(int mode)
        {
            if (mode == 0)
                cursorMode = Mode.Paint;
            else if (mode == 1)
                cursorMode = Mode.Erase;
            else if (mode == 2)
                cursorMode = Mode.Move;
        }

        public void SelectRune(int index)
        {
            currentSelection = index;
        }

        bool IsCellEmpty(Vector3 position)
        {
            return (levelData.xy[Mathf.RoundToInt(position.x)][Mathf.RoundToInt(position.y)] == null) ? true : false;
        }

        public void PlaceTile(Vector3 position)
        {
            if (cursorMode == Mode.Paint)
            {
                if (IsCellEmpty(position))
                {
                    levelData.xy[Mathf.RoundToInt(position.x)][Mathf.RoundToInt(position.y)] = Instantiate(Tiles[currentSelection], position, Quaternion.identity, Level.transform);
                }
                else if (levelData.xy[Mathf.RoundToInt(position.x)][Mathf.RoundToInt(position.y)] != Tiles[currentSelection])
                {
                    Destroy(levelData.xy[Mathf.RoundToInt(position.x)][Mathf.RoundToInt(position.y)]);
                    levelData.xy[Mathf.RoundToInt(position.x)][Mathf.RoundToInt(position.y)] = Instantiate(Tiles[currentSelection], position, Quaternion.identity, Level.transform);
                }
            }
            else if (cursorMode == Mode.Erase)
            {
                Destroy(levelData.xy[Mathf.RoundToInt(position.x)][Mathf.RoundToInt(position.y)]);
                levelData.xy[Mathf.RoundToInt(position.x)][Mathf.RoundToInt(position.y)] = null;
            }
        }
    }
}