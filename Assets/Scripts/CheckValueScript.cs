using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class CheckValueScript : MonoBehaviour 
{
	public List<int> numbers = new List<int>();
	public List<ElementController.ChemicalFormula> elements = new List<ElementController.ChemicalFormula>();
	public List<string> operators = new List<string>();

	public Text twoXtwoLeft1;
	public Text twoXtwoLeft2;
	public Text twoXtwoRight1;
	public Text twoXtwoRight2;

	public Text twoXtwoLeft1Formula;
	public Text twoXtwoLeft2Formula;
	public Text twoXtwoRight1Formula;
	public Text twoXtwoRight2Formula;

	public GameObject left1;
	public GameObject left2;
	public GameObject right1;
	public GameObject right2;

	public bool correct;


	// Use this for initialization
	void Start () 
	{
		correct = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void ResetArrays()
	{
		numbers.Clear();
		elements.Clear();
	}

	public void UpdateValues()
	{
		// update equation values and set ui accordingly
		if(operators.Count > 0)
		{
			// 3 operators 2 plus signs and the equal
			if(operators.Count == 3)
			{
				twoXtwoLeft1Formula.text = elements[0].displayName;
				twoXtwoLeft2Formula.text = elements[1].displayName;
				twoXtwoRight1Formula.text = elements[2].displayName;
				twoXtwoRight2Formula.text = elements[3].displayName;
			}
			//2 operators plus sign and equal
			else if(operators.Count == 2)
			{
				// a + b -> c
				if(operators[0] == " + ")
				{
					right2.SetActive(false);

					twoXtwoLeft1Formula.text = elements[0].displayName;
					twoXtwoLeft2Formula.text = elements[1].displayName;
					twoXtwoRight1Formula.text = elements[2].displayName;

				}
				//a -> b + c
				else
				{
					Debug.Log(operators[0]);
					left1.SetActive(false);

					twoXtwoLeft2Formula.text = elements[0].displayName;
					twoXtwoRight1Formula.text = elements[1].displayName;
					twoXtwoRight2Formula.text = elements[2].displayName;
				}
			}
			//single operator
			else
			{
				right2.SetActive(false);
				left1.SetActive(false);

				twoXtwoLeft2Formula.text = elements[0].displayName;
				twoXtwoRight1Formula.text = elements[1].displayName;
			}
		}
	}

	public void Submit()
	{
		List<int> userSelected = new List<int>();

		if(left1.activeSelf)
		{
			userSelected.Add(int.Parse(twoXtwoLeft1.text));
			Debug.Log(userSelected[0]);
		}
		userSelected.Add(int.Parse(twoXtwoLeft2.text));
		userSelected.Add(int.Parse(twoXtwoRight1.text));
		if(right2.activeSelf)
		{
			userSelected.Add(int.Parse(twoXtwoRight2.text));
		}

		if(userSelected.Count != numbers.Count)
		{
			correct = false;
		}
		else
		{
			for(int i = 0; i < numbers.Count; i++)
			{
				if(userSelected[i] == numbers[i])
				{
					correct = true;
				}
				else
				{
					correct = false;
					break;
				}
			}
			if (correct == true)
			{
				GetComponent<AnimationsController>().slideVaribaleTabOut();
				if(operators.Count > 0)
				{
					// 3 operators 2 plus signs and the equal
					if (operators.Count == 3)
					{
						GetComponent<ElementController>().setUpDragGame((float)System.Math.Round((Random.Range(0.50f, 10.00f)),2), PlayerPrefs.GetString("convertFrom"), elements[Random.Range(0,2)], elements[Random.Range(2,4)], PlayerPrefs.GetString("convertFrom"), PlayerPrefs.GetString("convertTo"));
					}
					//2 operators plus sign and equal
					else if(operators.Count == 2)
					{
						// a + b -> c
						if(operators[0] == " + ")
						{
							GetComponent<ElementController>().setUpDragGame((float)System.Math.Round((Random.Range(0.50f, 10.00f)),2), PlayerPrefs.GetString("convertFrom"), elements[Random.Range(0,2)], elements[2], PlayerPrefs.GetString("convertFrom"), PlayerPrefs.GetString("convertTo"));
						}
						//a -> b + c
						else
						{
							GetComponent<ElementController>().setUpDragGame((float)System.Math.Round((Random.Range(0.50f, 10.00f)),2), PlayerPrefs.GetString("convertFrom"), elements[0], elements[Random.Range(1,3)], PlayerPrefs.GetString("convertFrom"), PlayerPrefs.GetString("convertTo"));
						}
					}
					//single operator
					else
					{
					}
				}
			}
		}
	}


}
