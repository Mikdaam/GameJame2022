using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    private Vector3 Origin;
    private Vector3 Difference;
    private Vector3 ResetCamera;

    private bool drag = false;

    private Vector3 screenPoint;
    private Vector3 offset;

    private void Start()
    {
        ResetCamera = Camera.main.transform.position;

        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

    }


    private void LateUpdate()
    {
        if (!DragAndDropObject.objectOnDrag)
        {
            if (Input.GetMouseButton(0))
            {
                Difference = (Camera.main.ScreenToWorldPoint(Input.mousePosition)) - Camera.main.transform.position;
                if (drag == false)
                {
                    drag = true;
                    Origin = Camera.main.transform.position;
                }

            }
            else
            {
                drag = false;
            }

            if (drag)
            {
                Camera.main.transform.position = Origin - Difference * 0.5f;
            }

            if (Input.GetMouseButton(1))
                Camera.main.transform.position = ResetCamera;
        }
    }
}
