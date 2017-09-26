using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

	public Grid grid;

	public Text scoreText;

	public Text screenPath;

	public int score = 0;

	public int captureCounter = 1;

	void Start ()
	{	
		GenerateGrid ();

		screenPath.text = "Screenshot saved at " + Application.persistentDataPath + "";

		screenPath.enabled = false;
	}
		
	void GenerateGrid ()
	{
		score = 0;

		grid.Initializer (10, 10);
		grid.Populate ();
		grid.Render ();
	}

	void Update ()
	{

		if (grid.Touch () == true)
		{
			score += 100;
			scoreText.text = "Score: " + score;

			grid.checkListForEmpties ();
			grid.RePopulate ();


		}

		if (Input.GetMouseButtonDown (1))
		{
			Application.CaptureScreenshot ("ClickingSimulator_" + captureCounter++ +".png");
			StartCoroutine (ShowText());
		}

			
	}

	void LateUpdate()
	{
		grid.Render ();

	}

	IEnumerator ShowText()
	{
		screenPath.enabled = true;
		yield return new WaitForSeconds (3f);
		screenPath.enabled = false;


	}
}
