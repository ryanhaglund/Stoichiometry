using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Dragable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler 
{
	public Transform currentParent = null;
	public Transform transferTransform;

	void Start()
	{
		transferTransform = GameObject.Find("Canvas").transform;
	}

	public void OnBeginDrag (PointerEventData eventData)
	{
		//Debug.Log("begin dragging");
		currentParent = this.transform.parent;
		this.transform.SetParent(transferTransform);
		GetComponent<CanvasGroup>().blocksRaycasts = false;
	}

	public void OnDrag(PointerEventData eventData)
	{
		//Debug.Log("Dragging");
		this.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(eventData.position).x, Camera.main.ScreenToWorldPoint(eventData.position).y, 10);
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		//Debug.Log("End dragging");
		this.transform.SetParent(currentParent);
		GetComponent<CanvasGroup>().blocksRaycasts = true;
	}
}
