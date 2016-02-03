using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
	public void OnPointerEnter(PointerEventData eventData)
	{
		
	}

	public void OnDrop(PointerEventData eventData)
	{
		Debug.Log("drop on " + gameObject.name);
		eventData.pointerDrag.GetComponent<Dragable>().currentParent = this.transform;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		
	}
}
