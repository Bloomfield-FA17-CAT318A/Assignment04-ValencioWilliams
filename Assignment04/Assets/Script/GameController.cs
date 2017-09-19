using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

	public Grid grid;

	public Text scoreText;

	public int score = 0;


	void Start ()
	{	
		GenerateGrid ();
	}

	void GenerateGrid ()
	{
		score = 0;

		grid.Initializer (10, 10);
		grid.Populate ();
		grid.Render ();
		grid.ReadList ();
	}

	void Update ()
	{
		if (grid.Touch () == true)
		{
			score += 100;
			scoreText.text = "Score: " + score;
			grid.checkListForEmpties ();

		}
			
	}
}
