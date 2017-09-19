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

	public int rows;

	public int columns;

	public int[,] gemList;

	public GameObject[] gemObjects = new GameObject[4];

	//	public Grid (int row, int col)
	//	{
	//		rows = row;
	//		columns = col;
	//		gemList = new int[row, col];
	//		gemObjects = new List<GameObject> ();
	//
	//		gemObjects.Add (red);
	//		gemObjects.Add (blue);
	//		gemObjects.Add (green);
	//		gemObjects.Add (yellow);
	//
	//
	//
	//	}

	public void Initializer (int row, int col)
	{	
		//which takes the number of columns and rows
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
				gemList [i, k] = Random.Range (0, 4);

			}
		}

				
		//Handles filling in random fruit

	}

	public void ReadList ()
	{
		for (int i = 0; i < rows; i++)
		{
			for (int k = 0; k < columns; k++)
			{
				Debug.Log ("Gemlist Column " + i + " Row " + k + ": " + gemList [i, k]);
			}
		}
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
					Debug.Log ("You hit the " + hit.collider.name + " fruit" +
					" at " + hit.collider.gameObject.transform.position.x + "," + hit.collider.gameObject.transform.position.y);

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
					Debug.Log ("The space at " + i + " , " + k + " is empty");
					SlideDown (i , k);
				}
			}
		}
	}

	void SlideDown (int row, int col)
	{
		Vector3 replacement = new Vector3 (row, col + 1, 0);

		for (int i = 0; i < rows; i++)
		{
			for (int k = 0; k < columns; k++)
			{
				for(int l = 0; l < gemObjects.Length; l++)
				{
					Debug.Log (gemObjects [l].transform.position);
					if (gemObjects[l].transform.position == replacement)
					{
						Debug.Log ("DO IT ");

						gemObjects [l].transform.position = new Vector3 (row, col);
					}
				}
			}

		}
		//Pass the grid location to slide the items down, setting the top empty value to a fruit number.

	}

}
