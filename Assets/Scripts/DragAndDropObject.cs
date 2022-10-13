using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDropObject : MonoBehaviour
{
    private Vector3 dragPosition;
    private Vector3 screenPoint;
    private Vector3 offset;
    public GameObject objet;

    public static GameObject CurrentlySelectedGameObject = null;

    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    private Camera mainCamera;
    private float CameraZDistance;

    void OnMouseDrag()
    {
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
            if (transform.position == objet.transform.position && objet != gameObject)
            {
                //screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
                offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
                curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

                curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
                curPosition.x = (Mathf.Round(curPosition.x*0.125f)/0.125f) + (gameObject.transform.localScale.x*8f);
                curPosition.y = (Mathf.Round(curPosition.y*0.125f)/0.125f);
                curPosition.z = gameObject.transform.position.z;
                gameObject.transform.position = curPosition;
            }
        }
    }
}
