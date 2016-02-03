using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class EquationController : MonoBehaviour 
{
	public Transform cfPrefab;
	public List<Transform> fabList = new List<Transform>();
	// Use this for initialization
	void Start () 
	{
		
	}

	public void addFormula(ElementController.ChemicalEquation temp)
	{
		for (int i = 0; i < temp.Formulas.Count; i++)
		{
			fabList.Add(Instantiate(cfPrefab, transform.position, transform.rotation) as Transform);
			fabList[i].SetParent(this.transform);
			fabList[i].localScale = new Vector3(1, 1, 1);
			fabList[i].gameObject.GetComponent<Text>().text = temp.Formulas[i].displayName;
			fabList[i].name = i.ToString();
		}
	}
}
