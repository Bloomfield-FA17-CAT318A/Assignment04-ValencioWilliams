using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{

	public Canvas startScreen;
	public Canvas instructions;

	void Start ()
	{
		GoToStart ();
	}
		
	public void GoToStart ()
	{
		startScreen.enabled = true;
		instructions.enabled = false;

	}

	public void GoToInstructions()
	{
		instructions.enabled = true;
		startScreen.enabled = false;

	}

	public void GoToGame()
	{
		SceneManager.LoadScene ("Game");
	}
}
