using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem : MonoBehaviour {

	Grid grid; // = new Grid(10,10);

	void Start()
	{
		grid = new Grid (10, 10);

		GenerateGrid ();
		//GenerateMyGrid ();
	}

	void GenerateGrid()
	{
		grid.Initializer (10,10);
		grid.Populate ();
		grid.Render ();

	}
}
