using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runningtap
{
    public class LevelGridCursor : MonoBehaviour
    {
        public delegate void OnTilePlacement(Vector3 position);
        public static OnTilePlacement TilePlacement;

        public GameObject gridCursor;
        public Camera LevelEditorCamera;
        LevelGrid grid;
        RaycastHit hit;
        Ray ray;

        private void Start()
        {
            grid = GetComponent<LevelGrid>();

            gridCursor = Instantiate(gridCursor, transform);
            gridCursor.SetActive(false);
        }

        void Update()
        {
            ray = LevelEditorCamera.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit))
            {
                gridCursor.SetActive(true);
                UpdateCursor(hit.point);

                if(Input.GetMouseButtonDown(0))
                {
                    if (TilePlacement != null)
                        TilePlacement(grid.GetNearestPointOnGrid(hit.point));
                }
            }
            else
            {
                gridCursor.SetActive(false);
            }
        }

        void UpdateCursor(Vector3 position)
        {
            gridCursor.transform.position = grid.GetNearestPointOnGrid(position);
        }
    }
}