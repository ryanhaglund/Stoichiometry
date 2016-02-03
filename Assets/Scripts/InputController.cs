using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InputController : MonoBehaviour 
{
	public void solveWithGrams()
	{
		if (this.GetComponent<InputField>().text == "")
		{
			Debug.Log("Empty Entry");
		}
		else
		{
			for (int i = 0; i < GameObject.Find("ChemicalEquation").GetComponent<EquationController>().fabList.Count; i++)
			{
				if (GameObject.Find("ChemicalEquation").GetComponent<EquationController>().fabList[i] == this.transform.parent)
				{
					GameObject.Find("Canvas").GetComponent<ElementController>().solveWithGrams(i, float.Parse(this.GetComponent<InputField>().text));
				}
			}
		}
	}

	public void solveWithMoles()
	{
		if (this.GetComponent<InputField>().text == "")
		{
			Debug.Log("Empty Entry");
		}
		else
		{
			for (int i = 0; i < GameObject.Find("ChemicalEquation").GetComponent<EquationController>().fabList.Count; i++)
			{
				if (GameObject.Find("ChemicalEquation").GetComponent<EquationController>().fabList[i] == this.transform.parent)
				{
					GameObject.Find("Canvas").GetComponent<ElementController>().solveWithMoles(i, float.Parse(this.GetComponent<InputField>().text));
				}
			}
		}
	}

	public void solveWithAtoms()
	{
		if (this.GetComponent<InputField>().text == "")
		{
			Debug.Log("Empty Entry");
		}
		else
		{
			for (int i = 0; i < GameObject.Find("ChemicalEquation").GetComponent<EquationController>().fabList.Count; i++)
			{
				if (GameObject.Find("ChemicalEquation").GetComponent<EquationController>().fabList[i] == this.transform.parent)
				{
					GameObject.Find("Canvas").GetComponent<ElementController>().solveWithAtoms(i, float.Parse(this.GetComponent<InputField>().text));
				}
			}
		}
	}

	public void solveWithLitersOfGas()
	{
		if (this.GetComponent<InputField>().text == "")
		{
			Debug.Log("Empty Entry");
		}
		else
		{
			for (int i = 0; i < GameObject.Find("ChemicalEquation").GetComponent<EquationController>().fabList.Count; i++)
			{
				if (GameObject.Find("ChemicalEquation").GetComponent<EquationController>().fabList[i] == this.transform.parent)
				{
					GameObject.Find("Canvas").GetComponent<ElementController>().solveWithLitersOfGas(i, float.Parse(this.GetComponent<InputField>().text));
				}
			}
		}
	}
}
