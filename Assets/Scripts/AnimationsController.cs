using UnityEngine;
using System.Collections;

public class AnimationsController : MonoBehaviour 
{
	public Animator variableTab;
	public Animator puzzlePanel;
	public Animator selectionPanel;

	public void slideVariableTabIn()
	{
		variableTab.SetTrigger("slideIn");
	}

	public void slideVaribaleTabOut()
	{
		variableTab.SetTrigger("slideOut");
	}

	public void slidePuzzlePanelIn()
	{
		puzzlePanel.SetTrigger("SlideIn");
	}

	public void slidePuzzlePanelOut()
	{
		puzzlePanel.SetTrigger("SlideOut");
	}

	public void slideSelectionPanelIn()
	{
		selectionPanel.SetTrigger("SlideIn");
	}

	public void slideSelectionPanelOut()
	{
		selectionPanel.SetTrigger("SlideOut");
	}
}
