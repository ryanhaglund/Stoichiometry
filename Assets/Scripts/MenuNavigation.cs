using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuNavigation : MonoBehaviour 
{
	void loadPractice()
	{
		SceneManager.LoadScene("CalculatorScene");
	}

	void loadPlay()
	{
		SceneManager.LoadScene("FillInTheBlanks");
	}

	void loadMainMenu()
	{
		SceneManager.LoadScene("MainMenu");
	}
}
