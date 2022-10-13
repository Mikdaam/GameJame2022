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
    private void Start()
	{
	}

	void OnMouseDown()
    {
        objectOnDrag = true;
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        objectOnDrag = true;
        Supprimer.btnDelete.SetActive(true);
       
        CurrentlySelectedGameObject = gameObject;
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        curPosition.x = Mathf.Round(curPosition.x);
        curPosition.y = Mathf.Round(curPosition.y);
        curPosition.z = transform.position.z;
        transform.position = curPosition;

        foreach (GameObject objet in GameObject.FindGameObjectsWithTag("object"))
        {
            if (transform.position == objet.transform.position && objet != gameObject)
            {
                offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
                curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
                curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
                curPosition.x = Mathf.Round(curPosition.x) + gameObject.transform.localScale.x;
                curPosition.y = Mathf.Round(curPosition.y);
                curPosition.z = gameObject.transform.position.z;
                gameObject.transform.position = curPosition;
            }
        }

    }

	private void OnMouseUp()
	{
        objectOnDrag = false;
	}

	void Update()
    {
        
    }
}
