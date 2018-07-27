using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runningtap
{
    public class LevelGrid : MonoBehaviour
    {
        [SerializeField]
        private int x, y;

        public int X { get { return x; } set { x = value; } }
        public int Y { get { return y; } set { y = value; } }

        private void Awake()
        {
            GetComponent<LevelGridVisual>().UpdateGridVisual(x, y);
        }

        public Vector3 GetNearestPointOnGrid(Vector3 position)
        {
            position -= transform.position;

            int xCount = Mathf.RoundToInt(position.x);
            int yCount = Mathf.RoundToInt(position.y);
            int zCount = Mathf.RoundToInt(position.z);

            return new Vector3((float)xCount, (float)yCount, (float)zCount) + transform.position;
        }
    }
}