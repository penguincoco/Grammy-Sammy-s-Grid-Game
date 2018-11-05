using System;
using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.UIElements.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{

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

	private Scene currentScene;
	private string curSceneName;
	public string[,] levelMap;
	private string levelStr;

	private GameObject[] goalZones;
	private int numberOfGoalZones;

	private GameObject[] boxes;

	private float timeToChange;


	[HideInInspector]public int goalsInPlace;

	public GameObject playerObj;

	public bool allGoalsIn;

	public Text displayMoves; 

	// Use this for initialization
	void Start()
	{
		allGoalsIn = false; 
		goalsInPlace = 0;
		timeToChange = 5f;
		
		numberOfGoalZones = 0;

		currentScene = SceneManager.GetActiveScene();
		curSceneName = currentScene.name;

		if (curSceneName.Equals("Level1"))
		{
			levelMap = new string[,]
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

			row = 9;
			col = 9;
		}
		else if (curSceneName.Equals("Level2"))
		{
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
			
			row = 10;
			col = 9; 
		}

		Debug.Log(row);
		Debug.Log(col);
		
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
					Instantiate(goal, new Vector3(i + 0.5f, j + 0.5f, 1), Quaternion.identity);
				}
			}
		}

		goalZones = GameObject.FindGameObjectsWithTag("Goal");
		//Debug.Log(goalZones.Length);

		timeToChange = 5f;
		
		playerObj = GameObject.FindGameObjectWithTag("Player");

		boxes = GameObject.FindGameObjectsWithTag("Box");
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKey(KeyCode.Alpha1))
		{
			//Debug.Log("Restarting the level");
			SceneManager.LoadScene("Level1");
		}
		
		if (Input.GetKey(KeyCode.Alpha2))
        		{
        			//Debug.Log("Restarting the level");
        			SceneManager.LoadScene("Level2");
        		}

		if (Input.GetKey(KeyCode.Alpha0))
		{
			//Debug.Log("Restarting the level");
			SceneManager.LoadScene("MainMenu");
		}

//		if (MapCompleted())
//		{
//			SceneManager.LoadScene("GameOver");
//		}
		MapCompleted();
		displayMoves.text = playerObj.GetComponent<NewPlayerController>().steps.ToString();

//		if (playerObj.GetComponent<NewPlayerController>().steps >= 100)
//		{
//			SceneManager.LoadScene("GameOver");
//		}
	}

	void MapCompleted()
	{
		if (goalsInPlace == boxes.Length)
		{
			Debug.Log(timeToChange);
			Debug.Log("All goals in place");
			timeToChange -= Time.deltaTime;
			if (timeToChange <= 0)
			{
				SceneManager.LoadScene("MainMenu");
			}
		}
	}
	
//	bool MapCompleted()
//	{
//		for (int i = 0; i < goalZones.Length; i++)
//		{
//			if (goalZones[i].GetComponent<GoalZone>().getGoalStatus())
//			{
//				allGoalsIn = true;
//			}
//			else if (!goalZones[i].GetComponent<GoalZone>().getGoalStatus())
//			{
//				allGoalsIn = false; 
//			}
//			Debug.Log(i.ToString() + allGoalsIn);
//		}
//		
//		return allGoalsIn; 
//	}
	
}


