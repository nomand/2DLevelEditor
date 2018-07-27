using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runningtap
{
    public class LevelGridVisual : MonoBehaviour
    {
        public GameObject GridTemplatePrefab;

        [HideInInspector]
        public GameObject newGrid;

        public void UpdateGridVisual(int x, int y)
        {
            newGrid = Instantiate(GridTemplatePrefab, transform) as GameObject;

            float offsetx = (x % 2 == 0) ? 0.5f : 0f;
            float offsety = (y % 2 == 0) ? 0.5f : 0f;

            newGrid.transform.localScale = new Vector3(x, y, 1);
            newGrid.GetComponent<Renderer>().material.SetTextureScale("_MainTex", new Vector2(x, y));
            newGrid.transform.position = new Vector3(transform.position.x + (x / 2) - offsetx, transform.position.y + (y / 2) - offsety, 0f);
        }
    }
}