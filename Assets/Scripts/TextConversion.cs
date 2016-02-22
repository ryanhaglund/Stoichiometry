using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class TextConversion : MonoBehaviour 
{
	public List<string> options = new List<string>();
	public string field;
	int index = 0;

	public Text textVariable;

	// Use this for initialization
	void Start () 
	{
		textVariable.text = options[index];
	}

	public void Up()
	{
		if(index < options.Count - 1)
		{
			index ++;
		}
		else
		{
			index = 0;
		}
		textVariable.text = options[index];
	}

	public void Down()
	{
		if(index > 0)
		{
			index --;
		}
		else
		{
			index = options.Count -1;
		}
		textVariable.text = options[index];
	}

	public void Submit()
	{
		PlayerPrefs.SetString (field, options[index]);
	}
} 