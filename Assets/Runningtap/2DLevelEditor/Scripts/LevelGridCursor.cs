using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Runningtap
{
    public class LevelGridCursor : MonoBehaviour
    {
        public delegate void OnTilePlacement(Vector3 position);
        public static OnTilePlacement TilePlacement;

        public static int CursorCurrentX;
        public static int CursorCurrentY;

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

            if (!EventSystem.current.IsPointerOverGameObject())
            {
                if (Physics.Raycast(ray, out hit))
                {
                    CursorVisual.SetActive(true);
                    UpdateCursor(hit.point);

                    if (Input.GetMouseButton(0))
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
            else
            {
                CursorVisual.SetActive(false);
            }
        }

        void UpdateCursor(Vector3 position)
        {
            CursorCurrentX = Mathf.RoundToInt(grid.GetNearestPointOnGrid(position).x);
            CursorCurrentY = Mathf.RoundToInt(grid.GetNearestPointOnGrid(position).y);
            CursorVisual.transform.position = new Vector3(CursorCurrentX, CursorCurrentY);
        }
    }
}