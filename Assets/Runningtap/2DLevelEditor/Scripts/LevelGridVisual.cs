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

        public void UpdateGridVisual(float size)
        {
            newGrid = Instantiate(GridTemplatePrefab, transform) as GameObject;

            newGrid.transform.localScale *= size;
            newGrid.GetComponent<Renderer>().material.SetTextureScale("_MainTex", new Vector2(size, size));
            newGrid.transform.position = new Vector3(transform.position.x + (size / 2) - 0.5f, transform.position.y + (size / 2) - 0.5f, 0f);
        }
    }
}