using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveCamera : MonoBehaviour
{
    /*public void OnMouseDrag()
	{
        //In 2d/UI you can move the object to your mouse position by writing this in a script and then adding it to the object you want to be at the mouse position also put it in the void update spot
        transform.position = Input.mousePosition;

        //or in 3d
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    }*/
    /*private Vector3 Origin;
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
                //Camera.main.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) * 0.2f;
            }

            if (Input.GetMouseButton(1))
                Camera.main.transform.position = ResetCamera;
        }
    }*/

    [SerializeField]
    private Camera cam; //obiekt kamery

    [SerializeField]
    private float zoomStep, minCamSize, maxCamSize; //zakres powiększenia

    [SerializeField]
    //private SpriteRenderer mapRenderer;
    //private float mapMinX, mapMaxX, mapMinY, mapMaxY;

    private Vector3 dragOrigin;


    private void Awake()
    {
        
        /*mapMinX = mapRenderer.transform.position.x - mapRenderer.bounds.size.x / 2f;
        mapMaxX = mapRenderer.transform.position.x + mapRenderer.bounds.size.x / 2f;

        mapMinY = mapRenderer.transform.position.y - mapRenderer.bounds.size.y / 2f;
        mapMaxY = mapRenderer.transform.position.y + mapRenderer.bounds.size.y / 2f;*/
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PanCamera();
    }

    //przesuwanie pozycji kamery (lewo, prawo, góra, dół)
    private void PanCamera()
    {
        if (!DragAndDropObject.objectOnDrag)
        {

            if (Input.GetMouseButtonDown(0))
                dragOrigin = cam.ScreenToWorldPoint(Input.mousePosition);

            if (Input.GetMouseButton(0))
            {
                Vector3 difference = dragOrigin - cam.ScreenToWorldPoint(Input.mousePosition);
                //print("origin " + dragOrigin + " newPosition " + cam.ScreenToWorldPoint(Input.mousePosition) + " =difference" + difference);
                //cam.transform.position += difference; //bez ograniczenia obszaru

                cam.transform.position = ClampCamera(cam.transform.position + difference);   //ograniczenie obszaru

            }
        }

        /*
        if (Input.GetMouseButtonDown(0)) dragOrigin = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.transform.position.z * -1));
        if (Input.GetMouseButton(0))
        {
            Vector3 difference = dragOrigin - cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.transform.position.z * -1));
            Debug.Log("origin " + dragOrigin + " newPosition " + cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.transform.position.z * -1)) + " =difference " + difference);
            cam.transform.position += new Vector3(difference.x, difference.y, 0f);
        }
        */
    }

    public void ZoomIn()
    {
        float newSize = cam.orthographicSize - zoomStep;
        cam.orthographicSize = Mathf.Clamp(newSize, 0, 100);

        cam.transform.position = ClampCamera(cam.transform.position);   //ograniczenie obszaru
    }

    public void ZoomOut()
    {
        float newSize = cam.orthographicSize + zoomStep;
        cam.orthographicSize = Mathf.Clamp(newSize, 0, 100);

        cam.transform.position = ClampCamera(cam.transform.position); //ograniczenie obszaru
    }

    private Vector3 ClampCamera(Vector3 targetPosition)
    {
        float camHeight = cam.orthographicSize;
        float camWidth = cam.orthographicSize * cam.aspect;

        /*float minX = mapMinX + camWidth;
        float maxX = mapMaxX - camWidth;
        float minY = mapMinY + camHeight;
        float maxY = mapMaxY - camHeight;
        */
        float newX = Mathf.Clamp(targetPosition.x, -200, 200);
        float newY = Mathf.Clamp(targetPosition.y, -200, 200);

        return new Vector3(newX, newY, targetPosition.z);
    }
}
