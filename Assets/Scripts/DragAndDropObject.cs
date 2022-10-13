using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDropObject : MonoBehaviour
{
    private Vector3 dragPosition;
    private Vector3 screenPoint;
    private Vector3 offset;

    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        
    }

    private Camera mainCamera;
    private float CameraZDistance;

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        curPosition.x = Mathf.Round(curPosition.x);
        curPosition.y = Mathf.Round(curPosition.y);
        curPosition.z = transform.position.z;
        transform.position = curPosition;
    }

    void OnMouseExit()
    {
        foreach (GameObject objet in GameObject.FindGameObjectsWithTag("object"))
        {
            if (transform.position == objet.transform.position && objet != gameObject)
            {
                Debug.Log("CA MARCHE");
            }
        }
    }
}
