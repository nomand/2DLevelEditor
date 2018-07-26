using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runningtap
{
    public class LevelGridCursor : MonoBehaviour
    {
        public delegate void OnTilePlacement(Vector3 position);
        public static OnTilePlacement TilePlacement;

        public GameObject CursorVisual;
        public Camera LevelEditorCamera;

        private LevelGrid grid;
        private RaycastHit hit;
        private Ray ray;

        private void Start()
        {
            grid = GetComponent<LevelGrid>();

            CursorVisual = Instantiate(CursorVisual, transform);
            CursorVisual.SetActive(false);
        }

        void Update()
        {
            ray = LevelEditorCamera.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit))
            {
                CursorVisual.SetActive(true);
                UpdateCursor(hit.point);

                if(Input.GetMouseButton(0))
                {
                    if (TilePlacement != null)
                        TilePlacement(grid.GetNearestPointOnGrid(hit.point));
                }
            }
            else
            {
                CursorVisual.SetActive(false);
            }
        }

        void UpdateCursor(Vector3 position)
        {
            CursorVisual.transform.position = grid.GetNearestPointOnGrid(position);
        }
    }
}