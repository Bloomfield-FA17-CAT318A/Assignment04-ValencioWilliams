using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{

	public enum Gems
	{
		RED = 0,
		BLUE = 1,
		GREEN = 2,
		YELLOW = 3}

	;

	public Gems gem;

	public int numOfGems;

	public int rows;

	public int columns;

	public int[,] gemList;

	public GameObject[] gemObjects = new GameObject[4];

	public int count = 0;

	public void Initializer (int row, int col)
	{	
		//which takes the number of columns and rows

		numOfGems = System.Enum.GetValues (typeof(Gems)).Length;
		rows = row;
		columns = col;
		gemList = new int[row, col];
	}

	public void Populate ()
	{
		for (int i = 0; i < rows; i++)
		{
			for (int k = 0; k < columns; k++)
			{
				gemList [i, k] = Random.Range (0, numOfGems);
				
			}
		}
		//Handles filling in random fruit
	}

	public void RePopulate ()
	{
		for (int i = 0; i < rows; i++)
		{
			for (int k = 0; k < columns; k++)
			{
				if (gemList [i, k] == -1)
				{
					gemList [i, k] = Random.Range (0, numOfGems);
				}
			}
		}
		//Handles filling in random fruit
	}

	public void Render ()
	{
		for (int i = 0; i < rows; i++)
		{
			for (int k = 0; k < columns; k++)
			{
				for (int l = 0; l < gemObjects.Length; l++)
				{
					if (gemList [i, k] == l)
					{
						GameObject obj = Instantiate (gemObjects [l], new Vector3 (i, k, 0), Quaternion.identity, transform);

						obj.tag = "Fruit";	
					}

				}
					
			}

		}

		//Loop through the array and add new game items to the world in the grid. It will convert the Grid location to Unity coordinates.
		//Focus on looping through the array. If you can't get it to place actual object, make sure you can convert the position. 
		//If you want to render objects, but don't feel like finding images, you can use a different 3D shape.

	}

	public bool Touch ()
	{
		if (Input.GetMouseButtonDown (0))
		{
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

			if (Physics.Raycast (ray, out hit))
			{
				if (hit.transform.tag == "Fruit")
				{
					Destroy (hit.collider.gameObject);
					gemList [(int)hit.collider.gameObject.transform.position.x, (int)hit.collider.gameObject.transform.position.y] = -1;

					return true;
				}
			}
		}

		return false;

		//Convert the Unity coordinates to the grid location.
	}

	public void checkListForEmpties ()
	{
		for (int i = 0; i < rows; i++)
		{
			for (int k = 0; k < columns; k++)
			{
				if (gemList [i, k] == -1)
				{
					count = 0;
					SlideDown (i, k);

				}
			}
		}

	}

	void SlideDown (int emptyRow, int emptyCol)
	{
		DeRender ();

		for (int start = emptyCol; start < gemList.GetLength (0) - 1; start++)
		{
			if (gemList [emptyRow, start] == -1)
			{
				count++;

			}
		}

		for (int i = 0; i < count; i++)
		{
			Debug.Log ("Swapping!!!");

			gemList [emptyRow, emptyCol] = gemList [emptyRow, emptyCol + 1];
			gemList [emptyRow, emptyCol + 1] = -1;


		}
	
		//Pass the grid location to slide the items down, setting the top empty value to a fruit number.
	}

	void DeRender ()
	{
		GameObject[] objs = GameObject.FindGameObjectsWithTag ("Fruit");

		foreach (GameObject obj in objs)
		{
			Destroy (obj);
		}
	}


}