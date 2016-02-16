using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class VariableManipulator : MonoBehaviour 
{

	public int multiple;
	public Text numeral;

	// Use this for initialization
	void Start () 
	{
		multiple = 0;
		SetMultiple();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void Up()
	{
		multiple ++;
		SetMultiple();
		TriggerAnimation ();
	}


	public void Down()
	{
		if(multiple > 0)
		{
			multiple --;
			TriggerAnimation ();
		}
		SetMultiple();
	}

	public void SetMultiple()
	{
		numeral.text = multiple.ToString();
	}

	public void TriggerAnimation()
	{
		if(numeral.GetComponent<Animator>())
		{
			numeral.GetComponent<Animator> ().SetTrigger ("switch");
		}
	}
}
