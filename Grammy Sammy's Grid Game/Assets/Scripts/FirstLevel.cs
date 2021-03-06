﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
//using UnityEditor.Experimental.UIElements.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FirstLevel : MonoBehaviour
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

	public string[,] levelMap; //2D array of Strings for spawning the map
	public GameObject[,] levelObjs; //2D array of GAMEOBJECTS for storing POSITIONS

	private GameObject[] goalZones;
	private int numberOfGoalZones;
	private GameObject goalOne;
	private GameObject goalTwo;
	private GameObject goalThree;

	private GameObject[] boxes;
	private GameObject boxOne;
	private GameObject boxTwo;
	private GameObject boxThree;


	private float timeToChange;

	private bool goalOneIn;
	private bool goalTwoIn;
	private bool goalThreeIn;

	public GameObject playerObj;
	public String stepCounterText;
	public GameObject stepCounterObj;
	public NewPlayerController playerScript; 

	[HideInInspector] public int goalsInPlace;


	public AudioSource backMusSrc;
	public AudioClip backMusClip;

	private bool allGoalsIn;

	private int playerX;
	private int playerY;

	// Use this for initialization
	void Start()
	{
		allGoalsIn = false; 
		goalsInPlace = 0;
		goalOneIn = false;
		goalTwoIn = false;
		goalThreeIn = false;
		timeToChange = 5f;
		row = 9;
		col = 9;
		numberOfGoalZones = 0;


		levelMap = new string[,]
		{
			{" ", " ", " ", " ", "#", "#", "#", "#", "#"},
			{"#", "#", "#", "#", "#", " ", " ", "p", "#"},
			{"#", " ", " ", "#", "#", " ", " ", " ", "#"},
			{"#", " ", "b", " ", " ", " ", " ", " ", "#"},
			{"#", " ", " ", " ", "#", "#", "#", "#", "#"},
			{"#", "#", "#", "b", "#", " ", " ", " ", " "},
			{" ", "#", " ", " ", "#", "#", "#", " ", " "},
			{" ", "#", " ", "0", "0", "0", "#", " ", " "},
			{" ", "#", "#", "#", "#", "#", "#", " ", " "}
		};
		
		levelObjs = new GameObject[9,9];

		for (int i = 0; i < row; i++)
		{
			//Debug.Log("i = " + i);

			for (int j = 0; j < col; j++)
			{
				//Debug.Log(levelMap[i, j]);
				if (levelMap[i, j] == "#")
				{
					GameObject thisWall =
						Instantiate(wall, new Vector3(i + 0.5f, j + 0.5f, 0), Quaternion.identity) as GameObject;
					Debug.Log(thisWall);
					levelObjs[i, j] = thisWall;
				}
				else if (levelMap[i, j] == "b")
				{
					GameObject thisBox =
						Instantiate(box, new Vector3(i + 0.5f, j + 0.5f, 0), Quaternion.identity) as GameObject;
					levelObjs[i, j] = thisBox;
				}
				else if (levelMap[i, j] == "p")
				{
					GameObject thisPlayer =
						Instantiate(player, new Vector3(i + 0.5f, j + 0.5f, 0), Quaternion.identity) as GameObject;
					levelObjs[i, j] = thisPlayer;
					playerX = i;
					playerY = j;
				}
				else if (levelMap[i, j] == "0")
				{
					GameObject thisGoal =
						Instantiate(goal, new Vector3(i + 0.5f, j + 0.5f, 0), Quaternion.identity) as GameObject;
					levelObjs[i, j] = thisGoal;
				}
				else
				{
					GameObject thisBlank =
						Instantiate(blankSpot, new Vector3(i + 0.5f, j + 0.5f, 0), Quaternion.identity) as GameObject;
					levelObjs[i, j] = thisBlank;
				}
			}
		}

		goalZones = GameObject.FindGameObjectsWithTag("Goal");
		//Debug.Log(goalZones.Length);

		timeToChange = 5f;

//		playerObj = GameObject.FindGameObjectWithTag("Player");
//		playerScript = playerObj.GetComponent<NewPlayerController>();
//		stepCounterObj = GameObject.FindGameObjectWithTag("Movement Counter");
//		stepCounterText = "Step Count: " + playerObj.GetComponent<NewPlayerController>().steps;
//		Debug.Log(stepCounterText);

		backMusSrc.clip = backMusClip;
		//backMusSrc.playOnAwake = backMusClip;

		boxes = GameObject.FindGameObjectsWithTag("Box");
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKey(KeyCode.DownArrow) && levelMap[playerX, playerY - 1] == " ")
		{
			levelObjs[playerX, playerY] = levelObjs[playerX, playerY - 1];
			Debug.Log("moving the player down 1 unit");
		}
		else if (Input.GetKey(KeyCode.UpArrow) && levelMap[playerX, playerY + 1] == " ")
		{
			Debug.Log("moving the player up 1 unit");
		}
		if (Input.GetKey(KeyCode.Alpha1))
		{
			//Debug.Log("Restarting the level");
			SceneManager.LoadScene("Level1");
		}

		if (Input.GetKey(KeyCode.Alpha0))
		{
			//Debug.Log("Restarting the level");
			SceneManager.LoadScene("MainMenu");
		}

		//stepCounterObj.GetComponent<Text>().text = stepCounterText;
	}

//	void LateUpdate()
//	{
//		if (playerScript.canMove == true)
//		{
//			Debug.Log("The player can move again which means we should check to see if the map is complete");
//			if (MapCompleted() == true)
//			{
//				Debug.Log("All goals in place");
//				SceneManager.LoadScene("MainMenu");
//			}
//		}
//	}

	bool MapCompleted()
	{
		for (int i = 0; i < goalZones.Length; i++)
		{
			if (goalZones[i].GetComponent<GoalZone>().getGoalStatus() == true)
			{
				allGoalsIn = true;
			}
			else
			{
				allGoalsIn = false; 
			}

			Debug.Log(i.ToString() + allGoalsIn);
		}
		
		return allGoalsIn; 
	}
	
//		if (goalsInPlace == 6)
//		{
//			Debug.Log("All goals in place");
//			timeToChange -= Time.deltaTime;
//			if (timeToChange <= 0)
//			{
//				SceneManager.LoadScene("MainMenu");
//			}
//		}
}


