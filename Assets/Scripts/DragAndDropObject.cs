using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDropObject : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;
    public GameObject objet;

    public static GameObject CurrentlySelectedGameObject = null;
    public static bool objectOnDrag = false;

    void OnMouseDown()
    {
        objectOnDrag = true;
        screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    private Camera mainCamera;
    private float CameraZDistance;

    void OnMouseDrag()
    {
        objectOnDrag = true;
        Supprimer.btnDelete.SetActive(true);

        CurrentlySelectedGameObject = gameObject;

        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        curPosition.x = Mathf.Round(curPosition.x*0.125f)/0.125f;
        curPosition.y = Mathf.Round(curPosition.y*0.125f)/0.125f;
        curPosition.z = transform.position.z;
        transform.position = curPosition;

        foreach (GameObject objet in GameObject.FindGameObjectsWithTag("object"))
        {
            if (transform.position.x == objet.transform.position.x && transform.position.y == objet.transform.position.y && objet != gameObject)
            {
                curPosition.x = (Mathf.Round(curPosition.x*0.125f)/0.125f) + (gameObject.transform.localScale.x*8f);
                gameObject.transform.position = curPosition;
            }
        }

        // Rotate
        if (Input.GetButtonDown("Jump"))
        {
            if (gameObject != null)
            {
                transform.Rotate(0, 90, 0);
            }
        }
    }

    private void OnMouseUp()
    {
        objectOnDrag = false;
    }
}