using UnityEngine;
using System.Collections.Generic;

namespace Runningtap
{
    [CreateAssetMenu(fileName = "Tile Pallete", menuName = "Runningtap/2DLevelEditor/Tile Palette")]
    [System.Serializable]
    public class LevelTilePalette : ScriptableObject
    {
        public List<LevelTile> LevelTiles;
    }
}