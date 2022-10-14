using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    private Camera cam;
    private float targetZoom;
	private float zoomFactor = 3f;
    [SerializeField] private float zoomLerpSpeed = 10;
    public float zoomMax;
    public float zoomMin;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        targetZoom = cam.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        float scrollData;
        scrollData = Input.GetAxis("Mouse ScrollWheel");
        //Debug.Log(scrollData);
        targetZoom = targetZoom - scrollData * zoomFactor;
        targetZoom = Mathf.Clamp(targetZoom, zoomMax, zoomMin);
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetZoom, Time.deltaTime * zoomLerpSpeed);
    }
}
