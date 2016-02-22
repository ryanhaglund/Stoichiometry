using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
	public ElementController elmCont;

	public void OnPointerEnter(PointerEventData eventData)
	{
		
	}

	public void OnDrop(PointerEventData eventData)
	{
		Debug.Log("drop on " + gameObject.name);
		eventData.pointerDrag.GetComponent<Dragable>().currentParent = this.transform;
		Debug.Log(eventData.pointerDrag.GetComponent<Dragable>().currentParent.name);
		eventData.pointerDrag.GetComponent<Dragable>().doStuf();

		//if (this.transform.name != "Selection Panel")
		//{
			elmCont.calcTableResults();
		//}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		
	}

	public void calculateStuff()
	{
		//if (this.transform.name != "Selection Panel")
		//{
			elmCont.calcTableResults();
		//}
	}
}
