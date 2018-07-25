using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runningtap
{
    public class CameraRubberBand : MonoBehaviour
    {
        public GameObject Grid;

        private GameObject gridVisual;
        private Bounds gridBounds;
        private float x;
        private float y;
        private Vector3 half;

        private void Start()
        {
            gridVisual = Grid.GetComponent<LevelGridVisual>().newGrid;
            gridBounds = gridVisual.GetComponent<Collider>().bounds;
            half = gridBounds.extents;
        }

        public bool CheckOutOfBounds()
        {
            if (
                transform.position.x < gridVisual.transform.position.x - half.x ||
                transform.position.x > gridVisual.transform.position.x + half.x ||
                transform.position.y < gridVisual.transform.position.y - half.y ||
                transform.position.y > gridVisual.transform.position.y + half.y)
                return true;
            else
                return false;
        }
    }
}