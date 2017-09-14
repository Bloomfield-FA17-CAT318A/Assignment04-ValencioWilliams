using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {

	public enum fruit
	{
		APPLE,
		ORANGE,
		BANANA,
		LEMON
	};

	public fruit[] FRUITS = new fruit[4,4];

	void Start () {
		
	}
	
	void Update () {
		
	}

	void Initializer(int rows, int column)
	{
		//which takes the number of columns and rows

	}

	void Populate(int rows, int column)
	{
		//Handles filling in random fruit

	}

	void Render()
	{
		//Loop through the array and add new game items to the world in the grid. It will convert the Grid location to Unity coordinates. Focus on looping through the array. If you can't get it to place actual object, make sure you can convert the position. If you want to render objects, but don't feel like finding images, you can use a different 3D shape.

	}

	void Touch()
	{
		//Convert the Unity coordinates to the grid location.

	}


	void SlideDown()
	{
		//Pass the grid location to slide the items down, setting the top empty value to a fruit number.

	}


}
