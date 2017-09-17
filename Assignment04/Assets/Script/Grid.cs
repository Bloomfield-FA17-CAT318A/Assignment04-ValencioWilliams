using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{

//	public enum Gems
//	{
//		RED = 0,
//		BLUE = 1,
//		GREEN = 2,
//		YELLOW = 3}
//
//	;

	public int rows;

	public int columns;

	//public Gems gem;
	//public int gemInt;

	public int[,] gemList;

	public List<GameObject> gemObjects;

	public GameObject red, blue, green, yellow;

	public Grid (int row, int col)
	{
		rows = row;
		columns = col;
		gemList = new int[row, col];
		gemObjects = new List<GameObject> ();

		gemObjects.Add (red);
		gemObjects.Add (blue);
		gemObjects.Add (green);
		gemObjects.Add (yellow);


	
	}

	public void Initializer (int row, int col)
	{	
		//which takes the number of columns and rows

	}

	public void Populate ()
	{
		Debug.Log ("Populate");

		for (int i = 0; i < rows; i++)
		{
			for (int k = 0; k < gemList.GetLength (0); k++)
			{
				gemList [i, k] = Random.Range (0, 4);

			}
		}

				
		//Handles filling in random fruit

	}

	public void Render ()
	{
		Debug.Log ("Render");

		for (int i = 0; i < rows; i++)
		{

			Debug.Log ("Row " + i +" Start");

			for (int k = 0; k < columns; k++)
			{

				Debug.Log ("Column " + k +" Start");

				Debug.Log ("GemCount is  " + gemObjects.Count);

				for(int l = 0; l < gemObjects.Count; l++)
				{

					Debug.Log ("Indexer "+ l +" Start");

					if (gemList [i, k] == l && gemObjects[l] != null)
					{

						Debug.Log ("INSTANTIATE");
						GameObject.Instantiate (gemObjects[l], new Vector3 (i,k,0) ,Quaternion.identity);
					}

				}
					
			}

		}

		//Loop through the array and add new game items to the world in the grid. It will convert the Grid location to Unity coordinates.
		//Focus on looping through the array. If you can't get it to place actual object, make sure you can convert the position. 
		//If you want to render objects, but don't feel like finding images, you can use a different 3D shape.

	}

	void Touch ()
	{
		//Convert the Unity coordinates to the grid location.
	}


	void SlideDown ()
	{
		//Pass the grid location to slide the items down, setting the top empty value to a fruit number.

	}

}
