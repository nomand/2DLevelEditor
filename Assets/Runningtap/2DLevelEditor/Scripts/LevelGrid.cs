using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runningtap
{
    public class LevelGrid : MonoBehaviour
    {
        [SerializeField]
        private float size = 1f;

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

        //private void OnDrawGizmos()
        //{
        //    Gizmos.color = Color.yellow;
        //    for (float x = 0; x < size; x ++)
        //    {
        //        for (float y = 0; y < size; y ++)
        //        {
        //            var point = GetNearestPointOnGrid(new Vector3(x, y, 0f));
        //            Gizmos.DrawSphere(point, 0.1f);
        //        }
        //    }
        //}
    }
}