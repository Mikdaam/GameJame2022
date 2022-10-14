using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Supprimer : MonoBehaviour
{
	[SerializeField]
	GameObject objectToDestroy;

	public static GameObject btnDelete = null;
	public void Start()
	{
		gameObject.SetActive(false);
		btnDelete = gameObject;
	}

	public void DestroyGameObject()
	{
		objectToDestroy = DragAndDropObject.CurrentlySelectedGameObject;
		Destroy(objectToDestroy);

		gameObject.SetActive(false);
	}
}
