using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runningtap
{
    public class LevelGrid : MonoBehaviour
    {
        [SerializeField]
        private int size = 1;

        public int resolution
        {
            get { return size; }
            set { resolution = value; }
        }

        private void Awake()
        {
            GetComponent<LevelGridVisual>().UpdateGridVisual(size);
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