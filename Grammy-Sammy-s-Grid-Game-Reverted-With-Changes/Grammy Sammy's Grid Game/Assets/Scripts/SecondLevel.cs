using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SecondLevel : MonoBehaviour {

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

	private GameObject[] boxes;

	private float timeToChange;


	[HideInInspector] public int goalsInPlace;

	public GameObject playerObj;

	public bool allGoalsIn;
	
	// Use this for initialization
	void Start ()
	{
		allGoalsIn = false; 
		goalsInPlace = 0;
		timeToChange = 5f;
		numberOfGoalZones = 0;

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
	void Update ()
	{
		if (Input.GetKey(KeyCode.Alpha1))
		{
			//Debug.Log("Restarting the level");
			SceneManager.LoadScene("Level2");
		}

		if (Input.GetKey(KeyCode.Alpha0))
		{
			//Debug.Log("Restarting the level");
			SceneManager.LoadScene("MainMenu");
		}

		MapCompleted();
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
				SceneManager.LoadScene("GameOver");
			}
		}
	}
}
