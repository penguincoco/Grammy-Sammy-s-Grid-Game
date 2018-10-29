using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.UIElements.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstLevel : MonoBehaviour {

	//This is what will display level 1
	//map a 2D matrix
	//based on what is living on a certain index, spawn that. 
	//So, for example, if there's an x in [row][column], instantiate a box at that location.

	/*
	 * Key
	 * "#" = brick/wall
	 * "b" = box
	 * "p" =  player
	 * "0" = goal
	 * " " = blank spot
	 */

	public GameObject wall;
	public GameObject box;
	public GameObject player;
	public GameObject goal;
	public GameObject blankSpot;

	public int row;
	public int col;

	public string[,] levelMap; //rows first, then inner array is column

	private GameObject[] goalZones;
	private int numberOfGoalZones;

	private float timeToChange;

	private int goalsInPlace;
	
	// Use this for initialization
	void Start ()
	{
		goalsInPlace = 0;
		timeToChange = 5f;
		row = 9;
		col = 9;
		numberOfGoalZones = 0;
		
		levelMap = new string[,]
//		{
//			{"#", "#", "#", "#", "#", " ", " ", " ", " "},
//			{"#", " ", " ", " ", "#", " ", " ", " ", " "},
//			{"#", " ", "p", " ", "#", " ", "#", "#", "#"},
//			{"#", " ", " ", " ", "#", " ", "#", "0", "#"},
//			{"#", "#", "#", " ", "#", "#", "#", "0", "#"},
//			{" ", "#", "#", " ", " ", " ", " ", "0", "#"},
//			{" ", "#", " ", " ", " ", "#", " ", " ", "#"},
//			{" ", "#", " ", " ", " ", "#", "#", "#", "#"},
//			{" ", "#", "#", "#", "#", "#", " ", " ", "#"},
//		};
		
		{
			{" ", " ", " ", " ", "#", "#", "#", "#", "#"},
			{"#", "#", "#", "#", "#", " ", " ", "p", "#"},
			{"#", " ", " ", "#", "#", "b", "b", " ", "#"},
			{"#", " ", " ", " ", " ", " ", "b", " ", "#"},
			{"#", " ", " ", " ", "#", "#", "#", "#", "#"},
			{"#", "#", "#", " ", "#", " ", " ", " ", " "},
			{" ", "#", " ", " ", "#", "#", "#", " ", " "},
			{" ", "#", " ", "0", "0", "0", "#", " ", " "},
			{" ", "#", "#", "#", "#", "#", "#", " ", " "}
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

		goalZones = GameObject.FindGameObjectsWithTag("Goal");
		Debug.Log(goalZones.Length);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Alpha1))
		{
			Debug.Log("Restarting the level");
			SceneManager.LoadScene("Level1");
		}

		MapCompleted();
	}

	void MapCompleted()
	{
		Debug.Log("Running Map Completed");
		//check to see if any goals have an object in them.
		foreach (GameObject goalZone in goalZones)
		{
			Debug.Log("checking the goals");
			if (goalZone.GetComponent<GoalZone>().GetGoalStatus())
			{
				Debug.Log(goalsInPlace);
				goalsInPlace++;
			}
		}

		//Debug.Log(goalsInPlace);
		//if all three goals are filled, game over. 		
		if (goalsInPlace == 3)
		{
			timeToChange -= Time.deltaTime;
			Debug.Log("All goals in place");
			SceneManager.LoadScene("MainMenu");
		}
	}
}
