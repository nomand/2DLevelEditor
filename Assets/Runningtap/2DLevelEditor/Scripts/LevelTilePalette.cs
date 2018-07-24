using UnityEngine;
using System.Collections.Generic;

namespace Runningtap
{
    [CreateAssetMenu(fileName = "Tile Pallete", menuName = "Runningtap/Tile Palette")]
    [System.Serializable]
    public class LevelTilePalette : ScriptableObject
    {
        public List<LevelTile> prefabs;
    }
}