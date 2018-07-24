using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runningtap
{
    public class CameraClickDrag : MonoBehaviour
    {
        public int cameraDragSpeed = 50;
        float currentZoom;
        bool isDragging;
        CameraRubberBand rubberBand;
        Vector3 lastValidPosition;

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

            if (Input.GetMouseButton(1))
            {
                isDragging = true;
            }
            else
            {
                isDragging = false;
            }
        }

        void doZoom()
        {
            currentZoom = Camera.main.orthographicSize;
            var newZoom = Mathf.Clamp(currentZoom - Input.GetAxis("Mouse ScrollWheel") * cameraDragSpeed / 2, 1, 20);
            Camera.main.orthographicSize = Mathf.Lerp(currentZoom, newZoom, Time.deltaTime * 10f);
        }

        private void LateUpdate()
        {
            if(isDragging)
            {
                float speed = cameraDragSpeed * Time.deltaTime;
                transform.position -= new Vector3(Input.GetAxis("Mouse X") * speed, Input.GetAxis("Mouse Y") * speed, 0f);
            }
            else if(rubberBand.CheckOutOfBounds())
            {
                transform.position = Vector3.Lerp(transform.position, lastValidPosition, Time.deltaTime * 2f);
            }

            doZoom();
        }
    }
}