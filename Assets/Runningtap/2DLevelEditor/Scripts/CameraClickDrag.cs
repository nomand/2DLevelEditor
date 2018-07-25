using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runningtap
{
    public class CameraClickDrag : MonoBehaviour
    {
        public int CameraDragSpeed = 50;

        private float currentZoom;
        private bool isDragging;
        private CameraRubberBand rubberBand;
        private Vector3 lastValidPosition;

        private void Start()
        {
            rubberBand = GetComponent<CameraRubberBand>();
        }

        private void Update()
        {
            if(!rubberBand.CheckOutOfBounds())
            {
                lastValidPosition = transform.position;
            }

            isDragging = Input.GetMouseButton(1) ? true : false;
        }

        private void LateUpdate()
        {
            if(isDragging)
            {
                float speed = CameraDragSpeed * Time.deltaTime;
                transform.position -= new Vector3(Input.GetAxis("Mouse X") * speed, Input.GetAxis("Mouse Y") * speed, 0f);
            }
            else if(rubberBand.CheckOutOfBounds())
            {
                transform.position = Vector3.Lerp(transform.position, lastValidPosition, Time.deltaTime * 2f);
            }

            doZoom();
        }

        private void doZoom()
        {
            currentZoom = Camera.main.orthographicSize;
            var newZoom = Mathf.Clamp(currentZoom - Input.GetAxis("Mouse ScrollWheel") * CameraDragSpeed / 2, 1, 20);
            Camera.main.orthographicSize = Mathf.Lerp(currentZoom, newZoom, Time.deltaTime * 10f);
        }
    }
}