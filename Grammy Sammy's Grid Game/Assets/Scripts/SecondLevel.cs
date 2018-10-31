using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondLevel : MonoBehaviour {

	public string[,] levelMap;
	
	public GameObject wall;
	public GameObject box;
	public GameObject player;
	public GameObject goal;
	public GameObject blankSpot;
	
	public int row;
	public int col;
	
	// Use this for initialization
	void Start ()
	{

		row = 10;
		col = 9; 
		
		levelMap = new string[,]
		{
			{" ", " ", " ", "#", "#", "#", "#", "#", "#"},
			{" ", " ", " ", "#", " ", " ", "0", "0", "#"},
			{"#", "#", "#", "#", "b", " ", "0", "0", "#"},
			{"#", " ", " ", "#", " ", "#", "b", " ", "#"},
			{"#", " ", "b", "#", " ", "b", " ", " ", "#"},
			{"#", " ", " ", " ", " ", "#", " ", " ", "#"},
			{"#", " ", "p", "#", " ", "#", "#", " ", "#"},
			{"#", " ", " ", " ", " ", " ", " ", " ", "#"},
			{"#", "#", "#", "#", "#", "#", " ", " ", "#"},
			{" ", " ", " ", " ", " ", "#", "#", "#", "#"}			
		};
		
		
		for (int i = 0; i < row; i++)
		{
			//Debug.Log("i = " + i);

			for (int j = 0; j < col; j++)
			{
				//Debug.Log(levelMap[i, j]);
				if (levelMap[i, j] == "#")
				{
					Instantiate(wall, new Vector3(i + 0.5f, j + 0.5f, 0), Quaternion.identity);
				}
				else if (levelMap[i, j] == "b")
				{
					Instantiate(box, new Vector3(i + 0.5f, j + 0.5f, 0), Quaternion.identity);
				}
				else if (levelMap[i, j] == "p")
				{
					Instantiate(player, new Vector3(i + 0.5f, j + 0.5f, 0), Quaternion.identity);
				}
				else if (levelMap[i, j] == "0")
				{
					Instantiate(goal, new Vector3(i + 0.5f, j + 0.5f, 0), Quaternion.identity);
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
